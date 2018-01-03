using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLesson01.Tests
{
    [TestClass()]
    public class MyHelperTests
    {
        const int TestLength = 16;
        // 有序序列的排序测试
        [TestMethod()]
        public void MySortTest1()
        {
            MyHelper aTarget = new MyHelper();

            int[] L = new int[TestLength];
            for (int i = 0; i < L.Length; i++) L[i] = i + 1;
            aTarget.MySort(L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], i + 1);
        }

        // 逆序序列的排序测试
        [TestMethod]
        public void MySortTest2()
        {
            MyHelper aTarget = new MyHelper();

            int[] L = new int[TestLength];
            for (int i = 0; i < L.Length; i++) L[i] = TestLength - i;
            aTarget.MySort(L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], i + 1);
        }

        // 随机序列的排序测试
        [TestMethod]
        public void MySortTest3()
        {
            MyHelper aTarget = new MyHelper();

            int[] L = new int[TestLength];

            Random aRandom = new Random();
            for (int i = 0; i < L.Length; i++)
                L[i] = i + 1;
            for (int i = 0; i < 100; i++)
            {
                int a = aRandom.Next() % TestLength;
                int b = aRandom.Next() % TestLength;
                if (a != b)
                {
                    int temp = L[a];
                    L[a] = L[b];
                    L[b] = temp;
                }
            }

            aTarget.MySort(L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], i + 1);
        }
    }
}