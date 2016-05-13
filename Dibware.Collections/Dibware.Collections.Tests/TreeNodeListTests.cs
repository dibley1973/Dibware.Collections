using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dibware.Collections.Tests
{
    [TestClass]
    public class TreeNodeListTests
    {
        [TestMethod]
        public void ChildCount_AfterInstantiation_ReturnsZero()
        {
            // ARRANGE
            var owner = new TreeNode<Byte>();
            var nodeList = new TreeNodeList<Byte>(owner);

            // ACT
            var actual = nodeList.ChildCount;

            // ASSERT
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Children_AfterInstantiation_ReturnsNonNull()
        {
            // ARRANGE
            var owner = new TreeNode<Byte>();
            var nodeList = new TreeNodeList<Byte>(owner);

            // ACT
            var actual = nodeList.Children;

            // ASSERT
            Assert.IsNotNull(actual);
        }
    }
}