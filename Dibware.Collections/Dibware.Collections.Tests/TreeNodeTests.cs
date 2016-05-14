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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenInstantiatedWithNullTag_ThrowsException()
        {
            // ARRANGE
            const string text = "Hello";
            string tag = null;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            // ReSharper disable once ExpressionIsAlwaysNull
            new TreeNode<string>(text, tag);
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
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void GetRecursiveNodes_WhenCalledWithNestedNodeLists_ReturnsNodesAsFlatttenedList()
        {
            // ARRANGE

            var grandParent = new TreeNode<Byte>("Garand Parent", (byte)1);

            // ACT
            throw new NotImplementedException();

            // ASSERT
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
            CollectionAssert.AreEqual(children, node.Children);
        }

        [TestMethod]
        public void Children_AfterCallingAppendChildrenWhenNot_ResultsInAppendedChildrenAddedToEnd()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            TreeNodeList<Byte> originalChildren = new TreeNodeList<Byte>(node);
            TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);
            node.AppendChildren(originalChildren);


            // ACT
            node.AppendChildren(children);

            // ASSERT
            Assert.IsNotNull(node.Children);
        }

        //[TestMethod]
        //public void Nodes_AfterInstantiationWithChildNodes_ReturnsSameInstanceOfChildNodes()
        //{
        //    // ARRANGE
        //    var node = new TreeNode<byte>();
        //    TreeNodeList<Byte> children = new TreeNodeList<Byte>(node);

        //    // ACT
        //    node.AppendChildren(children);

        //    // ASSERT
        //    Assert.AreSame(children, node.Children);
        //}

        [TestMethod]
        public void Nodes_AfterReplaceChildrenWithChildNodes_ReturnsSameInstanceOfChildNodes()
        {
            // ARRANGE
            var node = new TreeNode<byte>();
            var children = new TreeNodeList<Byte>(node)
            {
                new TreeNode<byte>("A", 1),
                new TreeNode<byte>("B", 2),
                new TreeNode<byte>("C", 3)
            };

            // ACT
            node.ReplaceChildren(children);

            // ASSERT
            Assert.AreSame(children[0], node.Children[0]);
            Assert.AreSame(children[1], node.Children[1]);
            Assert.AreSame(children[2], node.Children[2]);
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

        [TestMethod]
        public void Children_AfterCallingReplaceChildrenWithValidChildNodes_ReturnsSameInstance()
        {
            // ARRANGE
            var node = new TreeNode<Byte>();

            var nodeList1 = new TreeNodeList<Byte>(node)
            {
                new TreeNode<byte>("A", 1),
                new TreeNode<byte>("B", 2),
                new TreeNode<byte>("C", 3)
            };

            var nodeList2 = new TreeNodeList<Byte>(node)
            {
                new TreeNode<byte>("D", 4),
                new TreeNode<byte>("E", 5),
                new TreeNode<byte>("F", 6)
            };

            node.ReplaceChildren(nodeList1);

            // ACT
            node.ReplaceChildren(nodeList2);

            // ASSERT
            Assert.AreNotSame(nodeList1, node.Children);
            Assert.AreSame(nodeList2, node.Children);
            CollectionAssert.AreNotEqual(nodeList1, node.Children);
            CollectionAssert.AreEqual(nodeList2, node.Children);
        }

        [TestMethod]
        public void ToString_WhenCalled_ReturnsCorrectFormat()
        {
            // ARRANGE
            const byte tag = (byte)5;
            var node = new TreeNode<Byte>("Test", tag);

            // ACT
            var actual = node.ToString();

            // ASSERT
            Assert.AreEqual("Dibware.Collections.TreeNode`1[System.Byte] [Test:5]", actual);
        }
    }
}