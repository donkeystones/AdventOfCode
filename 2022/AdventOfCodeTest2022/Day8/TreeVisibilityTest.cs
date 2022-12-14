using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day8;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day8 {
	public class TreeVisibilityTest {
		TreeVisibility treeVisibility;
		[SetUp]
		public void Setup() {
			treeVisibility = new TreeVisibility();
		}
		[Test]
		public void MiddleTreeShouldNotBeVisible() {
			Assert.AreEqual(true, treeVisibility.CheckVisibility(1, 2, 2, 2));
		}

		[Test]
		public void MiddleTreeNotShouldBeVisibleFromLeft() {
			Assert.AreEqual(true, treeVisibility.CheckVisibility(1, 1, 2, 2));
		}

		readonly int[,] treeData = { { 1,1,1,1,1 },
							{ 1,2,1,2,1 },
							{ 1,2,1,2,1 },
							{ 1,2,1,2,1 },
							{ 1,1,1,1,1 },};
		[Test]
		public void TwentyOneTressShouldBeVisible() {
			Assert.AreEqual(22, treeVisibility.GetTotalVisibleTrees(treeData));
		}

		[Test]
		public void LoadTreeData() {
			string data = "30373\n25512\n65332\n33549\n35390";

			treeVisibility.LoadData(data);
			Assert.AreEqual(4,treeVisibility.TreeData.GetUpperBound(0));
			Assert.AreEqual(4, treeVisibility.TreeData.GetUpperBound(1));
		}

		[Test]
		public void LoadTreeData3x5() {
			string data = "30373\n25512\n65332";

			treeVisibility.LoadData(data);
			Assert.AreEqual(2, treeVisibility.TreeData.GetUpperBound(0));
			Assert.AreEqual(4, treeVisibility.TreeData.GetUpperBound(1));
		}

		[Test]
		public void TestAOC() {
			string data = "30373\n25512\n65332\n33549\n35390";

			treeVisibility.LoadData(data);
			Assert.AreEqual(21, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}
	}
}
