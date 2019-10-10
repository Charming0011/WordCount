using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class excuteTests
    {
        [TestMethod()]
        public void CountWordTest()
        {
            String path = "F:/GitRepos/WordCount/201731062308/WordCount/test.txt";
            excute countword = new excute();
            int a = 7;
            int b = countword.CountWord(path);
            Assert.AreEqual(a, b);
        }

        [TestMethod()]
        public void CountLineTest()
        {
            String path = "F:/GitRepos/WordCount/201731062308/WordCount/test.txt";
            excute countword = new excute();
            int a = 2;
            int b = countword.CountLine(path);
            Assert.AreEqual(a, b);
        }
    }
}