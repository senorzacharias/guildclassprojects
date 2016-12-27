using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == true && bSmile == true)
            {
                return true;
            }
            else if (aSmile == false && bSmile == false)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SumDouble(int a, int b)
        {
            if (a != b)
            {
                return a + b;
            }
            else
            {
                return a * 4;
            }
        }

        public int Diff21(int n)
        {
            int overDifference = (n - 21) * 2;
            if (n <= 21)
            {
                return 21 - n;
            }
            else
            {
                return overDifference;
            }
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == false)
            {
                return false;
            }
            else if (hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Makes10(int a, int b)
        {
            if (a + b == 10 || a == 10 || b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NearHundred(int n)
        {
            int withinOneHundred = 100 - n;
            int withinTwoHundred = 200 - n;

            if (Math.Abs(withinOneHundred) <= 10 || Math.Abs(withinTwoHundred) <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PosNeg(int a, int b, bool negative)
        {

            if (a == -1 || b == -1)
            {
                return true;
            }
            else if (a < 0 && b < 0 && negative == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return "not " + s;
            }
            else if (s.Substring(0, 3) != "not")
            {
                return "not " + s;
            }
            else
            {
                return s;
            }
        }

        public string MissingChar(string str, int n)
        {
            if (str.Length > 0)
            {
                string rem = str.Remove(n, 1);
                return rem;
            }
            else
            {
                return str;
            }

        }

        public string FrontBack(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            else if (str.Length == 2)
            {
                string front = str.Substring(0, 1);
                string back = str.Substring(str.Length - 1, 1);
                return back + front;
            }
            else
            {
                string front = str.Substring(0, 1);
                string back = str.Substring(str.Length - 1, 1);
                string middle = str.Substring(1, str.Length - 2);
                string swap = string.Concat(back, middle, front);
                return swap;
            }
        }

        public string Front3(string str)
        {
            if (str.Length < 3)
            {
                return string.Concat(str, str, str);
            }
            else
            {
                string front = str.Substring(0, 3);
                return string.Concat(front, front, front);
            }
        }

        public string BackAround(string str)
        {
            if (str.Length == 1)
            {
                string superhappyfuntime = string.Concat(str, str, str);
                return superhappyfuntime;
            }
            else
            {
                string front = str.Substring(str.Length - 1, 1);
                string full = string.Concat(front, str, front);
                return full;
            }
        }

        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartHi(string str)
        {

            if (str.Length < 2)
            {
                return false;
            }

            else if (str.Length < 3 && str.Substring(0, 2) == "hi")
            {
                return true;
            }
            else if (str.Length > 1 && str.Substring(0, 2) == "hi" && str.Substring(2, 1) == "," || str.Substring(2, 1) == " ")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else if (temp1 > 100 && temp2 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20)
            {
                return true;
            }
            else if (b >= 10 && b <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 && a <= 19)
            {
                return true;
            }
            else if (b >= 13 && b <= 19)
            {
                return true;
            }
            else if (c >= 13 && c <= 19)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SoAlone(int a, int b)
        {
            if ((a >= 13 && a <= 19) && (b >= 13 && b <= 19))
            {
                return false;
            }
            else if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public string RemoveDel(string str)
        {
            if (str.Substring(1, 3) == "del")
            {
                string delete = str.Remove(1, 3);
                return delete;
            }
            else
            {
                return str;
            }
        }

        public bool IxStart(string str)
        {
            if (str.Substring(1, 2) == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string StartOz(string str)
        {
            if (str.Length <= 1)
            {
                return "";
            }
            else if (str.Substring(0, 2) == "oz")
            {

                return "oz";
            }
            else if (str.Substring(0, 1) == "o" && str.Substring(1, 1) != "z")
            {
                return "o";
            }
            else if (str.Substring(1, 1) == "z" && str.Substring(0, 1) != "o")
            {
                return "z";
            }
            else
            {
                return "";
            }
        }

        public int Max(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return a;
            }
            else if (b > a && b > c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        public int Closer(int a, int b)
        {
            int absA = Math.Abs(a - 10);
            int absB = Math.Abs(b - 10);
            if (absA > absB)
            {
                return b;
            }
            else if (absA < absB)
            {
                return a;
            }
            else
            {
                return 0;
            }
        }

        public bool GotE(string str)
        {
            int eee = str.Split('e').Length - 1;
            return (eee <= 3) && str.Contains("e");
        }


        public string EndUp(string str)
        {
            if (str.Length < 3)
            {
                string upper = str.ToUpper();
                return upper;
            }
            else
            {
                string lastThree = str.Substring(str.Length - 3);
                string upperThree = lastThree.ToUpper();
                string first = str.Substring(0, str.Length - 3);
                return first + upperThree;
            }

        }

        public string EveryNth(string str, int n)
        {
            int counter = 0;
            string results = "";
            while (counter < str.Length)
            {
                results = results + str.Substring(counter, 1);
                counter += n;
            }
            return results;
        }
    }
}
