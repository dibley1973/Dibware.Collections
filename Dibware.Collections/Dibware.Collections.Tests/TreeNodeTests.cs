using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dibware.Collections.Tests
{
    [TestClass]
    public class TreeNodeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenInstantiatedWithNullText_ThrowsException()
        {
            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            new TreeNode<byte>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenInstantiatedWithEmptyText_ThrowsException()
        {
            // ARRANGE
            var text = string.Empty;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            new TreeNode<byte>(text);
        }

        [TestMethod]
        public void Nodes_AfterInstantiation_ReturnsEmptyList()
        {
            // ARRANGE
            var treeNode = new TreeNode<byte>();

            // ACT
            var actual = treeNode.Children;

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.ChildCount);
        }

        [TestMethod]
        public void Tag_AfterInstantiation_ReturnsNull()
        {
            // ARRANGE
            var treeNode = new TreeNode<string>();

            // ACT
            var actual = treeNode.Tag;

            // ASSERT
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Tag_AfterSetting_ReturnsSetObject()
        {
            // ARRANGE
            byte[] expected = { 1, 2, 3 };
            var treeNode = new TreeNode<byte[]> { Tag = expected };

            // ACT
            var actual = treeNode.Tag;

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void Text_AfterInstantiationWithoutText_ReturnsEmptyString()
        {
            // ARRANGE
            var treeNode = new TreeNode<byte>();

            // ACT
            var actual = treeNode.Text;

            // ASSERT
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Text_AfterInstantiationWithText_ReturnsInstantiatedValue()
        {
            // ARRANGE
            const string expected = "Yo!";
            var treeNode = new TreeNode<byte>(expected);

            // ACT
            var actual = treeNode.Text;

            // ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Text_AfterSetting_ReturnsSetValue()
        {
            // ARRANGE
            const string expected = "Yo!";
            var treeNode = new TreeNode<byte>(expected)
            {
                Text = expected
            };

            // ACT
            var actual = treeNode.Text;

            // ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AppendChildren_WhenCalleddWithNullChildNodes_ThrowsException()
        {
            // ARRANGE
            var node = new TreeNode<Byte>();

            // ACT
            node.AppendChildren(null);
        }

        [TestMethod]
        public void Children_AfterCallingAppend_ResultsInNotNull()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);

            // ACT
            node.AppendChildren(children);

            // ASSERT
            Assert.IsNotNull(node.Children);
        }

        [TestMethod]
        public void Children_AfterCallingAppendChildrenWhenEmpty_ResultsInOnlyAppendedChildren()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);

            // ACT
            node.AppendChildren(children);

            // ASSERT
            Assert.AreSame(children, node.Children);
        }

        [TestMethod]
        public void Children_AfterCallingAppendChildrenWhenNot_ResultsInAppendedChildrenAddedToEnd()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            TreeNodeList<Byte> originalChildren = new TreeNodeList<Byte>(node);
            TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);

            // ACT
            node.AppendChildren(children);

            // ASSERT
            Assert.IsNotNull(node.Children);
        }



        [TestMethod]
        public void Nodes_AfterInstantiationWithChildNodes_ReturnsSameInstanceOfChildNodes()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);

            // ACT
            node.AppendChildren(children);

            // ASSERT
            Assert.AreSame(children, node.Children);
        }




        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReplaceChildren_WhenCalleddWithNullChildNodes_ThrowsException()
        {
            // ARRANGE
            var node = new TreeNode<Byte>();

            // ACT
            node.ReplaceChildren(null);
        }
    }
}