using System;

namespace CS002
{
    class B : A
    {
        public override void Func01()
        {
            Console.WriteLine("Func01 in B.");
        }
        public override void Func02() => Console.WriteLine("Func02 in B.");
    }
}
