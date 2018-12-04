using System;

namespace CS002
{
    abstract class A
    {
        public abstract void Func01();
        public virtual void Func02()
        {
            Console.WriteLine("Func02 in A.");
        }
    }
}
