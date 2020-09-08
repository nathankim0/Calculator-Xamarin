using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        Button currentButton;

        public MainPage()
        {
            InitializeComponent();

        }

        public void OnButtonClick(object sender, EventArgs e)
        {
            var pressed = (sender as Button).Text;

            if (this.label.Text == "0" || currentState < 0)
            {
                this.label.Text = "";
                if (currentState == -1)
                {
                    currentState = 1;
                }
                else if (currentState == -2)
                {
                    currentButton.BackgroundColor = Color.Silver;
                    currentState = 3;
                }
            }

            this.label.Text += pressed;

            double number;

            if (double.TryParse(this.label.Text, out number))
            {
                this.label.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        public void OnOperator(object sender, EventArgs e)
        {
            if (currentState == -2)
            {
               currentButton.BackgroundColor = Color.Silver;
            }
            currentButton = sender as Button;
            mathOperator = currentButton.Text;

            currentButton.BackgroundColor = Color.LightBlue;

            if (currentState == 3)
            {
                OnResult(this, null);
            }

            currentState = -2;


        }

        public void OnAc(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            currentButton.BackgroundColor = Color.Silver;
            this.label.Text = "0";

        }

        public void OnResult(object sender, EventArgs e)
        {
            if (currentState == 3)
            {
                double result = 0;

                switch (mathOperator)
                {
                    case "÷":
                        result = firstNumber / secondNumber;
                        break;
                    case "x":
                        result = firstNumber * secondNumber;
                        break;
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                }
                this.label.Text = result.ToString("N0");
                firstNumber = result;
                currentState = -1;
            }
        }

    }
}
