using System;
using static System.Console;
class PimdMiscCalculator
{
    static void Main()
    {
        string methodChoice;
        int methodChoiceToInt,x = 0;

        //While loop to determine if you are doing a single trade or multiple trade, then calls that method 
        while (x !=1)
        {
            Write("Are you doing a single trade or multiple trades? Enter a 1 if you are doing a single trade or a 2 if you are doing multiple trades >> ");
            methodChoice = ReadLine();
            methodChoiceToInt = Convert.ToInt32(methodChoice);

            if (methodChoiceToInt == 1)//calls the single trade method and then adds 1 to x exit the loop
            {
                SingleTrade();
                x += 1;
            }
           else  if (methodChoiceToInt == 2) //calls the multiple trade and then adds 1 to x to exit the loop
            {
                MultipleTrades();
                x += 1;
            }
            else //error message for invalid input 
            {
                WriteLine("You entered an invalid option please try again. Please enter either a 1 for single trades or a 2 for multiple trades");
            }
        }




    }
    private static void SingleTrade() //method for single trades 
    {
        int  itemStatsToInt, numberofItems = 0, numberOfStacksToInt, itemStats, stackItemsToInt,tradeTotal = 0, x = 0,stackItemTotal = 0; 
        string itemStatsEntry, correctEntry, stackItems, numberOfStacks;

        Write("How many stacks are there? >> "); //number of unique items in the trade "stacks" 
        numberOfStacks = ReadLine();
        numberOfStacksToInt = Convert.ToInt32(numberOfStacks); //converts user input input in an integer 
        while (x < numberOfStacksToInt)//while loop that gets hte items/stacks stats and calculates their total and dispays it
        {
            Write("Enter one side of the misc either strenghth or intelligence >>  "); // enter only one side of the misc because it will multiiply by 2 to get the total
            itemStatsEntry = ReadLine();
            itemStatsToInt = Convert.ToInt32(itemStatsEntry);
            Write("How many items are in the stack >> ");
            stackItems = ReadLine();
            stackItemsToInt = Convert.ToInt32(stackItems);
            Write("Did you input the item in correctly y/n >> ");
            correctEntry = ReadLine();
            if (correctEntry == "y")
            {

                itemStats = itemStatsToInt * 2;
                stackItemTotal = itemStats * stackItemsToInt; // calculates the total stats of the stack 
                tradeTotal = stackItemTotal + tradeTotal; //adss the stack total misc 
                numberofItems += stackItemsToInt; //counts the number of items in the stack
                x += 1;
                WriteLine("\nThe misc total for that item stack is {0}\n", stackItemTotal.ToString("n")); // displays the misc total of the entered stack
            }
            else if (correctEntry == "n")
            {
                WriteLine("\nYou entered the item stack incorrectly please try");
            }
            else //Error code for invalid inpu 
            {
                WriteLine("\nComputer did not recgonize your input, please enter either a 'y' for yes or a 'n' for no");
            }
           
        }
        WriteLine("\nYou transffered {0} items for a total of {1} in misc stats", numberofItems, tradeTotal.ToString("n"));
    }
    private static void MultipleTrades()
    {
        int tradeTotal = 0, itemStats, totalMisc = 0, numberofItems = 0, itemStatsToInt, numberOfTrades = 0, stackItemTotal = 0, stackItemsToInt;
        string itemStatsEntry, correctEntry, stackItems, numberOfStacks, tradeDecision;


        bool trade = true;
        while (trade == true)
        {
            int x = 0, numberOfStacksToInt;
            Write("How many stacks are there? >> "); //number of unique items in the trade "stacks" 
            numberOfStacks = ReadLine();
            numberOfStacksToInt = Convert.ToInt32(numberOfStacks); //converts user input input in an integer 
            while (x != numberOfStacksToInt)//while loop that gets hte items/stacks stats and calculates their total and dispays it
            {
                Write("Enter one side of the misc either strenghth or intelligence >>  "); // enter only one side of the misc because it will multiiply by 2 to get the total
                itemStatsEntry = ReadLine();
                itemStatsToInt = Convert.ToInt32(itemStatsEntry);
                Write("How many items are in the stack >> ");
                stackItems = ReadLine();
                stackItemsToInt = Convert.ToInt32(stackItems);
                Write("Did you input the item in correctly y/n >> ");
                correctEntry = ReadLine();
                if (correctEntry == "y") // counts the item 
                {
                    itemStats = itemStatsToInt * 2; //Misc is counted using both sides so it multiplies the one side you entered by 2 to get the total stats for that item 
                    stackItemTotal = itemStats * stackItemsToInt; // calculates the total stats of the stack 
                    tradeTotal = stackItemTotal + tradeTotal; //adss the stack total misc 
                    numberofItems += stackItemsToInt; //counts the number of items in the stack
                    x += 1;
                    WriteLine("\nThe misc total for that item stack is {0}\n", stackItemTotal.ToString("n")); // displays the misc total of the entered stack
                }


                else if (correctEntry == "n") //does not count the entered item and asks again
                {
                    WriteLine("\nYou entered the item stack incorrectly please try");
                }



                else //Error code for invalid input
                {
                    WriteLine("\nComputer did not recgonize your input, please enter either a 'y' for yes or a 'n' for no");

                }

                numberOfTrades += 1;// adds the current trade to the total number of trades 
                totalMisc = tradeTotal; //Total amount of misc for the trade 


            }
            //If statement to determine if there is another trade
            //Either restarts the while loop or ends the program based on answer
            Write("Is there another trade y/n? >> ");
            tradeDecision = ReadLine();
            if (tradeDecision == "y")
            {
                trade = true; //restarts while loop for another trade
            }
            if (tradeDecision == "n")
            {
                WriteLine("You traded {0} times for a total of {1} items and a total of {2} in misc", numberOfTrades, numberofItems, totalMisc.ToString("n"));
                trade = false; //ends the program

            }
            if (tradeDecision != "y" && tradeDecision != "n")
            {
                WriteLine("You entered an invalid input please enter either a Y or N for yes or no");
            }


        }



    }
}
