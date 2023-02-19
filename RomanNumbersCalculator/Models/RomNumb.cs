using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalc.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort number;
        private static int[] value = new int[] {     1000, 900, 500, 400,  100,  90,  50,   40,   10,   9,   5,   4,    1 };
        private static string[] roman = new string[]{ "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public RomanNumber(ushort n)
        {
            if (n <= 0) 
                throw new RomanNumberException("#ERROR");
            else this.number = n;
        }
        public static RomanNumber operator +(RomanNumber? first, RomanNumber? second)
        {
            int num = first.number + second.number;
            if (num <= 0) 
                throw new RomanNumberException("#ERROR");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }
        public static RomanNumber operator -(RomanNumber? first, RomanNumber? second)
        {
            int num = first.number - second.number;
            if (num <= 0) 
                throw new RomanNumberException("#ERROR");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }
        public static RomanNumber operator *(RomanNumber? first, RomanNumber? second)
        {
            int num = first.number * second.number;
            if (num <= 0) 
                throw new RomanNumberException("#ERROR");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }
        public static RomanNumber operator /(RomanNumber? first, RomanNumber? second)
        {

            if (second.number == 0) 
                throw new RomanNumberException("#ERROR");
            else
            {
                int num = first.number / second.number;
                if (num == 0) 
                    throw new RomanNumberException("#ERROR");
                else
                {
                    return new RomanNumber((ushort)num);
                }
            }
        }
        public override string ToString()
        {
            int tmp = number;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (tmp >= value[i])
                {
                    tmp -= (ushort)value[i];
                    result.Append(roman[i]);
                }
            }
            if (result.ToString() == "") 
                throw new RomanNumberException("#ERROR");
            else
                return result.ToString();

        }
        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object obj)
        {
            if (obj is RomanNumber roman)
                return number.CompareTo(roman.number);
            else
                throw new RomanNumberException("#ERROR");
        }

    }

}
