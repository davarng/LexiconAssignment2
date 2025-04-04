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
                $"2. {Environment.NewLine}" +
                $"3. ");
            //Nullable string because the user might just hit enter.
            string? input = Console.ReadLine();
            //Declaring bool for TryParse that resets when the loop runs again.
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
                    do
                    {
                        //Max 20 guests to give some reasonable upper end.
                        Console.WriteLine("How many guests? (MAX 20)");
                        success = int.TryParse(Console.ReadLine(), out int guests);
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
                    } while (!success);

                    break;

                case "2":


                    break;

                case "3":
                    break;

                case "4":
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
