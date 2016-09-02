using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Boolean shift = false;

        private Calculator calculator = new Calculator();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles button actions
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string clickedButton = ((Button)sender).Name;
            
            // Handle clicked button value
            switch (clickedButton)
            {

                case "number0":
                    calculator.updateOperand("0");
                    displayBox.Text = calculator.operand;
                    break;

                case "number1":
                    calculator.updateOperand("1");
                    displayBox.Text = calculator.operand;
                    break;

                case "number2":
                    calculator.updateOperand("2");
                    displayBox.Text = calculator.operand;
                    break;

                case "number3":
                    calculator.updateOperand("3");
                    displayBox.Text = calculator.operand;
                    break;

                case "number4":
                    calculator.updateOperand("4");
                    displayBox.Text = calculator.operand;
                    break;

                case "number5":
                    calculator.updateOperand("5");
                    displayBox.Text = calculator.operand;
                    break;

                case "number6":
                    calculator.updateOperand("6");
                    displayBox.Text = calculator.operand;
                    break;

                case "number7":
                    calculator.updateOperand("7");
                    displayBox.Text = calculator.operand;
                    break;

                case "number8":
                    calculator.updateOperand("8");
                    displayBox.Text = calculator.operand;
                    break;

                case "number9":
                    calculator.updateOperand("9");
                    displayBox.Text = calculator.operand;
                    break;

                case "buttonAddition":
                    displayBox.Text = calculator.queueOperation(Operation.Add);
                    displayBox.Text += "+";
                    break;

                case "buttonSubtraction":
                    displayBox.Text = calculator.queueOperation(Operation.Subtract);
                    displayBox.Text += "-";
                    break;

                case "buttonMultiplication":
                    displayBox.Text = calculator.queueOperation(Operation.Multiply);
                    displayBox.Text += "*";
                    break;

                case "buttonDivision":
                    displayBox.Text = calculator.queueOperation(Operation.Divide);
                    displayBox.Text += "/";
                    break;

                case "buttonEquals":
                    calculator.queueOperand();
                    calculator.evaluate();

                    // Change display box to show result of operation
                    displayBox.Text = calculator.getNextOperand();
                    break;

                case "buttonClear":
                    calculator.clear();
                    displayBox.Text = calculator.operand = "0";
                    calculator.append = false;
                    break;
            }
        }

        /// <summary>
        /// Handles keyboard clicks
        /// </summary>
        private void key_press(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.D0:
                    calculator.updateOperand("0");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D1:
                    calculator.updateOperand("1");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D2:
                    calculator.updateOperand("2");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D3:
                    calculator.updateOperand("3");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D4:
                    calculator.updateOperand("4");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D5:
                    calculator.updateOperand("5");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D6:
                    calculator.updateOperand("6");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D7:
                    calculator.updateOperand("7");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.D8:
                    if (this.shift)
                    {
                        displayBox.Text = calculator.queueOperation(Operation.Multiply);
                        displayBox.Text += "*";
                        this.shift = false;
                    }
                    else
                    {
                        calculator.updateOperand("8");
                        displayBox.Text = calculator.operand;
                    }
                   
                    break;

                case Key.D9:
                    calculator.updateOperand("9");
                    displayBox.Text = calculator.operand;
                    break;

                case Key.OemPlus:
                    if (this.shift)
                    {
                        displayBox.Text = calculator.queueOperation(Operation.Add);                        
                        displayBox.Text = calculator.getNextOperand();
                        displayBox.Text += "+";
                        this.shift = false;
                    }
                    else
                    {
                        calculator.queueOperand();
                        calculator.evaluate();

                        // Change display box to show result of operation
                        displayBox.Text = calculator.getNextOperand();
                    }
                    break;

                case Key.OemMinus:
                    displayBox.Text = calculator.queueOperation(Operation.Subtract);
                    displayBox.Text += "-";
                    break;

                case Key.Oem2:
                    displayBox.Text = calculator.queueOperation(Operation.Divide);
                    displayBox.Text += "/";
                    break;

                case Key.LeftShift:
                    this.shift = true;
                    break;

                case Key.RightShift:
                    this.shift = true;
                    break;

                case Key.Enter:
                    //this.queue.Enqueue(calculator.operand);
                    calculator.queueOperand();
                    calculator.evaluate();

                    // Change display box to show result of operation
                    displayBox.Text = calculator.getNextOperand();
                    break;
                }
        }
    }
}
