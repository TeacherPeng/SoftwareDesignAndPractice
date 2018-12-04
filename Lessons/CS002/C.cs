using System;

namespace CS002
{
    class C : A
    {
        public override void Func01() => Console.WriteLine("Func01 in C.");
        public override void Func02()
        {
            base.Func02();
            Console.WriteLine("Func02 in C.");
        }
    }
}
