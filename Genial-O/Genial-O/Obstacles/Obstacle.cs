using System;
using Microsoft.SPOT;

namespace Genial_O
{
    class Obstacle
    {
        Vector _pos;
        int _lengthX;
        int _lengthY;
        Guid _id;

        public Obstacle(Guid id, Vector pos)
        {
            _id = id;
            _pos = pos;
        }

        public Vector Position
        {
            get
            {
                return _pos;
            }
        }

        public Guid ID
        {
            get
            {
                return _id;
            }
        }
    }
}
