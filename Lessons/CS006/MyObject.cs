using System.Threading;

namespace CS006
{
    class MyObject
    {
        public delegate void ProgressChangedDelegate(object sender, int percent);
        public event ProgressChangedDelegate ProgressChanged;
        public void DoWork()
        {
            for (int i = 0; i<100; i++)
            {
                ProgressChanged?.Invoke(this, i);
                Thread.Sleep(50);
            }
            ProgressChanged?.Invoke(this, 100);
        }
    }
}
