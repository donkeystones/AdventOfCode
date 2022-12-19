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

		readonly int[,] treeData2 = { { 1,1,1,1,1 },
							{ 1,2,1,0,2 },
							{ 1,2,1,2,1 },
							{ 1,2,1,1,1 },
							{ 1,1,1,1,2 },};
		[Test]
		public void CheckRightShouldReturnTrue() {
			Assert.AreEqual(true,treeVisibility.CheckRight(treeData2, 1, 2));
		}

		[Test]
		public void CheckRightShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckRight(treeData2, 3, 1));
		}

		[Test]
		public void CheckLeftShouldReturnTrue() {
			Assert.AreEqual(true, treeVisibility.CheckLeft(treeData2, 1, 2));
		}

		[Test]
		public void CheckLeftShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckLeft(treeData2, 4, 4));
		}

		[Test]
		public void CheckUpShouldReturnTrue() {
			Assert.AreEqual(true, treeVisibility.CheckUp(treeData2, 4, 4));
		}

		[Test]
		public void CheckUpShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckUp(treeData2, 1, 1));
		}

		[Test]
		public void CheckDownShouldReturnTrue() {
			Assert.AreEqual(true, treeVisibility.CheckDown(treeData2, 1, 4));
		}

		[Test]
		public void CheckDownShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckDown(treeData2, 2, 3));
		}

		[Test]
		public void TestWithDataOfTreesHiddenFartherBetween() {
			string data = "26345\n17235\n71127\n26421\n81351";


			treeVisibility.LoadData(data);
			Assert.AreEqual(20, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnesAndTwosNewEachOther() {
			string data = "22222\n21112\n21112\n21112\n22222";


			treeVisibility.LoadData(data);
			Assert.AreEqual(16, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}


	}
}
