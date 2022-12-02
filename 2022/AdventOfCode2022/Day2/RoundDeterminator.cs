using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day2 {
	public enum Outcome {
		WIN = 6,
		DRAW = 3,
		LOSS = 0
	}
	public class RoundDeterminator {
		public int CalculateRoundPoints(Material elveMaterial, Material playerMaterial) {
			if(elveMaterial == Material.ROCK && playerMaterial == Material.SCISSOR)
				return (int)Outcome.LOSS + (int)Material.SCISSOR;
			else if(elveMaterial == Material.ROCK && playerMaterial == Material.PAPER)
				return (int)Outcome.WIN + (int)Material.PAPER;
			else if(elveMaterial == Material.ROCK && playerMaterial == Material.ROCK)
				return (int)Outcome.DRAW + (int)Material.ROCK;
			else if(elveMaterial == Material.PAPER && playerMaterial == Material.ROCK) 
				return (int)Outcome.LOSS + (int)Material.ROCK;
			else if(elveMaterial == Material.PAPER && playerMaterial == Material.PAPER)
				return (int)Outcome.DRAW + (int)Material.PAPER;
			else if(elveMaterial == Material.PAPER && playerMaterial == Material.SCISSOR)
				return (int)Outcome.WIN + (int)Material.SCISSOR;
			else if(elveMaterial == Material.SCISSOR && playerMaterial == Material.ROCK)
				return (int)Outcome.WIN + (int)Material.ROCK;
			else if(elveMaterial == Material.SCISSOR && playerMaterial == Material.PAPER)
				return (int)Outcome.LOSS + (int)Material.PAPER;
			else if(elveMaterial == Material.SCISSOR && playerMaterial == Material.SCISSOR)
				return (int)Outcome.DRAW + (int)Material.SCISSOR;
			return 0;
		}
	}
}
