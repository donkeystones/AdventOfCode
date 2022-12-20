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

		readonly int[,] treeData = { { 1,1,1,1,1 },
							{ 1,2,1,2,1 },
							{ 1,2,1,2,1 },
							{ 1,2,1,2,1 },
							{ 1,1,1,1,1 },};
		[Test]
		public void TwentyFiveTressShouldBeVisible() {
			Assert.AreEqual(22, treeVisibility.GetTotalVisibleTrees(treeData));
		}

		[Test]
		public void LoadTreeData() {
			string data = "30373\n25512\n65332\n33549\n35390\n";

			treeVisibility.LoadData(data);
			Assert.AreEqual(4,treeVisibility.TreeData.GetUpperBound(0));
			Assert.AreEqual(4, treeVisibility.TreeData.GetUpperBound(1));
		}

		[Test]
		public void LoadTreeData3x5() {
			string data = "30373\n25512\n65332\n";

			treeVisibility.LoadData(data);
			Assert.AreEqual(2, treeVisibility.TreeData.GetUpperBound(0));
			Assert.AreEqual(4, treeVisibility.TreeData.GetUpperBound(1));
		}

		[Test]
		public void TestAOC() {
			string data = "30373\n25512\n65332\n33549\n35390\n";

			treeVisibility.LoadData(data);
			Assert.AreEqual(21, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		readonly int[,] treeData2 = { 
							{ 1,1,1,1,1 },
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
			Assert.AreEqual(true, treeVisibility.CheckUp(treeData2, 4, 3));
		}

		[Test]
		public void CheckUpShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckUp(treeData2, 1, 1));
		}

		[Test]
		public void CheckDownShouldReturnTrue() {
			Assert.AreEqual(true, treeVisibility.CheckDown(treeData2, 1, 3));
		}

		[Test]
		public void CheckDownShouldReturnFalse() {
			Assert.AreEqual(false, treeVisibility.CheckDown(treeData2, 2, 3));
		}

		[Test]
		public void TestWithDataOfTreesHiddenFartherBetween() {
			string data = "26345\n" +
						  "17235\n" +
						  "71127\n" +
						  "26421\n" +
						  "81351\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(20, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnesAndTwosNewEachOther() {
			string data = "22222\n" +
						  "21112\n" +
						  "21112\n" +
						  "21112\n" +
						  "22222\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(16, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnlyHiddenTreeIsUpmostrightCorner() {
			string data = "11131\n" +
						  "54323\n" +
						  "65431\n" +
						  "76541\n" +
						  "87651\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(24, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnlyHiddenTreeIsUpmostLeftCorner() {
			string data = "13111\n" +
						  "32345\n" +
						  "13456\n" +
						  "14567\n" +
						  "15678\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(24, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnlyHiddenTreeIsLowerMostLeftCorner() {
			string data = "15678\n" +
						  "14567\n" +
						  "13456\n" +
						  "32345\n" +
						  "13111\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(24, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		[Test]
		public void OnlyHiddenTreeIsLowerMostRightCorner() { 
			string data = "87651\n76541\n65421\n54323\n11131\n";


			treeVisibility.LoadData(data);
			Assert.AreEqual(24, treeVisibility.GetTotalVisibleTrees(treeVisibility.TreeData));
		}

		public void CheckScenicScore() {
			string data = "22222\n" +
						  "21112\n" +
						  "20102\n" +
						  "20002\n" +
						  "22222\n";
			treeVisibility.LoadData(data);
			Assert.AreEqual(1, treeVisibility.GetScenicScore(treeVisibility.TreeData, 1, 2));
		}

	}
}
