using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars < 30) { return false; }
            else if ((cigars >= 40 && cigars <= 60) && (isWeekend == false)) { return true; }
            else if (cigars > 60 && isWeekend == true) { return true; }
            else { return false; }

        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle < 3 || dateStyle < 3) { return 0; }
            else if ((yourStyle > 3 && yourStyle < 8) && (dateStyle > 3 && dateStyle < 8)) { return 1; }
            else if (yourStyle >= 8 || dateStyle >= 8) { return 2; }
            else { return 0; }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {

            if (isSummer == false)
            {
                if (temp < 60 || temp > 90) { return false; }
                else { return true; }
            }
            else if (isSummer == true)
            {
                if (temp < 60 || temp > 100) { return false; }
                else { return true; }
            }
            else
            {
                return true;
            }
        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday == true)
            {
                if (speed <= 65)
                {
                    return 0;
                }
                else if (speed >= 66 && speed <= 85)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            else if (isBirthday == false)
            {
                if (speed <= 60)
                {
                    return 0;
                }
                else if (speed >= 61 && speed <= 80)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else { return 2; }
        }

        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum <= 19)
            {
                return 20;
            }
            else
            {
                return sum;
            }
        }

        public string AlarmClock(int day, bool vacation)
        {
            if (vacation == false)
            {
                if (day > 0 && day < 6)
                {
                    return "7:00";
                }
                else
                {
                    return "10:00";
                }
            }
            else if (vacation == true)
            {
                if (day > 0 && day < 6)
                { return "10:00"; }
                else
                { return "Off"; }
            }
            else
            { return "Off"; }
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            else if (a + b == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode == true)
            {
                if (n <= 1 || n >= 10)
                { return true; }
                else
                { return false; }
            }
            else if (outsideMode == false)
            {
                if (n >= 1 && n <= 10)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }

        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || n % 11 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            else if (n % 5 == 0)
            {
                return true;
            }
            else if (n % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
            {
                return false;
            }
            else if (isMorning == true && isMom == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || a + c == b || b + c == a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk == true && c > b)
            {
                return true;
            }
            else if (b > a && c > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk == true && b >= a && c >= b)
            {
                return true;
            }
            else if (b > a && c > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LastDigit(int a, int b, int c)
        {
            string aparse = a.ToString();
            string bparse = b.ToString();
            string cparse = c.ToString();
            string ap = aparse.Substring(aparse.Length - 1);
            string bp = bparse.Substring(bparse.Length - 1);
            string cp = cparse.Substring(cparse.Length - 1);
            if (ap == bp || bp == cp || ap == cp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;
            if (noDoubles == true && die1 == die2)
            {
                return sum + 1;
            }
            else
            {
                return sum;
            }
        }

    }
}
