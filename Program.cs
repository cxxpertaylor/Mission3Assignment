using System.ComponentModel.Design;
using System.Xml.Linq;
using Mission3Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        List<FoodItem> foodItems = new List<FoodItem>();   //make a list to hold all of the food item objects

        while (true)
        {
            //Ask the user what they would like to do
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Add food items");
            Console.WriteLine("2: Delete food items");
            Console.WriteLine("3: Print list of current food items");
            Console.WriteLine("4: Exit the program");
            Console.Write("\nPlease select an option (1-4): ");
            string selection = Console.ReadLine();

            List<string> validInputs = new List<string> { "1", "2", "3", "4" }; //list of valid menu options

            if (validInputs.Contains(selection))
            {
                //If the user enters 1, add a new food item object to the foodItems array.
                if (selection == "1")
                {
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter the category: ");
                    string category = Console.ReadLine();

                    //get quantity from user and make sure the user enters a number greater than 0
                    bool isValid = false;
                    int quantity = 0;
                    while (!isValid)
                    {
                        Console.Write("Enter the quantity: ");
                        string quantityInput = Console.ReadLine();
                        isValid = int.TryParse(quantityInput, out quantity) && quantity > 0;

                        if (!isValid)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
                        }
                       
                    }

                    //get the expiration date from the user and make sure they enter a valid date
                    DateTime expirationDate = DateTime.MinValue;
                    isValid = false;
                    while (!isValid)
                    {
                        Console.Write("Enter the expiration date (YYYY-MM-DD): ");
                        string expirationDateInput = Console.ReadLine();
                        isValid = DateTime.TryParse(expirationDateInput, out expirationDate);

                        if (!isValid)
                        {
                            Console.WriteLine("Invalid date. Please enter the date in the format YYYY-MM-DD.");
                        }
                    }

                    FoodItem fi = new FoodItem(name, category, quantity, expirationDate); //make a FoodItem object
                    foodItems.Add(fi); //add the new food item object to the foodItems array
                    Console.WriteLine("Item added successfully.\n");
                }

                //If the user enters 2, delete a specific food item
                else if (selection == "2")
                {
                    if (foodItems.Count == 0)   //error handling if they try to delete without adding any food items
                    {
                        Console.WriteLine("You have not added any food items yet.\n");  
                    }

                    else
                    {
                        bool isValid = false;
                        int deleteItem = 0;
                        while (!isValid)
                        {
                            Console.WriteLine("\nItem list:");

                            //show the options to delete
                            for (int i = 0; i < foodItems.Count; i++)
                            {
                                Console.WriteLine((i + 1) + ": " + foodItems[i].Name);
                            }

                            Console.Write("Please select an item to delete: ");
                            string deleteItemInput = Console.ReadLine();
                            isValid = int.TryParse(deleteItemInput, out deleteItem) && deleteItem > 0 && deleteItem <= foodItems.Count;

                            // error handling for non integers and integers out of the menu range
                            if (!isValid)
                            {
                                Console.WriteLine("Invalid option. Please choose a number 1-" + foodItems.Count);
                            }
                        }

                            foodItems.RemoveAt(deleteItem - 1);
                            Console.WriteLine("Item deleted successfully.\n");

                    }
                }

                //If the user enters 3, print the current food items
                else if (selection == "3")
                {
                    if (foodItems.Count == 0)   //error handling if they try to delete without adding any food items
                    {
                        Console.WriteLine("You have not added any food items yet.");
                    }

                    Console.WriteLine("\nList of current food items:");
                    foreach (FoodItem food in foodItems)
                    {
                        if (food.ExpirationDate > DateTime.Now)
                        {
                            Console.WriteLine("Name: " + food.Name + "  Expiration Date: " + food.ExpirationDate + "\n");
                        }
                    }
                }

                //If the user enters 4, exit the program
                else if (selection == "4")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
            }

            else //make sure the user enters a valid menu item.
            {
                Console.WriteLine("Not a valid menu item. Please try again.\n");
            }
        }        
    }
}