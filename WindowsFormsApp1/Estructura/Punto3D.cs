using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Estructura
{
    public struct Punto3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Punto3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Punto3D operator +(Punto3D a, Punto3D b)
        {
            return new Punto3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

    }
}
