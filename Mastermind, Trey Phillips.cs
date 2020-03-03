//(C)2020 Trey Phillips
using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play some Mastermind!");

            //randomly generate number array
            Random rnd = new Random();
            int[] number = new int[4];
            for (int i = 0; i < 4; i++)
                number[i] = rnd.Next(1, 6);

            //make answer string for comparisons
            string answer = null;
            foreach (int i in number)
                answer += i.ToString();
            Console.WriteLine(answer);

            int attempts = 0;  //initialize counter
            bool success = false;   //flag for won game
            do
            {
                attempts++;
                //strings for feedback
                string placement = null, numeral = null;

                //prompt for each turn
                Console.WriteLine("Attempt #{0}", attempts);
                
                //current guess string
                //could be consolidated into separate class
                string guess = Console.ReadLine();

                //input checking
                if (guess.Length != 4)  //check length
                {
                    Console.WriteLine("Incorrect character amount. Limit to 4.");
                    attempts--;
                    continue;
                }
                else
                {
                    //check range
                }
                {
                    bool InvalidRange = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if ((int)char.GetNumericValue(guess[i]) < 1 || 6 < (int)char.GetNumericValue(guess[i]))
                        {
                            Console.WriteLine("Not in range. Limit to [1, 6].");
                            InvalidRange = true;
                            break;
                        }
                    }
                    if (InvalidRange)
                    {
                        attempts--;
                        continue;
                    }
                }

                //raises flag for correctness
                if (String.Equals(guess, answer))
                    success = true;

                //boolean array to keep track of correct guesses in answer
                //could also be consolidated into class
                bool[] verified = { false, false, false, false };
            
                for (int i = 0; i < 4; i++) //guess
                    for (int j = 0; j < 4; j++) //answer
                    {
                        if (verified[j])    //if verified as correct, skip answer index
                            continue;
                        if (guess[i] == answer[j])  //if numerals are same
                        {
                            if (i==j)   //if indices are same
                                placement += "+ ";
                            else        //if indices are different
                                numeral += "- ";
                            verified[j] = true; //numeral verified
                            break;  //go to next guess
                        }
                    }

                //displays correct placements (+)
                //and out of order numerals (-)
                string result = placement + numeral;
                Console.WriteLine(result);
            } while (attempts < 10 && !success);   //do until attempts run out

            //endgame
            if (success)
                Console.WriteLine("Yay! You won!");
            else
                Console.WriteLine("Better luck next time. Answer was " + answer);

            Console.ReadKey();
        }
    }
}