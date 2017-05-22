using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Numbers
{
    public class Diamond
    {

        [Test]
        public void One()
        {
            var str = "*";
            Assert.That(Calc(1),Is.EqualTo(str));
        }

        [Test]
        public void Three()
        {
            var sb = new StringBuilder();
            sb.Append("  *  " + Environment.NewLine);
            sb.Append(" *** " + Environment.NewLine);
            sb.Append("*****" + Environment.NewLine);
            sb.Append(" *** " + Environment.NewLine);
            sb.Append("  *  ");

            Assert.That(Calc(5), Is.EqualTo(sb.ToString()));
        }

        private string Calc(int num, int curr=1)
        {
            var spaces =( num - curr) / 2;
            var str = string.Empty;
            for (var i = 0; i <= num; i++)
            {
                if (i < spaces)
                {
                    str += " ";
                }else if (i < spaces + curr)
                {
                    str += "*";
                }
                else
                {
                    str += " ";
                }
            }
            if (curr == 1)
            {
                return str;
            }
            else if (curr < num)
            {
                return str + Environment.NewLine + Calc(num, curr + 2);
            }
            else { 
                return str + Environment.NewLine + Calc(num, curr - 2);
            }
            
        }
    }
}
