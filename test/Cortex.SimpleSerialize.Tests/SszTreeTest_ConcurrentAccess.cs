using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Cortex.SimpleSerialize.Tests
{
    [TestClass]
    public class SszTreeTest_ConcurrentAccess
    {
        [TestMethod]
        public async Task ConcurrentAccessFromMultipleThreads()
        {
            var bytes = new byte[64];
            bytes[0] = 1;

            void Test()
            {
                for (var i = 0; i < 100; i++)
                {
                    var instance = new SszTree(new SszBasicVector(bytes));
                    Convert.ToBase64String(instance.HashTreeRoot()).ShouldBe("FqurNB+383Difk2tz4F2bdDf0K5kRpR3uyz2YUk4sq8=");
                }
            }

            var tasks = Enumerable.Range(1, 5).Select(_ => Task.Run(Test)).ToArray();
            await Task.WhenAll(tasks);
        }
     }
}
