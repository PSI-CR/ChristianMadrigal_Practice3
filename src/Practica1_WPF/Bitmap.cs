using System;
using System.Windows.Media;

namespace Practica1_WPF
{
    internal class Bitmap
    {
        private object p;

        public Bitmap(object p, int h)
        {
            this.p = p;
        }

        public int Width { get; internal set; }
        public int Height { get; internal set; }

        internal void Save(string fileName)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ImageSource(Bitmap v)
        {
            throw new NotImplementedException();
        }

        internal System.Drawing.Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        internal void SetPixel(int x, int y, System.Drawing.Color newC)
        {
            throw new NotImplementedException();
        }

        internal void SetPixel(int x, int y, Color newC)
        {
            throw new NotImplementedException();
        }
    }
}