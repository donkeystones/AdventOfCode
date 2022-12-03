using AdventOfCode2022.Day3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCodeTest2022.Day3 {
    public class RuckSackOrganizerTest {
        RuckSackOrganizer ruckSackOrganizer;

        [SetUp]
        public void Setup() {
            ruckSackOrganizer = new RuckSackOrganizer();
        }

        [Test]
        public void AllIsSplitIntoTwoCompartments() {
            string ruckSack = "vJrwpWtwJgWrhcsFMMfFFhFp";

            ruckSackOrganizer.LoadRuckSack(ruckSack);
            Assert.AreEqual(1, ruckSackOrganizer.RuckSacks.Count);
            Assert.AreEqual("vJrwpWtwJgWr", ruckSackOrganizer.RuckSacks[0].FirstCompartment);
            Assert.AreEqual("hcsFMMfFFhFp", ruckSackOrganizer.RuckSacks[0].SecondCompartment);
        }

        [Test]
        public void TwoRuckSacksIncreasesRuckSackList() {
            string ruckSack = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL";

            ruckSackOrganizer.LoadRuckSack(ruckSack);
            Assert.AreEqual(2, ruckSackOrganizer.RuckSacks.Count);
            Assert.AreEqual("vJrwpWtwJgWr", ruckSackOrganizer.RuckSacks[0].FirstCompartment);
            Assert.AreEqual("hcsFMMfFFhFp", ruckSackOrganizer.RuckSacks[0].SecondCompartment);
            Assert.AreEqual("jqHRNqRjqzjGDLGL", ruckSackOrganizer.RuckSacks[1].FirstCompartment);
            Assert.AreEqual("rsFMfFZSrLrFZsSL", ruckSackOrganizer.RuckSacks[1].SecondCompartment);
            
        }

        [Test]
        public void FindItemContainedInBothCompartements() {
            RuckSack ruckSack = new RuckSack() {
                FirstCompartment = "vJrwpWtwJgWr",
                SecondCompartment = "hcsFMMfFFhFp"
            };

            char containedInBoth = ruckSackOrganizer.FindItemInBothCompartments(ruckSack);
            Assert.AreEqual('p', containedInBoth);
        }

        [Test]
        public void GetValueOfTheItemContainedInBothCompartments() {
            RuckSack ruckSack = new RuckSack() {
                FirstCompartment = "vJrwpWtwJgWr",
                SecondCompartment = "hcsFMMfFFhFp"
            };

            char containedInBoth = ruckSackOrganizer.FindItemInBothCompartments(ruckSack);
            int containedVal = ruckSackOrganizer.GetValueOfItem(containedInBoth);
            Assert.AreEqual(16, containedVal);
        }

        [Test]
        public void GetSumOfDuplicatesInBothCompartmentsOfAllRuckSacks() {
            string ruckSacks = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";

            ruckSackOrganizer.LoadRuckSack(ruckSacks);
            Assert.AreEqual(6, ruckSackOrganizer.RuckSacks.Count);

            Assert.AreEqual(157, ruckSackOrganizer.GetSumOfDuplicatesInRuckSacks());
        }

        [Test]
        public void GetSumOfDuplicatesInBothCompartmentsOfAllRuckSacksABC() {
            string ruckSacks = "aa\r\nbb\r\ncc\r\nAA\r\nBB\r\nCC";

            ruckSackOrganizer.LoadRuckSack(ruckSacks);
            Assert.AreEqual(6, ruckSackOrganizer.RuckSacks.Count);

            Assert.AreEqual(90, ruckSackOrganizer.GetSumOfDuplicatesInRuckSacks());
        }

        [Test]
        public void FindCommonItemInThreeSeperateRuckSacks() {
            RuckSack rucksack1 = new RuckSack() {
                FirstCompartment = "abc",
                SecondCompartment = "def"
            };
            RuckSack rucksack2 = new RuckSack() {
                FirstCompartment = "blr",
                SecondCompartment = "iow"
            };
            RuckSack rucksack3 = new RuckSack() {
                FirstCompartment = "zz",
                SecondCompartment = "xb"
            };

            Assert.AreEqual('b', ruckSackOrganizer.FindCommonItemInThreeSeperateRuckSacks(rucksack1,rucksack2,rucksack3));
        }

        [Test]
        public void GetSumOfItemInThreeRuckSacks() {
            string rucksacks = "abcdef\r\nblriow\r\nzzxb";
            ruckSackOrganizer.LoadRuckSack(rucksacks);

            Assert.AreEqual(2, ruckSackOrganizer.GetSumOfItemInThreeRucksacks());
        }
    }
}
