using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day5;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day5 {
	public class SupplyStackTrackerTest {
		SupplyStackOrganizer organizer;
		[SetUp]
		public void Setup() {
			organizer = new SupplyStackOrganizer();
		}
		private string getData() {
			string data = "";
			foreach(string str in System.IO.File.ReadLines("./Day5/onlyStacks.txt")) {
				data += str + "\n";
			}
			return data;
		}
		[Test]
		public void ParseStacksResultInThreeStacks() {
			string data = getData();
			
			organizer.ParseStacks(data);
			Assert.AreEqual(3, organizer.Stacks.Count);
		}

		[Test]
		public void Move1FromStack1ToStack2() {
			string data = getData();

			organizer.ParseStacks(data);

			organizer.Move(1, 1, 2);
			Assert.AreEqual(1, organizer.Stacks[0].Count);
			Assert.AreEqual(4, organizer.Stacks[1].Count);
			Assert.AreEqual(1, organizer.Stacks[2].Count);
		}

		[Test]
		public void MoveParser() {
			string data = "move 1 from 2 to 1\nmove 3 from 1 to 3\nmove 2 from 2 to 1\nmove 1 from 1 to 2";

			organizer.ParseMoves(data);

			Assert.AreEqual(4, organizer.Moves.Count);
		}

		[Test]
		public void SeperateStacksFromMoves() {
			string data = "";
			foreach(string str in System.IO.File.ReadLines("./Day5/input.txt")) {
				data += str + "\n";
			}
			string[] dataArr = data.Split("\n\n");
			organizer.ParseStacks(dataArr[0]);
			organizer.ParseMoves(dataArr[1]);
		}
	}
}
