using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Interview.Strings
{
    /// <summary>
    ///  Parse a string containing numbers and "+", "-" and   parentheses. Evaluate the expression. -2+(3-5) should return -4. 
    /// </summary>
    public class ParsePlusMinus
    {
        [Test]
        public void Simple()
        {
            Assert.That(Calculate("2-(3+5)"), Is.EqualTo(-6));
        }

        [Test]
        public void SimpleNoPar()
        {
            Assert.That(Calculate("2-3+5"), Is.EqualTo(4));
        }

        [Test]
        public void NestedParenthis()
        {
            Assert.That(Calculate("2-(3+5-(8+5-3))"), Is.EqualTo(4));
        }

        [Test]
        public void OneNumber()
        {
            Assert.That(Calculate("(7)-(0)+(4)"), Is.EqualTo(11));
        }

        private int Calculate(string s)
        {
            var res = 0;
            var sign = '+';
            var num = "";
            var isPar = false;
            var par = "";
            var parenthisNum = 0;
            
            foreach (var ch in s)
            {
                if (ch == ')')
                {
                    parenthisNum--;
                    if (parenthisNum == 0)
                    {
                        isPar = false;
                        res = Compute(sign, res, Calculate(par));
                        par = "";
                    }
                    else
                    {
                        par += ch;
                    }
                    continue;
                }

                if (isPar)
                {
                    if (ch == '(')
                    {
                        parenthisNum++;
                    }
                    par += ch;
                    continue;
                }

                if (ch == '-' || ch == '+')
                {
                    res = Compute(sign, res, Parse(num));
                    sign = ch;
                    num = "";
                }
                else if (ch == '(')
                {
                    parenthisNum++;
                    isPar = true;
                }
                else if (ch == ' ')
                {
                }
                else
                {
                    num += ch;
                }

            }

            res = Compute(sign, res, Parse(num));

            return res;

        }

        private int Parse(string s)
        {
            var res = 0;
            int.TryParse(s, out res);
            return res;
        }

        private int Compute(char sign, int num1, int num2)
        {
            if (sign == '+')
            {
                return num1 + num2;
            }
            else
            {
                return num1 - num2;
            }
        }

    }
}