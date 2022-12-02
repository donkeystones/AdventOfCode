using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2021.Day3;
using NUnit.Framework;

namespace AdventOfCodeTest2021 {
	public class SubmarineDiagnosticTest {
		SubmarineDiagnostic subdiagnostic;
		string data;
		[SetUp]
		public void Setup() {
			data = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            subdiagnostic = new SubmarineDiagnostic();
		}

		[Test]
		public void FindGammaValue() {
			subdiagnostic.LoadData(data);
			Assert.AreEqual(22, subdiagnostic.GetGamma());
		}

		[Test]
		public void FindEpsilonValue() {
			subdiagnostic.LoadData(data);
			Assert.AreEqual(9, subdiagnostic.GetEpsilon());
		}

		[Test]
		public void EpsilonTimesGamma() {
			subdiagnostic.LoadData(data);
			Assert.AreEqual(198, subdiagnostic.GetEpsilonTimesGamma());
		}
	}
}
