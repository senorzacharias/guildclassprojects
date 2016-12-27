using System;

namespace Warmups.BLL
{
    public class Strings
    {
        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {

            return container.Insert(2, word);
        }

        public string MultipleEndings(string str)
        {
            string multiples = str.Substring(str.Length - 2);
            return string.Concat(multiples, multiples, multiples);

        }

        public string FirstHalf(string str)
        {
            /* int measure = str.Length;
             int midpoint = measure / 2;
             string firsthalf = str.Remove(midpoint);
             return firsthalf;*/
            return str.Remove(str.Length / 2);

        }

        public string TrimOne(string str)
        {

            string Removed = str.Remove(str.Length - 1);
            string Trim = Removed.Substring(1);
            return Trim;
        }

        public string LongInMiddle(string a, string b)
        {

            if (b.Length <= 2)
            {
                return b + a + b;
            }
            else
            {
                return a + b + a;
            }

        }

        public string RotateLeft2(string str)
        {
            if (str.Length <= 2)
            {
                return str;
            }
            string End = str.Substring(2);
            string Start = str.Remove(2);
            return End + Start;
        }

        public string RotateRight2(string str)
        {
            if (str.Length > 2)
            {
                string RotateRight = str.Substring(str.Length - 2) + str.Substring(0, str.Length - 2);
                return RotateRight;
            }

            else
            {
                return str;
            }
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                string Take = str.Substring(0, 1);
                return Take;
            }
            else
            {
                string Give = str.Substring(str.Length - 1);
                return Give;
            }
        }

        public string MiddleTwo(string str)
        {
            int Middle = str.Length / 2;
            return str.Substring(Middle - 1, 2);

        }

        public bool EndsWithLy(string str)
        {
            if (str.EndsWith("ly"))
            {
                return true;

            }
            else
            {
                return false;
            }
            //bool isNegative = myOtherNumber <0 |?true :false;|
        }//hammer and nail**

        public string FrontAndBack(string str, int n)
        {
            string Front = str.Substring(0, n);
            string End = str.Substring(str.Length - n);
            return Front + End;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n == 2)
            {
                return str.Substring(2);
            }
            else
            {
                return str.Substring(0, 2);
            }
        }
        
        public bool HasBad(string str)
        {


            if (str.Length == 0)
            {
                return false;
            }
            else if (str.Substring(0, 3) == "bad" || str.Substring(1, 3) == "bad")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string AtFirst(string str)
        {


            if (str.Length == 1)
            {
                return string.Concat(str, "@");

            }
            else if (str.Length == 0)
            {
                return string.Concat(str, "@", "@");
            }
            else
            {
                string atFirst = str.Substring(0, 2);
                return atFirst;
            }
        }

        public string LastChars(string a, string b)
        {
            string first = "";
            string last = "";


            if (a.Length > 1 && b.Length == 0)
            {
                first = a.Substring(0, 1);
                return string.Concat(first, "@");
            }
            else if (a.Length == 0 && b.Length > 0)
            {
                return "@" + b;
            }
            else if (a.Length > 1 && b.Length >= 1)
            {
                first = a.Substring(0, 1);
                last = b.Substring(b.Length - 1);
                return first + last;
            }
            else
            {
                return string.Concat("@", "@");
            }
        }
        
        public string ConCat(string a, string b)
        {
            
            if (string.IsNullOrEmpty(a))
            {
                return b;
            }
            else if (string.IsNullOrEmpty(b))
            {
                return a;
            }
            
            else if ((a.Length == b.Length) && (a.Substring(a.Length-1, 1) != b.Substring(0, 1)))
            {
                
                return a + b;
            }
            else if (a.Length > b.Length)
            {
                string removeA = a.Substring(0, a.Length - 1);
                
                return removeA + b;
            }
            else
            {
                string removeB = b.Substring(1, b.Length - 1);
                return a + removeB;
            }

        }

        public string SwapLast(string str)
        {


            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                string end = str.Substring(str.Length - 1, 1);
                string rem = str.Remove(str.Length - 1);
                string add = rem.Insert(str.Length - 2, end);
                return add;
            }

        }

        public bool FrontAgain(string str)
        {
            string front = str.Substring(0, 2);
            string back = str.Substring(str.Length - 2, 2);
            if(str.Length < 3)
            {
                return true;
            }
            else if(front == back)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
        public string MinCat(string a, string b)
        {

            if (a.Length == b.Length)
            {
                return string.Concat(a, b);
            }
            else if (a.Length > b.Length)
            {
                return a.Substring(a.Length - b.Length, b.Length) + b;
            }
            else if (a.Length < b.Length)
            {
                return a + b.Substring(b.Length - a.Length, a.Length);
            }
            else
            {
                return "";
            }

        }

        public string TweakFront(string str)
        {

            if (str == "")
            {
                return "";
            }

            if (str.Substring(0, 2) == "ab")
            {
                return str;
            }

            else if (str.Substring(1, 1) == "b")
            {
                return str.Substring(1);
            }
            else if (str.Substring(0, 1) == "a")
            {
                return str.Remove(1, 1);
            }
            else
            {
                return str.Substring(2);
            }

        }

        public string StripX(string str)
        {
            if (str == "")
            {
                return str;
            }
            else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1) == "x")
            {
                if (str.Length == 1)
                {
                    return "";
                }
                return str.Substring(1, str.Length - 2);
            }
            else if (str.Substring(0, 1) == "x" && str != "")
            {
                return str.Substring(1);
            }
            else if (str.Substring(str.Length - 1) == "x" && str != "")
            {
                return str.Substring(0, str.Length - 1);
            }

            else
            {
                return str;
            }
        }
    }
} //trim[]
