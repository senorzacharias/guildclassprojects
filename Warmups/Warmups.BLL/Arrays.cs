﻿using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length > 1 && numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            return false;
        }
        public int[] MakePi(int n)
        {

            double pie = Math.PI;
            string numberPie = pie.ToString().Remove(1, 1);
            int[] newArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int.TryParse(numberPie.Substring(i, 1), out newArray[i]);
            }
            return newArray;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
                {
                    return true;
                }

            }
            return false;
        }

        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    newArray[numbers.Length - 1] = numbers[i];
                }
                else
                {
                    newArray[i - 1] = numbers[i];
                }

            }
            return newArray;

        }

        public int[] Reverse(int[] numbers)
        {
            int[] newArray = new int[numbers.Length];
            int last = numbers.Length - 1;
            int counter = 0;
            for (int i = last; i >= 0; i--)
            {
                newArray[counter] = numbers[i];
                counter++;
            }
            return newArray;
        }

        public int[] HigherWins(int[] numbers)
        {
            int higherNumber = 0;
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] > numbers[numbers.Length - 1])
                {
                    higherNumber = numbers[0];

                }
                if (numbers[numbers.Length - 1] > numbers[0])
                {
                    higherNumber = numbers[numbers.Length - 1];

                }
                newArray[i] = higherNumber;
            }
            return newArray;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] newArray = new int[2];

            newArray[0] = a[1];
            newArray[1] = b[1];
            return newArray;
        }

        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int[] KeepLast(int[] numbers)
        {
            int[] newArray = new int[numbers.Length * 2];
            int last = numbers[numbers.Length - 1];
            
                    newArray[newArray.Length -1] = last;
               
            return newArray;
        }
        //NEED TO PASS ONE
        public bool Double23(int[] numbers)
        {
            int twoCounter = 0;
            int threeCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    twoCounter++;
                }
                if (numbers[i] == 3)
                {
                    threeCounter++;
                }
                if (twoCounter == 2 || threeCounter == 2)//Fix--if more than 2 it doesn't return false
                {
                    return true;
                }
            }
            return false;
        }
        //NOT COMPLETE
        public int[] Fix23(int[] numbers)
        {
            int addzero = 0;
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 2)
                {
                    addzero = numbers[i];
                }

                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    newArray[addzero] = numbers[i + 1];
                }
            }
            return newArray;
        }

        public bool Unlucky1(int[] numbers)
        {

            throw new NotImplementedException();
        }

        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}
