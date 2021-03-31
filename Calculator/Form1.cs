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
        private string _firstValue = string.Empty;
        private string _secondValue = string.Empty;
        private string _calcOperator = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private string Calculate()
        {
            double firstValue = Convert.ToDouble(_firstValue);
            double secondValue = Convert.ToDouble(_secondValue);
            double result = 0;

            switch (_calcOperator)
            {
                case "+":
                    result = firstValue + secondValue;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    break;
                case "x":
                    result = firstValue * secondValue;
                    break;
                case "÷":
                    if (secondValue == 0)
                    {
                        Error();
                        return "Ты чё, дурак?";
                    }
                    else
                    {
                        result = firstValue / secondValue;
                    }

                    break;
            }

            return result.ToString();
        }

        private void Error()
        {
            buttonClear_Click(null, null);
            PictureSwitcher(pictureBoxError.Name);
            textBox.Text = "Ты чё, дурак?";
        }

        private void ButtonNumeric_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                PictureSwitcher(pictureBoxWaiting.Name);

                Button button = (Button)sender;
                if (_calcOperator == string.Empty)
                {
                    textBox.Text += button.Text;
                }
                else
                {
                    if (textBox.Text.Contains(_calcOperator))
                    {
                        textBox.Text = string.Empty;
                    }
                    textBox.Text += button.Text;
                }
            }
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                if (!(_firstValue is null))
                {
                    _firstValue = textBox.Text;
                    _calcOperator = button.Text;
                    textBox.Text = button.Text;
                }
                else
                {
                    _calcOperator = button.Text;
                    _secondValue = textBox.Text;
                    string result = Calculate();
                    textBox.Text = result;
                    _secondValue = string.Empty;
                    _firstValue = result;
                }
            }
        }

        private void buttonEqually_Click(object sender, EventArgs e)
        {
            _secondValue = textBox.Text;
            string result = Calculate();

            if (!result.Equals("Ты чё, дурак?"))
            {
                textBox.Text = result;
                _secondValue = string.Empty;
                _firstValue = result;
                PictureSwitcher(pictureBoxResult.Name);
            }
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if ((textBox.Text != string.Empty) && (!textBox.Text.Contains(".")))
            {
                textBox.Text += buttonPoint.Text;
            }
            else
            {
                Error();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _calcOperator = string.Empty;
            PictureSwitcher("Reset");
        }

        private void PictureSwitcher(string pictureName)
        {
            switch (pictureName)
            {
                case "pictureBoxWaiting":
                    pictureBoxWaiting.Visible = true;
                    pictureBoxResult.Visible = false;
                    pictureBoxError.Visible = false;
                    break;

                case "pictureBoxResult":
                    pictureBoxWaiting.Visible = false;
                    pictureBoxResult.Visible = true;
                    pictureBoxError.Visible = false;
                    break;

                case "pictureBoxError":
                    pictureBoxWaiting.Visible = false;
                    pictureBoxResult.Visible = false;
                    pictureBoxError.Visible = true;
                    break;

                case "Reset":
                    pictureBoxWaiting.Visible = false;
                    pictureBoxResult.Visible = false;
                    pictureBoxError.Visible = false;
                    break;
            }
        }
    }
}
