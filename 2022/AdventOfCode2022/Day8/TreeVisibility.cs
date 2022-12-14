using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day8 {
	public class TreeVisibility {
		public int[,] TreeData { get; internal set; }
		public bool CheckVisibility(int middle, int left, int right, int down) => 
				middle <= left &&
				middle <= right &&
				middle <= down;

		public int GetTotalVisibleTrees(int[,] treeData) {
			int total = 0;
			for(int y = 1; y < treeData.GetUpperBound(0);y++) {
				for(int x = 1; x < treeData.GetUpperBound(1);x++) {
					if(CheckVisibility(treeData[y, x], 
									   treeData[y, x - 1], 
									   treeData[y, x + 1], 
									   treeData[y + 1, x])) {
						Console.WriteLine(treeData[y, x]);
						total += 1;
					}
				}
			}
			return treeData.Length - (total);
		}

		public void LoadData(string data) {
			string[] dataArr = data.Split("\n");
			TreeData = new int[dataArr.Length, dataArr[0].Length];

			for(int y = 0; y < dataArr.Length; y++) {
				for(int x = 0;x < dataArr[y].Length;x++) {
					if(dataArr[y] != "")
						TreeData[y, x] = int.Parse(dataArr[y][x].ToString());
				}
			}
		}
	}
}
