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
        public Boolean append { get; set; } = false;
        public string operand { get; set; } // Holds display value

        private Queue queue = new Queue();

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

                // Clear queue in order to append result of operation
                this.queue.Clear();

                // Compute operation and enqueue
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

        /// <summary>
        /// Returns the pending operand on the queue as a string
        /// </summary>
        public string getNextOperand()
        {   
            return (string)this.queue.Peek();
        }

        /// <summary>
        /// Queues an operand for evaluation
        /// </summary>
        public void queueOperand()
        {
            this.queue.Enqueue(this.operand);
        }

        /// <summary>
        /// Handles the queueing of operations and previous operands
        /// <typeparam name="operation">Mathematical operation to be evaluated</typeparam>
        /// </summary>
        public string queueOperation(Operation operation)
        {
            // If queue is empty, queue both the operand and operation
            if (queue.Count == 0)
            {
                this.queue.Enqueue(this.operand);
                this.queue.Enqueue(operation);
                this.operand = "";
            }

            // If queue contains an operand, queue only the operation
            else if (queue.Count == 1)
            {
                this.queue.Enqueue(operation);
            }

            // Queue has pending operand and operation; queue the remaining operand and evaluate
            else
            {
                this.queue.Enqueue(this.operand);
                evaluate();
                this.queue.Enqueue(operation); // Queue the result of the evaluation
            }

            this.append = false;

            return (string)queue.Peek();
        }

        /// <summary>
        /// Updates the display after a button is clicked. 
        /// If append is true, the user has not requested an operation yet and is still entering an operand
        /// If append is false, the user has requested an operation
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
