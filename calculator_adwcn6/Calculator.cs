using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculite
{
    class Calculator
    {
        private Queue queue = new Queue();

        public Boolean append { get; set; } = false;
        public string operand { get; set; } // Holds display value

        /// <summary>
        /// Clears the operation queue.
        /// </summary>
        public void clear()
        {
            this.queue.Clear();
        }

        /// <summary>
        /// Evaluates the queued operation.
        /// </summary>
        public void evaluate()
        {
            try
            {
                double firstOperand = double.Parse((string)this.queue.Dequeue());
                Operation operation = (Operation)this.queue.Dequeue();
                double secondOperand = double.Parse((string)this.queue.Dequeue());

                // Clear queue for result of operation
                this.queue.Clear();

                switch (operation)
                {

                    case Operation.Add:
                        this.queue.Enqueue((firstOperand + secondOperand).ToString());
                        break;

                    case Operation.Subtract:
                        this.queue.Enqueue((firstOperand - secondOperand).ToString());
                        break;

                    case Operation.Multiply:
                        this.queue.Enqueue((firstOperand * secondOperand).ToString());
                        break;

                    case Operation.Divide:
                        this.queue.Enqueue((firstOperand / secondOperand).ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The requested operation is not valid. Please try again.");
            }
        }

        public string getNextOperation()
        {   
            return (string)this.queue.Peek();
        }

        /// <summary>
        /// Queues an operand for evaluation.
        /// </summary>
        public void queueOperand()
        {
            this.queue.Enqueue(this.operand);
        }

        /// <summary>
        /// Queues the first part of the requested operation if the queue is empty.
        /// If the queue is not empty, the second half of the requested operation 
        /// is queued and then evaluated.
        /// <typeparam name="operation">Mathematical operation to be evaluated</typeparam>
        /// </summary>
        public void queueOperation(Operation operation)
        {
            if (queue.Count == 0)
            {
                this.queue.Enqueue(this.operand);
                this.queue.Enqueue(operation);
                this.operand = "";
            }
            else if (queue.Count == 1)
            {
                this.queue.Enqueue(operation);
            }
            else
            {
                this.queue.Enqueue(this.operand);
                evaluate();
                this.queue.Enqueue(operation);
            }

            this.append = false;
        }

        /// <summary>
        /// Updates the display after a button is clicked.
        /// <typeparam name="value">Value to add to the display</typeparam>
        /// </summary>
        public void updateOperand(string value)
        {
            if (append)
            {
                this.operand += value;
            }
            else
            {
                this.append = true;
                this.operand = value;
            }
        }
    }
}
