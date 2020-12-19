using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        bool isZeroDivide;
        double firstNum;
        string givenOperation;

        bool hasFirstNum;
        bool hasSecondNum;
        bool hasOperation;

        public Form1()
        {
            InitializeComponent();
            isZeroDivide = false;
            givenOperation = "";
            hasFirstNum = false;
            hasSecondNum = false;
            hasOperation = false;
        }

        private void RemoveStartingZero()
        {
            if (calcScreen.Text.StartsWith("0"))
            {
                calcScreen.Text = "";
            }
        }

        private void CheckForSecondNum()
        {
            if (hasFirstNum && hasOperation)
            {
                hasSecondNum = true;
            }
        }

        private void nineBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "9";
        }

        private void eightBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "8";
        }

        private void sevenBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "7";
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "6";
        }

        private void fiveBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "5";
        }

        private void fourBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "4";
        }

        private void threeBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "3";
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "2";
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            calcScreen.Text = calcScreen.Text + "1";
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            RemoveStartingZero();
            CheckForSecondNum();
            if (givenOperation.Equals("/"))
            {
                isZeroDivide = true;
            }
            calcScreen.Text = calcScreen.Text + "0";
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            calcScreen.Clear();
            firstNum = 0;
            hasFirstNum = false;
            hasSecondNum = false;
            hasOperation = false;
            givenOperation = "";
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            if (hasSecondNum)
            {
                Solve();
            }

            try
            {
                firstNum = Convert.ToDouble(calcScreen.Text);
                hasFirstNum = true;
            }
            catch (Exception)
            {
                //don't do anything
            }
            givenOperation = "+";
            hasOperation = true;
            calcScreen.Text = calcScreen.Text + givenOperation;
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            if (hasSecondNum)
            {
                Solve();
            }

            try
            {
                firstNum = Convert.ToDouble(calcScreen.Text);
                hasFirstNum = true;
            }
            catch (Exception)
            {
                //don't do anything
            }
            givenOperation = "-";
            hasOperation = true;
            calcScreen.Text = calcScreen.Text + givenOperation;
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            if (hasSecondNum)
            {
                Solve();
            }

            try
            {
                firstNum = Convert.ToDouble(calcScreen.Text);
                hasFirstNum = true;
            }
            catch (Exception)
            {
                //don't do anything
            }
            givenOperation = "*";
            hasOperation = true;
            calcScreen.Text = calcScreen.Text + givenOperation;
        }

        private void divideBtn_Click(object sender, EventArgs e)
        {
            if (hasSecondNum)
            {
                Solve();
            }

            try
            {
                firstNum = Convert.ToDouble(calcScreen.Text);
                hasFirstNum = true;
            }
            catch (Exception)
            {
                //don't do anything
            }
            givenOperation = "/";
            hasOperation = true;
            calcScreen.Text = calcScreen.Text + givenOperation;
        }

        private void decimalBtn_Click(object sender, EventArgs e)
        {
            calcScreen.Text = calcScreen.Text + ".";
        }

        private void Solve()
        {
            try
            {
                if (isZeroDivide)
                {
                    MessageBox.Show("Error! Cannot divide by zero.");
                }
                else
                {
                    removeLeadingEndingOperands();
                    double answer;
                    int indexOfOperation = calcScreen.Text.IndexOf(givenOperation) + 1;
                    calcScreen.Text.Substring(indexOfOperation);
                    double secondNum = Convert.ToDouble(calcScreen.Text.Substring(indexOfOperation));

                    if (givenOperation.Equals("+"))
                    {
                        answer = firstNum + secondNum;
                    }
                    else if (givenOperation.Equals("-"))
                    {
                        answer = firstNum - secondNum;
                    }
                    else if (givenOperation.Equals("*"))
                    {
                        answer = firstNum * secondNum;
                    }
                    else if (givenOperation.Equals("/"))
                    {
                        answer = firstNum / secondNum;
                    }
                    else
                    {
                        answer = firstNum;
                    }
                    firstNum = answer;
                    givenOperation = "";
                    hasOperation = false;
                    hasSecondNum = false;
                    calcScreen.Text = answer.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error! The inputted formula is invalid.");
            }

        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            Solve();
        }


        private void removeLeadingEndingOperands()
        {
            if (calcScreen.TextLength > 1) //if the calculator has more than one character in the formula
            {
                while (calcScreen.Text.StartsWith("+") || calcScreen.Text.StartsWith("-")
                 || calcScreen.Text.StartsWith("*") || calcScreen.Text.StartsWith("/") && calcScreen.TextLength > 1)
                { //removes unused +/-/*// used at the beginning of the calculation
                    calcScreen.Text = calcScreen.Text.Substring(1);
                }

                while (calcScreen.Text.EndsWith("+") || calcScreen.Text.EndsWith("-")
                 || calcScreen.Text.EndsWith("*") || calcScreen.Text.EndsWith("/") && calcScreen.TextLength > 1)
                { //removes unused +/-/*// used at the end of the calculation
                    int length = calcScreen.TextLength;
                    calcScreen.Text = calcScreen.Text.Substring(0, length - 2);
                }
            }
            else //the given formula has 0 or 1 characters
            {
                if (double.TryParse(calcScreen.Text, out double result))
                {
                    calcScreen.Text = result.ToString();
                }
                calcScreen.Clear();
                //try parsing the num
                //if it can't be parsed, clear
                //return
            }
        }
    }
}
