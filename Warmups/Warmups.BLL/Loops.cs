using System;


namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string sTimes = "";
            for (int i = 0; i < n; i++)
            {
                sTimes = sTimes + str;

            }
            return sTimes;
        }


        public string FrontTimes(string str, int n)
        {
            string threeFronts = "";
            string frontThree = str.Substring(0, 3);
            for (int i = 0; i < n; i++)
            {
                threeFronts += frontThree;
            }
            return threeFronts;
        }

        public int CountXX(string str)
        {
            int exCount = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 2) == "xx")
                {
                    exCount++;
                }
            }
            return exCount;
        }

        public bool DoubleX(string str)
        {


            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == "x" && str.Substring(i, 2) != "xx")
                {
                    return false;
                }
                if (str.Substring(i, 1) == "x" && str.Substring(i, 2) == "xx")
                {
                    return true;
                }


            }
            return false;
        }

        public string EveryOther(string str)
        {
            string everyOther = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    everyOther += str[i];
                }

            }
            return everyOther;
        }

        public string StringSplosion(string str)
        {
            string results = "";
            for (int i = 0; i < str.Length; i++)
            {
                results += str.Substring(0, i + 1);
            }
            return results;
        }

        public int CountLast2(string str)
        {
            int count = 0;
            string numberCompare = "";
            string lastTwo = str.Substring(str.Length - 2);
            for (int i = 0; i < str.Length - 2; i++)
            {
                numberCompare = str.Substring(i, 2);
                if (numberCompare == lastTwo)
                {
                    count++;
                }
            }
            return count++;
        }

        public int Count9(int[] numbers)
        {
            int nine = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    nine++;
                }
            }
            return nine;
        }



        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        //need counter for 2 length recurrences
        //for to loop through words and find equal substrings
        public int SubStringMatch(string a, string b)
        {
            string matchA = "";
            string matchB = "";
            int counter = 0;
            for (int i = 0; i < b.Length - 1; i++)
            {
                matchA = a.Substring(i, 2);
                matchB = b.Substring(i, 2);
                if (matchB == matchA)
                {
                    counter++;
                }
            }
            return counter;
        }

        public string StringX(string str)
        {
            string middle = "";
            string front = str.Substring(0, 1);
            string back = str.Substring(str.Length - 1);
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) != "x")
                {
                    middle += str[i];
                }
            }
            return front + middle + back;
        }
        //Add 0,1/ 4,5/ 8,9/ to string
        public string AltPairs(string str)
        {
            string searchCombined = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                string search1 = str.Substring(i, 1);
                if (i < str.Length - 1)
                {
                    string search2 = str.Substring(i + 1, 1);
                    searchCombined += search1 + search2;
                }
                else
                {
                    searchCombined += search1;
                }
            }
            return searchCombined;
        }

        public string DoNotYak(string str)
        {
            string search = "";

            for (int i = 0; i < str.Length - 3; i += 3)
            {
                if (str.Substring(i, 3) != "yak")
                {
                    search = str.Substring(i, str.Length - 3);
                }
                else
                {
                    search = str.Remove(i, 3);
                }
            }
            return search;
        }

        public int Array667(int[] numbers)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length - 1; i += 2)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    counter++;
                }
                if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    counter++;
                }
            }
            return counter;
        }

        public bool NoTriples(int[] numbers)
        {

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    return false;
                }
            }
            return true;
        }
        //2+5=7 7-6=1
        public bool Pattern51(int[] numbers)
        {

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                int first = numbers[i];
                int second = numbers[i + 1];
                int third = numbers[i + 2];
                if (second == first + 5 && third == (first-1))
                {
                    return true;
                }

            }
            return false;
        }

    }
}
