using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string _firstNumberValue = "0";
        private string _secondNumberValue = string.Empty;
        private string _symbolValue = string.Empty;
        private bool isFirstNull = true;
        private bool isSecondNull = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Calculate(string firstValue, string symbol, string secondValue)
        {
            double a = Convert.ToDouble(firstValue);
            double b = Convert.ToDouble(secondValue);
            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "x":
                    result = a * b;
                    break;
                case "÷":
                    if (b == 0)
                    {
                        Error();
                    }
                    result = a / b;
                    break;
            }
            _firstNumberValue = result.ToString();
            textBox.Text = _firstNumberValue;
        }
        private void ButtonNumeric_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                if (isFirstNull)
                {
                    textBox.Text += button.Text;                    
                    _firstNumberValue = textBox.Text;
                }
                else
                {
                    textBox.Text += button.Text;
                    _secondNumberValue = textBox.Text;
                }
            }
        }
        private void ButtonSymbol_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                _symbolValue = button.Text;
                textBoxSymbol.Text = _symbolValue;
                if (!isFirstNull)
                {
                    textBox.Text = string.Empty;
                    isSecondNull = isSecondNull ? false : true;
                    Calculate(_firstNumberValue, _symbolValue, _secondNumberValue);
                    textBoxSecondNumber.Text = _secondNumberValue;
                    isFirstNull = isFirstNull ? false : true;
                }
                else
                {
                    textBox.Text = string.Empty;
                    isFirstNull = isFirstNull ? false : true;
                    textBoxFirstNumber.Text = _firstNumberValue;
                }
            }
        }
        private void Error()
        {
            throw new NotImplementedException();
        }
    }
}
