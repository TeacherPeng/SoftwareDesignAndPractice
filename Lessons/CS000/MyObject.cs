using System;

namespace CS000
{
    class MyObject
    {
        public int X
        {
            get { return _X; }
            set
            {
                if (value < 0) return;
                _X = value;
            }
        }
        private int _X;

        public int Y
        {
            get => _Y;
            set
            {
                if (value < 0) return;
                _Y = value;
            }
        }
        private int _Y;

        public int Z { get; set; }

        public string Text => $"X={X}, Y={Y}, Z={Z}";
        public override string ToString() => Text;
        public void Print() { Console.WriteLine(this); }
    }
}
