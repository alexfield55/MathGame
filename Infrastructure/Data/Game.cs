using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Game
    {

        /// <summary>
        /// establish way of passing selected radio button type
        /// 1 = addition
        /// 2 = subraction
        /// 3 = multiplication
        /// 4 = division
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// to get random numbers
        /// </summary>
        private Random rand = new Random();
        /// <summary>
        /// to store first random number
        /// </summary>
        public int rand1 { get; set; }
        /// <summary>
        /// to store second random number
        /// </summary>
        public int rand2 { get; set; }
        /// <summary>
        /// holds answers
        /// </summary>
        public int answer { get; set; }
        /// <summary>
        /// holds operators
        /// </summary>
        public String symbol { get; set; }

        /// <summary>
        /// determines which type of questions to call
        /// </summary>
        public void gameQuestions()
        {
            rand1 = rand.Next(1, 10);
            rand2 = rand.Next(1, 10);

            if (this.type == 1)
                addition();
            if (this.type == 2)
                subtraction();
            if (this.type == 3)
                multiplication();
            if (this.type == 4)
                division();
        }
        /// <summary>
        /// addition game logic
        /// </summary>
        private void addition()
        {
            this.symbol = "+";
            this.answer = rand1 + rand2;
        }
        /// <summary>
        /// subtraction game logic
        /// </summary>
        private void subtraction()
        {
            if (this.rand1 < this.rand2)
            {
                int temp = rand1;
                this.rand1 = rand2;
                this.rand2 = temp;
            }

            this.symbol = "-";
            this.answer = this.rand1 - this.rand2;
        }
        /// <summary>
        /// multiplication game logic
        /// </summary>
        private void multiplication()
        {
            this.symbol = "x";
            this.answer = rand1 * rand2;
        }
        /// <summary>
        /// division game logic
        /// </summary>
        private void division()
        {
            if (rand1 < rand2)
            {
                int temp = rand1;
                rand1 = rand2;
                rand2 = temp;
            }

            int remainder;
            remainder = rand1 % rand2;
            while (!(remainder == 0))
            {
                if (rand1 < rand2)
                {
                    int temp = rand1;
                    rand1 = rand2;
                    rand2 = temp;
                }
                rand1 = rand.Next(1, 10);
                rand2 = rand.Next(1, 5);
                remainder = rand1 % rand2;
            }

            this.symbol = "/";
            this.answer = rand1 / rand2;
        }
        /// <summary>
        /// random number 1 getter
        /// </summary>
        /// <returns></returns>
        public int getRand1()
        {
            if (rand1 < rand2)
            {
                int temp = rand1;
                rand1 = rand2;
                rand2 = temp;
            }
            return rand1;
        }
        /// <summary>
        /// random number 2 geter
        /// </summary>
        /// <returns></returns>
        public int getRand2()
        { return rand2; }
        /// <summary>
        /// anwser getter
        /// </summary>
        /// <returns></returns>
        public int getAnswer()
        { return answer; }
        /// <summary>
        /// grab operator string for game
        /// </summary>
        /// <returns></returns>
        public String getOperator()
        { return symbol; }
        /// <summary>
        /// get name of game for labels
        /// </summary>
        /// <returns></returns>
        public String gametypetoString()
        {
            if (this.type == 1)
                return "Addition";
            if (this.type == 2)
                return "Subraction";
            if (this.type == 3)
                return "Multiplication";
            if (this.type == 4)
                return "Division";

            return "no type set";
        }
    }
}
