using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day10;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day10 {
	public class ClockCircuitTest {

		ClockCircuit clockCircuit;

		[SetUp]
		public void Setup() {
			clockCircuit = new ClockCircuit();
		}

		[Test]
		public void AddXOne() {
			clockCircuit.Addx(1);

			Assert.AreEqual(1, clockCircuit.Register);
			Assert.AreEqual(2, clockCircuit.Cycles);
		}

		[Test]
		public void NOOP() {
			clockCircuit.Noop();

			Assert.AreEqual(0, clockCircuit.Register);
			Assert.AreEqual(1, clockCircuit.Cycles);
		}

		[Test]
		public void ParseData() {
			string data = "noop\naddx 3";

			clockCircuit.RunCommands(data);

			Assert.AreEqual(3, clockCircuit.Cycles);
			Assert.AreEqual(3, clockCircuit.Register);
		}

		[Test]
		public void GetSumOf20thCycle() {
			string data = "addx 15\naddx -11\naddx 6\naddx -3\naddx 5\naddx -1\naddx -8\naddx 13\naddx 4\nnoop\naddx -1";

			clockCircuit.RunCommands(data);
			Assert.AreEqual(420, clockCircuit.SumOfCycles());
		}

		[Test]
		public void GetSumOfAllCyclesAOCTestInput() {
			string data = "";
			foreach(string str in System.IO.File.ReadLines("./Day10/input.txt")) {
				data += str + "\n";
			}
			clockCircuit.RunCommands(data);
			Assert.AreEqual(13140, clockCircuit.SumOfCycles());
		}
	}
}
