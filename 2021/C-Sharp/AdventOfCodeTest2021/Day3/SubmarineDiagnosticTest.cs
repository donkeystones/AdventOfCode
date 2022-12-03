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
            subdiagnostic = new SubmarineDiagnostic();
        }
		
		[Test]
		public void FindGammaValue() {
            data = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            subdiagnostic.LoadData(data);
			Assert.AreEqual(22, subdiagnostic.GetGamma());
		}

		[Test]
		public void FindEpsilonValue() {
            data = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            subdiagnostic.LoadData(data);
			Assert.AreEqual(9, subdiagnostic.GetEpsilon());
		}

		[Test]
		public void EpsilonTimesGamma() {
            data = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            subdiagnostic.LoadData(data);
			Assert.AreEqual(198, subdiagnostic.GetEpsilonTimesGamma());
		}

		//OB TODO: Add test with more bits in a row
		[Test]
		public void FindGammaValueNineBits() {
			data = "010011011\n010010110\n101100110\n010011001\n101111000";
			subdiagnostic.LoadData(data);
			Assert.AreEqual(154, subdiagnostic.GetGamma());
        }

		[Test]
        public void FindEpsilonValueNineBits() {
            data = "010011011\n010010110\n101100110\n010011001\n101111000";
            subdiagnostic.LoadData(data);
            Assert.AreEqual(357, subdiagnostic.GetEpsilon());
        }

		[Test]
        public void EpsilonTimesGammaNineBits() {
            data = "010011011\n010010110\n101100110\n010011001\n101111000";
            subdiagnostic.LoadData(data);
            Assert.AreEqual(54978, subdiagnostic.GetEpsilonTimesGamma());
        }

		[Test]
		public void GammaEpsilonAndMultiplyFromInputTxt() {
			string text = "";
			foreach (string line in System.IO.File.ReadLines("./Day3/input.txt")) {
				text += line + "\n";
			}
            subdiagnostic.LoadData(text);
			Assert.AreEqual(2581, subdiagnostic.GetGamma());
			Assert.AreEqual(1514, subdiagnostic.GetEpsilon());
			Assert.AreEqual(3907634, subdiagnostic.GetEpsilonTimesGamma());
		}

		[Test]
		public void GetOxygenGeneratorRating() {
            data = "010011011\n010010110\n101100110\n010011001\n101111000";
			subdiagnostic.LoadData(data);
			Assert.AreEqual(155, subdiagnostic.GetOxygenGeneretionVal());
        }

		[Test]
		public void GetCO2ScrubbingValue() {
            data = "010011011\n010010110\n101100110\n010011001\n101111000";
            subdiagnostic.LoadData(data);
            Assert.AreEqual(358, subdiagnostic.GetCO2ScrubbingVal());
        }

		[Test]
		public void GetLifeSupportRating() {
            data = "010011011\n010010110\n101100110\n010011001\n101111000";
            subdiagnostic.LoadData(data);
			Assert.AreEqual(55490, subdiagnostic.GetLifeSupportRating());
        }
    }
}
