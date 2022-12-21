using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Day10 {
	public class ClockCircuit {
		public int Register { get; set; }
		public int Cycles { get; set; }
		private List<int> sumOfCycles = new List<int>();

		public void Addx(int value) {
			Cycles += 2;
			if(InCycleRange()) {
				sumOfCycles.Add(Cycles * Register);
			}
			Register += value;
			
				
		}
		private void Debug() {
			Console.WriteLine("Cycles: " + Cycles + "\nRegister: " + Register);
		}

		private bool InCycleRange() {
			return Cycles % 40 == 20 || Cycles % 40 == 21;
		}

		public void Noop() {
			Cycles += 1;
			if(InCycleRange()) {
				sumOfCycles.Add(Cycles * Register);
			}
		}

		public void RunCommands(string data) {
			string[] dataArr = data.Split("\n");
			foreach(string command in dataArr) {
				string[] splitCommand = command.Split();
				Console.WriteLine("Running: " + command);
				if(splitCommand[0] == "addx")
					Addx(int.Parse(splitCommand[1]));
				else if(splitCommand[0] == "noop")
					Noop();
				Debug();
			}
		}

		public int SumOfCycles() {
			return sumOfCycles.Sum();
		}
	}
}
