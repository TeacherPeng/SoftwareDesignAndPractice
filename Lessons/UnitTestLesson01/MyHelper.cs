namespace UnitTestLesson01
{
    public class MyHelper
    {
        public void MySort(int[] L)
        {
            for (int i = 0; i < L.Length; i++)
            {
                for (int j = 0; j < L.Length - i - 1; j++)
                {
                    if (L[j] > L[j+1])
                    {
                        int temp = L[j];
                        L[j] = L[j + 1];
                        L[j + 1] = temp;
                    }
                }
            }
        }
    }
}
