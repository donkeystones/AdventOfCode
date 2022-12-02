using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day2;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day2 {
	public class GameDecryptorTest {
		RoundDeterminator determinator;
		MoveDecryptor decryptor;

		[SetUp]
		public void Setup() {
			determinator = new RoundDeterminator();
			decryptor = new MoveDecryptor();
		}
		[Test]
		public void AEqualsMaterialRock() {
			Assert.AreEqual(Material.ROCK, decryptor.ToMaterial("A"));
		}
		[Test]
		public void XEqualsMaterialRock() {
			Assert.AreEqual(Material.ROCK, decryptor.ToMaterial("X"));
		}
		[Test]
		public void BEqualsMaterialPaper() {
			Assert.AreEqual(Material.PAPER, decryptor.ToMaterial("B"));
		}
		[Test]
		public void YEqualsMaterialPaper() {
			Assert.AreEqual(Material.PAPER, decryptor.ToMaterial("Y"));
		}
		[Test]
		public void CEqualsMaterialScissor() {
			Assert.AreEqual(Material.SCISSOR, decryptor.ToMaterial("C"));
		}
		[Test]
		public void YEqualsMaterialScissor() {
			Assert.AreEqual(Material.SCISSOR, decryptor.ToMaterial("Z"));
		}
		[Test]
		public void RoundDeterminatorRockAndScissorEqualsThree() {
			Assert.AreEqual(3, determinator.CalculateRoundPoints(Material.ROCK, Material.SCISSOR));
		}
		[Test]
		public void RoundDeterminatorRockAndPaperEqualsEight() {
			Assert.AreEqual(8, determinator.CalculateRoundPoints(Material.ROCK, Material.PAPER));
		}
		[Test]
		public void RoundDeterminatorRockAndRockEqualsFour() {
			Assert.AreEqual(4, determinator.CalculateRoundPoints(Material.ROCK, Material.ROCK));
		}
		[Test]
		public void RoundDeterminatorPaperAndRockEqualsOne() {
			Assert.AreEqual(1, determinator.CalculateRoundPoints(Material.PAPER, Material.ROCK));
		}
		[Test]
		public void RoundDeterminatorPaperAndPaperEqualsFive() {
			Assert.AreEqual(5, determinator.CalculateRoundPoints(Material.PAPER, Material.PAPER));
		}
		[Test]
		public void RoundDeterminatorPaperAndScissorEqualsNine() {
			Assert.AreEqual(9, determinator.CalculateRoundPoints(Material.PAPER, Material.SCISSOR));
		}
		[Test]
		public void RoundDeterminatorScissorAndRockEqualsSeven() {
			Assert.AreEqual(7, determinator.CalculateRoundPoints(Material.SCISSOR, Material.ROCK));
		}
		[Test]
		public void RoundDeterminatorScissorAndPaperEqualsTwo() {
			Assert.AreEqual(2, determinator.CalculateRoundPoints(Material.SCISSOR, Material.PAPER));
		}
		[Test]
		public void RoundDeterminatorScissorAndScissorEqualsSix() {
			Assert.AreEqual(6, determinator.CalculateRoundPoints(Material.SCISSOR, Material.SCISSOR));
		}
		[Test]
		public void NeededOutcomeDecryptorXEqualsLoss() {
			Assert.AreEqual(Outcome.LOSS, decryptor.NeededOutcomeDecryptor("X"));
		}
		[Test]
		public void NeededOutcomeDecryptorYEqualsDraw() {
			Assert.AreEqual(Outcome.DRAW, decryptor.NeededOutcomeDecryptor("Y"));
		}
		[Test]
		public void NeededOutcomeDecryptorZEqualsWin() {
			Assert.AreEqual(Outcome.WIN, decryptor.NeededOutcomeDecryptor("Z"));
		}
		[Test]
		public void NeededMaterialForWinAgainstPaper() {
			Assert.AreEqual(Material.SCISSOR, decryptor.NeededMaterial(Outcome.WIN, Material.PAPER));
		}
		[Test]
		public void NeededMaterialForDrawAgainstPaper() {
			Assert.AreEqual(Material.PAPER, decryptor.NeededMaterial(Outcome.DRAW, Material.PAPER));
		}
		[Test]
		public void NeededMaterialForLossAgainstPaper() {
			Assert.AreEqual(Material.ROCK, decryptor.NeededMaterial(Outcome.LOSS, Material.PAPER));
		}
		[Test]
		public void NeededMaterialForWinAgainstRock() {
			Assert.AreEqual(Material.PAPER, decryptor.NeededMaterial(Outcome.WIN, Material.ROCK));
		}
		[Test]
		public void NeededMaterialForDrawAgainstRock() {
			Assert.AreEqual(Material.ROCK, decryptor.NeededMaterial(Outcome.DRAW, Material.ROCK));
		}
		[Test]
		public void NeededMaterialForLossAgainstRock() {
			Assert.AreEqual(Material.SCISSOR, decryptor.NeededMaterial(Outcome.LOSS, Material.ROCK));
		}
		public void NeededMaterialForWinAgainstScissor() {
			Assert.AreEqual(Material.ROCK, decryptor.NeededMaterial(Outcome.WIN, Material.SCISSOR));
		}
		[Test]
		public void NeededMaterialForDrawAgainstScissor() {
			Assert.AreEqual(Material.SCISSOR, decryptor.NeededMaterial(Outcome.DRAW, Material.SCISSOR));
		}
		[Test]
		public void NeededMaterialForLossAgainstScissor() {
			Assert.AreEqual(Material.PAPER, decryptor.NeededMaterial(Outcome.LOSS, Material.SCISSOR));
		}
	}
}
