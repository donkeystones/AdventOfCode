using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day2 {
	public enum Material {
		ROCK = 1,
		PAPER = 2,
		SCISSOR = 3,
		INVALID = 0
	}
	public class MoveDecryptor {
		public Material ToMaterial(string input) {
			if(input == "A" || input == "X")
				return Material.ROCK;
			else if(input == "B" || input == "Y")
				return Material.PAPER;
			else if(input == "C" || input == "Z")
				return Material.SCISSOR;
			return Material.INVALID;
		}

		public Outcome NeededOutcomeDecryptor(string input) {
			if(input == "X")
				return Outcome.LOSS;
			else if(input == "Y")
				return Outcome.DRAW;
			else if(input == "Z")
				return Outcome.WIN;
			return Outcome.LOSS;
		}
		public Material NeededMaterial(Outcome neededOutcome, Material opponentMaterial) {
			if(opponentMaterial == Material.ROCK && neededOutcome == Outcome.LOSS)
				return Material.SCISSOR;
			if(opponentMaterial == Material.ROCK && neededOutcome == Outcome.DRAW)
				return Material.ROCK;
			if(opponentMaterial == Material.ROCK && neededOutcome == Outcome.WIN)
				return Material.PAPER;
			if(opponentMaterial == Material.PAPER && neededOutcome == Outcome.WIN)
				return Material.SCISSOR;
			if(opponentMaterial == Material.PAPER && neededOutcome == Outcome.LOSS)
				return Material.ROCK;
			if(opponentMaterial == Material.PAPER && neededOutcome == Outcome.DRAW)
				return Material.PAPER;
			if(opponentMaterial == Material.SCISSOR && neededOutcome == Outcome.DRAW)
				return Material.SCISSOR;
			if(opponentMaterial == Material.SCISSOR && neededOutcome == Outcome.WIN)
				return Material.ROCK;
			if(opponentMaterial == Material.SCISSOR && neededOutcome == Outcome.LOSS)
				return Material.PAPER;

			return Material.INVALID;
		}
	}

}
