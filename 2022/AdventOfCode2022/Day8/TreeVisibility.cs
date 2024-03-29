﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022.Day8 {
	public class TreeVisibility {
		public int[,] TreeData { get; internal set; }

		public bool CheckVisibility(int[,] treeData, int y, int x) =>
				CheckRight(treeData, y, x) &&
				CheckLeft(treeData, y, x) &&
				CheckUp(treeData, y, x) &&
				CheckDown(treeData, y, x);

		public bool CheckRight(int[,] treeData, int input_y, int input_x) {
			for(int x = input_x+1; x <= treeData.GetUpperBound(1);x++) {
				if(treeData[input_y, input_x] <= treeData[input_y, x])
					return true;
			}
			return false;
		}

		public bool CheckLeft(int[,] treeData, int input_y, int input_x) {
			for(int x = input_x - 1;x >= 0;x--) {
				if(treeData[input_y, input_x] <= treeData[input_y, x])
					return true;
			}
			return false;
		}

		public bool CheckUp(int[,] treeData, int input_y, int input_x) {
			for(int y = input_y - 1;y >= 0;y--) {
				if(treeData[input_y, input_x] <= treeData[y, input_x])
					return true;
			}
			return false;
		}

		public bool CheckDown(int[,] treeData, int input_y, int input_x) {
			for(int y = input_y + 1;y <= treeData.GetUpperBound(0);y++) {
				if(treeData[input_y, input_x] <= treeData[y, input_x])
					return true;
			}
			return false;
		}

		public void Debug(int[,] treeData, int iny, int inx) {
			Console.WriteLine("Number On X: " + treeData[iny, inx]);
			Console.WriteLine("IsHidden: " + CheckVisibility(treeData,iny, inx));
			for(int y = 0;y <= treeData.GetUpperBound(0);y++) {
				for(int x = 0;x <= treeData.GetUpperBound(1);x++) {
					if(y == iny && x == inx)
						Console.Write("X ");
					else 
						Console.Write(treeData[y, x] + " ");
				}
				Console.WriteLine();
			}
		}

		public int GetTotalVisibleTrees(int[,] treeData) {
			int total = 0;
			for(int y = 1; y < treeData.GetUpperBound(0);y++) {
				for(int x = 1; x < treeData.GetUpperBound(1);x++) {
					if(CheckVisibility(treeData,y,x)) {
						total += 1;
					}
				}
			}
			return treeData.Length - (total);
		}

		public void LoadData(string data) {
			string[] dataArr = data.Split("\n");
			TreeData = new int[dataArr.Length-1, dataArr[0].Length];

			for(int y = 0; y < dataArr.Length; y++) {
				for(int x = 0;x < dataArr[y].Length;x++) {
					if(dataArr[y] != "")
						TreeData[y, x] = int.Parse(dataArr[y][x].ToString());
				}
			}
		}

		public int TreesSeenRight(int[,] treeData, int input_y, int input_x) {
			int total = 0;
			for(int x = input_x + 1;x <= treeData.GetUpperBound(1);x++) {
				total++;
				if(treeData[input_y, input_x] <= treeData[input_y, x])
					return total;
				
			}
			return total;
		}

		public int TreesSeenLeft(int[,] treeData, int input_y, int input_x) {
			int total = 0;
			for(int x = input_x - 1;x >= 0;x--) {
				total++;
				if(treeData[input_y, input_x] <= treeData[input_y, x])
					return total;

			}
			return total;
		}

		public int TreesSeenUp(int[,] treeData, int input_y, int input_x) {
			int total = 0;
			for(int y = input_y - 1;y >= 0;y--) {
				total++;
				if(treeData[input_y, input_x] <= treeData[y, input_x])
					return total;

			}
			return total;
		}

		public int TreesSeenDown(int[,] treeData, int input_y, int input_x) {
			int total = 0;
			for(int y = input_y + 1;y <= treeData.GetUpperBound(0);y++) {
				total++;
				if(treeData[input_y, input_x] <= treeData[y, input_x])
					return total;

			}
			return total;
		}

		public int GetScenicScore(int[,] treeData, int y, int x) {
			return TreesSeenRight(treeData, y, x) *
				TreesSeenLeft(treeData, y, x) *
				TreesSeenUp(treeData, y, x) *
				TreesSeenDown(treeData, y, x);
		}

		public int CalculateHighestScenicScore(int[,] treeData) {
			int highest = 0;
			for(int y = 0;y < treeData.GetUpperBound(0);y++) {
				for(int x = 0;x < treeData.GetUpperBound(1);x++) {
					int scenic = GetScenicScore(treeData, y, x);
					if(scenic > highest)
						highest = scenic;
				}
			}
			return highest;
		}
	}
}
