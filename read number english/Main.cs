using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace read_number_english
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        string[] ones = new string[20] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = new string[9] { "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] array = new string[4] { "hundred", "thousand", "million", "billion" };
        long hundreds = 0;
        long thousands = 0;
        long ten = 0;
        long remainder10 = 0;
        long remainder100 = 0;
        long remainder1000 = 0;
        long remainder1000000 = 0;
        long remainder1000000000 = 0;
        long number = 0;
        long billions = 0;
        long millions = 0;
        string read = "";
        string readNumber(long number, int length)
        {
            if (number == 0)
            {
                return "";

            }
            if (number < 20)
            {
                read = ones[number];
                return read;
            }
            if (length == 2)
            {
                ten = number / 10;
                remainder10 = number % 10;
                if (remainder10 == 0)
                {
                    read = tens[ten - 1];
                    return read;
                }
                else
                {
                    read = tens[ten - 1] + " " + ones[remainder10];
                    return read;
                }

            }
            if (length == 3)
            {
                hundreds = number / 100;
                remainder100 = number % 100;
                read = ones[hundreds] + " " + array[0] + " " + readNumber(remainder100, remainder100.ToString().Length);
                return read;
            }

            if (length > 3 && length < 7)
            {
                thousands = number / 1000;
                remainder1000 = number % 1000;
                read = readNumber(thousands, thousands.ToString().Length) + " " + array[1] + " " + readNumber(remainder1000, remainder1000.ToString().Length);
                return read;

            }

            if (length > 6 && length < 10)
            {
                millions = number / 1000000;
                remainder1000000 = number % 1000000;
                read = readNumber(millions, millions.ToString().Length) + " " + array[2] + " " + readNumber(remainder1000000, remainder1000000.ToString().Length);
                return read;

            }

            if (length > 9 && length < 13)
            {
                billions = number / 1000000000;
                remainder1000000000 = number % 1000000000;
                read = readNumber(billions, billions.ToString().Length) + " " + array[3] + " " + readNumber(remainder1000000000, remainder1000000000.ToString().Length);
                return read;
            }
            return read;
        }


        private void readNum_Click(object sender, EventArgs e)
        {
            number = Convert.ToInt64(textBox1.Text);
            if (number == 0)
            {
                MessageBox.Show("zero");
                return;
            }
            MessageBox.Show(readNumber(number, number.ToString().Length));
        }
    }
}
