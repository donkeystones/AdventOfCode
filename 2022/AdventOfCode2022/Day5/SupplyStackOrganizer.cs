using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day5 {
	public class SupplyStackOrganizer {
		public List<Stack<char>> Stacks { get; internal set; }
		public List<Move> Moves { get; internal set; }

		public void ParseStacks(string data) {
			string[] dataStrArr = data.Split("\n");
			List<List<char>> dataList = new List<List<char>>();
			char[] dataCharArr;
			int i = 0;
			foreach(string str in dataStrArr) {
				if(str[1] == '1' || str == "") break;
				dataList.Add(new List<char>());
				dataCharArr = str.ToCharArray();
				for(int j = 1; j < dataCharArr.Length; j += 4) {
					dataList[i].Add(dataCharArr[j]);
				}
				i++;
			}

			Stacks = ConvertToStacks(dataList);
		}

		private List<Stack<char>> PopulateDataStack(List<Stack<char>> dataStack, int columns) {
			List<Stack<char>> temp = dataStack;
			for(int i = 0; i < columns;i++) {
				temp.Add(new Stack<char>());
			}

			return temp;

		}

		public void Move(int amount, int fromStack, int toStack) {
			for(int i = 0; i < amount;i++) {
				Stacks[toStack-1].Push(Stacks[fromStack-1].Pop());
			}
		}

		private List<Stack<char>> ConvertToStacks(List<List<char>> dataList) {
			List<Stack<char>> dataStack = new List<Stack<char>>();
			dataStack = PopulateDataStack(dataStack, dataList[0].Count);
			for(int i = dataList.Count - 1; i >= 0;i--) {
				
				if(dataList[i].Count == 0)
					continue;
				for(int j = 0; j < dataList[i].Count;j++) {
					if(dataList[i][j] != ' ')
						dataStack[j].Push(dataList[i][j]);
				}
			}

			return dataStack;
		}

		public void ParseMoves(string data) {
			Moves = new List<Move>();
			string[] dataArr = data.Split("\n");
			string[] move;
			foreach(string str in dataArr) {
				move = str.Split(" ");
				Moves.Add(new Move() {
					Amount = int.Parse(move[1]),
					FromStack = int.Parse(move[3]),
					ToStack = int.Parse(move[5])
				});
			}
		}
	}
}
