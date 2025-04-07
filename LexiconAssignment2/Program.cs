namespace LexiconAssignment2;

internal class Program
{
    static void Main(string[] args)
    {
        //Infinite loop that returns to end loop. I tried to use a bool that I changed instead but it caused the application to pause on the last readline.
        while (true)
        {
            //Telling the user how the application works and receives input from user.
            Console.WriteLine($"Welcome to the Lexicon theatre!{Environment.NewLine}" +
                $"Press the number that corresponds to the option you want to choose and then press enter.{Environment.NewLine}" +
                $"0. Quit application.{Environment.NewLine}" +
                $"1. See ticket price.{Environment.NewLine}" +
                $"2. Write message 10 times.{Environment.NewLine}" +
                $"3. Split up sentence with atleast 3 words.");
            //Nullable string because the user might give a null value according to VS.
            string? input = Console.ReadLine();
            //Declaring bool for TryParse that resets when the loop runs again and guest variable 
            bool success;

            //Clearing console to make it less cluttered.
            Console.Clear();
            
            switch (input)
            {
                case "0":
                    //Return to instantly end the application.
                    Console.WriteLine("Application closed.");
                    return;

                case "1":
                    int guests;
                    do
                    {
                        //Max 20 guests to give some reasonable upper end.
                        Console.WriteLine("How many guests? (MAX 20)");
                        success = int.TryParse(Console.ReadLine(), out guests);
                        //Checks if TryParse failed. If it failed or if the number is unreasonable(ex -12, 1500) it warns the user and loops;
                        if (!success || guests > 20 || guests < 0)
                        {
                            Console.WriteLine("That is not a valid amount of guests.");
                        }
                        else
                        {
                            //Create int list that contains the prices and clear console.
                            int[] listOfCustomers = new int[guests];
                            Console.Clear();
                            for (int i = 0; i < guests;)
                            {                            
                                //Gives user information on which the current guest is and how many in total.
                                Console.Write($"Guest {i+1} out of {guests} age with a number: ");
                                success = int.TryParse(Console.ReadLine(), out int age);
                                //If failed TryParse or if the age is unreasonable (ex -20, 2000) it warns the user and tries again. Also skips increment of loop.
                                if (!success || age < 0 || age > 130)
                                {
                                    Console.WriteLine("The age you gave is not a number.");
                                }
                                else
                                {
                                    //Logic to check which cost range the current guest is part of and ads them to the list at the index of the current loop.
                                    if (age < 20 && age >= 5)
                                        listOfCustomers[i] = 80;
                                    else if (age > 64 && age <= 100)
                                        listOfCustomers[i] = 90;
                                    else if (age < 5 || age > 100)
                                        listOfCustomers[i] = 0;
                                    else
                                        listOfCustomers[i] = 120;
                                    //Message that tells the user what the current guests ticket price is and then increments the loop.
                                    Console.WriteLine($"Guest {i+1} ticket price: {listOfCustomers[i]} sek");
                                    i++;
                                }
                            }
                            //After the list of customers is filled with valid prices the user receives the sum of the list. Custom responses if only 1 guest. 
                            Console.WriteLine(Environment.NewLine +
                                (guests > 1 ? $"Total price for {guests} guests is: {listOfCustomers.Sum()}"
                                : listOfCustomers[0] == 80 ? "Youth ticket:80 sek"
                                : listOfCustomers[0] == 90 ? "Senior ticket:90 sek"
                                : listOfCustomers[0] == 0 ? "Free of charge!"
                                : "Standard price:120 sek")
                            );

                        }
                        //Step out of case if everything went right.
                    } while (!success || guests > 20);
                    break;

                case "2":
                    //Checks if the string given by the customer is null,empty string or just spaces. Repeats code until a valid answer.
                    do {
                        Console.WriteLine("Now write your message and it will be repeated 10 times!(Must not be only whitespace)");
                        input = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(input));
                    //Writes out the message given by the customer on the same line 10 times.
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.Write($"{i}.{input} ");
                    }
                    break;

                case "3":
                    //Asks user for input and creates a list with the words.
                    Console.WriteLine("Write a sentence with atleast 3 words and you will get the third word back.");
                    //Nullable input because VS warned me that it might be null, might be excessive?
                    var inputSplit = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    //Check for null again because of vs warning also making sure that the inputSplit contains atleast 3 words.
                    while (inputSplit == null || inputSplit.Length < 3)
                    {
                        //Error message and asks the user again until they give a valid answer.
                        Console.WriteLine("Your sentence is not the minimum 3 words that are required.");
                        inputSplit = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    //Gives user their word in index 2 (3rd word of array).
                    Console.WriteLine("Here is your word: " + inputSplit[2]);
                    break;

                default:
                    //If the switch input isn't valid the user gets warned.
                    Console.WriteLine("Input must be a number that corresponds to the options in the menu. Please try again.");
                    break;
            }
            //Stops the application so that it doesn't clear everything until the user presses enter.
            Console.WriteLine(Environment.NewLine + "Hit enter to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
