using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day3 {
    public class RuckSackOrganizer {
        
        public List<RuckSack> RuckSacks { get; internal set; }

        public RuckSackOrganizer() { 
            RuckSacks = new List<RuckSack>();
        }

        public void LoadRuckSack(string ruckSack) {
            string[] ruckSackArr = ruckSack.Split("\r\n");

            foreach(string str in ruckSackArr) {
                if (str != "") {
                    var first = str.Substring(0, (int)(str.Length / 2));
                    var last = str.Substring((int)(str.Length / 2), (int)(str.Length / 2));

                    RuckSacks.Add(new RuckSack() {
                        FirstCompartment = first,
                        SecondCompartment = last,
                    });
                }
            }
        }

        public char FindItemInBothCompartments(RuckSack ruckSack) {
            char[] ruckSackArrFirst = ruckSack.FirstCompartment.ToCharArray();
            char[] ruckSackArrSecond = ruckSack.SecondCompartment.ToCharArray();

            for(int i = 0; i < ruckSackArrFirst.Length; i++) {
                for(int j = 0; j < ruckSackArrSecond.Length; j++) {
                    if (ruckSackArrFirst[i] == ruckSackArrSecond[j]) return ruckSackArrFirst[i];
                }
            }

            return '\0';
        }

        

        public int GetValueOfItem(char containedInBoth) {
            int val = int.Parse(Encoding.ASCII.GetBytes(containedInBoth.ToString()).GetValue(0).ToString());
            return val - (char.IsUpper(containedInBoth) ? 38 : 96);
        }

        public int GetSumOfDuplicatesInRuckSacks() {
            int val = 0;
            foreach(RuckSack rucksack in RuckSacks) {
                val += GetValueOfItem(FindItemInBothCompartments(rucksack));
            }

            return val;
        }


        public char FindCommonItemInThreeSeperateRuckSacks(RuckSack rucksack1, RuckSack rucksack2, RuckSack rucksack3) {
            string rucksack1contents = rucksack1.FirstCompartment + rucksack1.SecondCompartment;
            string rucksack2contents = rucksack2.FirstCompartment + rucksack2.SecondCompartment;
            string rucksack3contents = rucksack3.FirstCompartment + rucksack3.SecondCompartment;
            char[] rucksack1chars = rucksack1contents.ToCharArray();
            char[] rucksack2chars = rucksack2contents.ToCharArray();
            char[] rucksack3chars = rucksack3contents.ToCharArray();

            for(int i = 0; i < rucksack1chars.Length; i++) {
                for(int j = 0; j < rucksack2chars.Length; j++) {
                    for (int k = 0; k < rucksack3chars.Length; k++) {
                        if (rucksack1chars[i] == rucksack2chars[j] && rucksack1chars[i] == rucksack3chars[k] && rucksack2chars[j] == rucksack3chars[k]) {
                            return rucksack3chars[k];
                        }
                    }
                }
            }
            return '\r';
        }

        public int GetSumOfItemInThreeRucksacks() {
            int val = 0;
            for(int i = 0; i < RuckSacks.Count; i += 3) {
                val += GetValueOfItem(FindCommonItemInThreeSeperateRuckSacks(RuckSacks[i], RuckSacks[i + 1], RuckSacks[i + 2]));
            }
            return val;
        }
    }
}
