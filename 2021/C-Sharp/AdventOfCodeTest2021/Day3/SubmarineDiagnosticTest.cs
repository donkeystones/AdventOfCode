using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2021.Day3;
using NUnit.Framework;

namespace AdventOfCodeTest2021 {
	public class SubmarineDiagnosticTest {
		SubmarineDiagnostic subdiagnostic;
		[SetUp]
		public void Setup() {
			subdiagnostic = new SubmarineDiagnostic();
		}

		[Test]
		public void FindGammaValue() {
			string data = "1010101\n0010011\n1000010\n1110011";
			subdiagnostic.LoadData(data);
			Assert.AreEqual(83, subdiagnostic.GetGamma());
		}

		[Test]
		public void FindEpsilonValue() {
			string data = "1010101\n0010011\n1000010\n1110011";
			subdiagnostic.LoadData(data);
			Assert.AreEqual(44, subdiagnostic.GetEpsilon());
		}

		[Test]
		public void EpsilonTimesGamma() {
			string data = "1010101\n0010011\n1000010\n1110011";
			subdiagnostic.LoadData(data);
			Assert.AreEqual(3652, subdiagnostic.GetEpsilonTimesGamma());
		}
	}
}
