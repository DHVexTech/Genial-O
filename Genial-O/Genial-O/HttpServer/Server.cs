using System;
using Microsoft.SPOT;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text;
using Microsoft.SPOT.Hardware;

namespace Genial_O.HttpServer
{
    class Server
    {
        private Socket socket = null;
        private IPAddress _synchronizedClientIp;
        private Robot _robot;

        public Server(Robot robot)
        {
            _robot = robot;
            IPAddress ip = IPAddress.Parse("192.168.43.160");
            //Initialize Socket class
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Request and bind to an IP from DHCP server
            socket.Bind(new IPEndPoint(IPAddress.Any, 80));
            //Debug print our IP address
            Debug.Print(Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPAddress);
            //Start listen for web requests
            socket.Listen(10);
        }

        public Socket Socket
        {
            get
            {
                lock (socket)
                {
                    return socket;
                }
            }
        }

        public void ListenForRequest()
        {
            while (true)
            {
                try
                {
                    Debug.Print("Search");
                    using (Socket clientSocket = socket.Accept())
                    {
                        //Get clients IP
                        IPEndPoint clientIp = clientSocket.RemoteEndPoint as IPEndPoint;
                        EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
                        int bytesReceived = clientSocket.Available;
                        
                        if (bytesReceived > 0)
                        {
                            Debug.Print("Find");
                            //Get request
                            byte[] buffer = new byte[bytesReceived];
                            int byteCount = clientSocket.Receive(buffer, bytesReceived, SocketFlags.None);
                            string request = new string(Encoding.UTF8.GetChars(buffer));

                            if (clientIp != null && (_synchronizedClientIp != null && clientIp.Address.ToString() == _synchronizedClientIp.ToString()))
                            {
                                //Analyze the message then send a response
                                MessageAnalyse(Utility.ParseQueryString(request), clientSocket, clientIp);
                            }
                            else if (_synchronizedClientIp == null)
                            {
                                MessageAnalyse(Utility.ParseQueryString(request), clientSocket, clientIp);
                            }
                            else
                            {
                                const string response = "Someone is already synchronized";
                                SendResponse(clientSocket, response);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }

            }
        }

        #region IDisposable Members
        ~Server()
        {
            Dispose();
        }

        public void MessageAnalyse(Hashtable nvc, Socket clientSocket, IPEndPoint clientIp)
        {

            if (nvc == null)
            {
                const string response = "Welcome to Genial-O, the funny robot";
                SendResponse(clientSocket, response);
                return;
            }

            if (_synchronizedClientIp != null && _synchronizedClientIp.ToString() != clientIp.Address.ToString())
            {
                string response = "Someone is already synchronized";
                SendResponse(clientSocket, response);
                return;
            }

            foreach (DictionaryEntry entry in nvc)
            {
                string response;
                switch ((string)entry.Key)
                {

                    case "Synchronize":
                        IPAddress ip = null;
                        try
                        {
                            ip = IPAddress.Parse((string)entry.Value);
                        }
                        catch (Exception e)
                        {
                            Debug.Print("Exception in ip synchronization : " + e.ToString());
                        }

                        if (ip != null)
                        {
                            _synchronizedClientIp = ip;
                        }
                        response = "Client synchronized : " + _synchronizedClientIp.ToString();
                        SendResponse(clientSocket, response);
                        break;

                    case "Desynchronize":
                        string tmp = _synchronizedClientIp.ToString();
                        if ((string)entry.Value == _synchronizedClientIp.ToString())
                        {
                            _synchronizedClientIp = null;
                        }
                        response = "Client unsynchronized : " + tmp;
                        SendResponse(clientSocket, response);
                        break;
                    case "Forward":
                        if ((string)entry.Value == "true")
                        {
                            _robot.GoForward();
                            response = "Robot going forward";
                            SendResponse(clientSocket, response);
                        }
                        break;
                    case "Backward":
                        if ((string)entry.Value == "true")
                        {
                            _robot.GoBackward();
                            response = "Robot going backward";
                            SendResponse(clientSocket, response);
                        }
                        break;
                    case "Right":
                        if ((string)entry.Value == "true")
                        {
                            _robot.GoRight();
                            response = "Robot turning right";
                            SendResponse(clientSocket, response);
                        }
                        break;
                    case "Left":
                        if ((string)entry.Value == "true")
                        {
                            _robot.GoLeft();
                            response = "Robot turning left";
                            SendResponse(clientSocket, response);
                        }
                        break;


                    default:
                        response = "Welcome to RSAMART VAL AND RAMI SAY HELLO TO YOU";
                        SendResponse(clientSocket, response);
                        break;
                }
            }
        }

        public string CreateHeader(string response)
        {
            return "HTTP/1.0 200 OK\r\nContent-Type: text charset=utf-8\r\nAccess-Control-Allow-Origin: *\r\nContent-Length: " + response.Length.ToString() + "\r\nConnection: close\r\n\r\n";
        }

        public void SendResponse(Socket clientSocket, string response)
        {
            string header = CreateHeader(response);
            clientSocket.Send(Encoding.UTF8.GetBytes(header), header.Length, SocketFlags.None);
            clientSocket.Send(Encoding.UTF8.GetBytes(response), response.Length, SocketFlags.None);
        }

        public void Dispose()
        {
            if (socket != null)
                socket.Close();
        }
        #endregion
    }
}
