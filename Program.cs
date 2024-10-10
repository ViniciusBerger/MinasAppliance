using assignment1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Program
    {
        //Creating appliance lists to all type of objects of the store
        static List<Appliance> appliances = new List<Appliance>();

        //Getting the file path and saving it in a attribute
        static string path = @"../../appliances.txt";
        static public string[] lines = File.ReadAllLines(path);



        static void Main(string[] args)
        {
            // create objects based on each line in the file and save them in its respective class based on its item number
            save_by_class();

            //This method displays all menu options
            displayMenu();
        }


        // create objects based on each line in the file and save them in its respective class based on its item number
        static void save_by_class()
        {
            //When the function starts its gonna read the file and add each value within a attribute and then, based in the first character of each itemNumber it will add that specific object in its respective list
            // 1 - refrigerators / 2- vacuums / 3- microwaves / 4,5 - Dishwasher
            foreach (string line in lines)
            {
                string[] field = line.Split(';');


                long itemNumber = long.Parse(field[0]);
                string brand = field[1];
                int quantity = int.Parse(field[2]);
                double wattage = double.Parse(field[3]);
                string color = field[4];
                double price = double.Parse(field[5]);

                string stringItemNumber = itemNumber.ToString();
                char firstChar = stringItemNumber[0];


                switch (firstChar)
                {
                    case '1':
                        int numberofDoors = int.Parse(field[6]);
                        int height = int.Parse(field[7]);
                        int width = int.Parse(field[8]);
                        appliances.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, numberofDoors, height, width));
                        break;

                    case '2':
                        string grade = field[6];
                        int batteryWattage = int.Parse(field[7]);
                        appliances.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, batteryWattage, grade));
                        break;

                    case '3':
                        double capacity = double.Parse(field[6]);
                        char roomType = char.Parse(field[7]);
                        appliances.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType));
                        break;

                    case '4':
                    case '5':
                        string soundRating = field[7];
                        string feature = field[6];

                        appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating));
                        break;

                    default:
                        break;
                }

            }
        }

        //This method displays all menu options
        static public void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("   Welcome to Modern Appliances!    ");
            Console.WriteLine("      How may we assist you?        ");
            Console.WriteLine("----------------------------------- ");
            Console.WriteLine();
            Console.WriteLine("     1-Check out appliances         ");
            Console.WriteLine("     2-Find appliances by brand     ");
            Console.WriteLine("     3-Display Appliances by type   ");
            Console.WriteLine("     4-Produce random Appliance list");
            Console.WriteLine("     5-Save and Exit                ");

            //Get the answer value from the user and coverts it to a char datatype 
            string stringOption = Console.ReadLine();

            if (string.IsNullOrEmpty(stringOption))
            {
                displayMenu();
            }
            else
            {
                char option = stringOption[0];

                process_option(option);
            }

        }

        static void process_option(char option)
        {
            switch (option)
            {
                //check out appliances
                case '1':
                    checkout_appliance();
                    break;

                //find appliances by brand
                case '2':
                    find_by_brand();
                    break;

                //display appliances by type
                case '3':
                    find_by_type();
                    break;
                //produce random appliances list
                case '4':
                    display_random_list();
                    break;
                //Save and exit
                case '5':
                    save_exit();
                    break;
                //default case
                default:
                    displayMenu();
                    break;
            }
        }

        //      This method does the function checkout appliance in the menu above (option 1)
        static void checkout_appliance()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your item Number: ");
            long productNumber = long.Parse(Console.ReadLine());
            bool notInList = false;

            //for each item in the list this function checks if the user's imput is in the list. If it exists the function removes it from inventory, if not it shows a message saying that the appliance is unavailable
            foreach (Appliance item in appliances)
            {
                if (item.itemNumber == productNumber)
                {
                    item.checkout();
                    Console.ReadLine();
                }
                //product not in list
                else
                {
                    notInList = true;
                }

            }

            //This if shows the unavailable message if the item is not in list
            if (notInList) Console.WriteLine("This item is not available in our stock!");
            Console.ReadLine();

            // return to the main menu
            displayMenu();
            Console.ReadLine();
        }

        // search appliance by the brand
        static void find_by_brand()
        {
            Console.WriteLine("Please type the item brand: ");
            string itemBrand = Console.ReadLine();
            bool inList = false;

            foreach (Appliance item in appliances)
            {
                if (string.Equals(itemBrand, item.brand.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(item.ToString());
                    inList = true;


                }

            }
            if (!inList) Console.WriteLine("This brand is not available in our stock!");
            Console.ReadLine();

            // return to main menu
            displayMenu();
            Console.ReadLine();
        }

        // seach appliance by the type
        static void find_by_type()
        {
            // method display_menu_type display a menu to the user choose the item type and return the first character of this number, which allows the system to seach which class the choosen item is
            char itemType = display_menu_type();
           
            // if item is refrigerator 
            if (itemType == '1')
            {
                //Ask the user to input the number of doors
                Console.WriteLine("Enter number of doors: (2 doors, 3 doors or 4 doors)");
                int numberofDoors = int.Parse(Console.ReadLine());

                if (numberofDoors == 2 || numberofDoors == 3 || numberofDoors == 4)
                {
                    foreach (Appliance item in appliances)
                    {
                        string itemId = item.itemNumber.ToString();
                        char itemNumber = itemId[0];

                        //if item is an object of Refrigerator class
                        if (item is Refrigerator)
                        {
                            //save this appliance object in a variable that is Refrigerator (casting) the item in a variable with the numberofDoors attribute
                            Refrigerator r = (Refrigerator)item;
                            if (numberofDoors == r.numberofDoors)
                            {
                                Console.WriteLine(r);
                            }
                        }
                    }
                    Console.ReadLine();
                    displayMenu();
                    }
                else
                {
                    Console.WriteLine("the caracteristics you selected is not available in any of our items. You will be redirected to MENU");
                    Console.ReadLine();
                    displayMenu();
                    Console.ReadLine();
                }
            }

            //if item is vacuum 
            else if (itemType == '2')
            {
                Console.WriteLine("Please type the battery wattage value: 18 V (low) or 24 V (high) ");
                int userWattage = int.Parse(Console.ReadLine());

                if (userWattage == 18 || userWattage == 24)
                {
                    foreach (Appliance item in appliances)
                    {
                        if (item is Vacuum)
                        {
                            Vacuum vacuum = (Vacuum)item;
                            if (vacuum.batteryWattage == userWattage)
                                Console.WriteLine(vacuum);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("the wattage you selected is not available in any of our items. You will be redirected to MENU");
                    Console.ReadLine();
                    displayMenu();
                    Console.ReadLine();
                }
            }
            //If the item is a microwave (itemtype 3)
            else if (itemType == '3')
            {

                Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site): ");
                char instalationSpot = char.Parse(Console.ReadLine());
                char roomType = char.ToUpper(instalationSpot);

                if (roomType == 'K' || roomType == 'W')
                {
                    foreach (Appliance item in appliances)
                    {
                        if (item is Microwave)
                        {
                            Microwave microwave = (Microwave)item;
                            if (microwave.roomType == roomType)
                                Console.WriteLine(microwave);
                        }
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("the option you selected is not available in any of our items. You will be redirected to MENU");
                    Console.ReadLine();
                    displayMenu();
                    Console.ReadLine();
                }

            }
            //if the item is dishwashe (itemtype 4  and 5)
            else if (itemType == '4' || itemType == '5')
            {
                Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                string soundRating = Console.ReadLine().ToUpper().Trim();
                if (soundRating == "QT" || soundRating == "QR" || soundRating == "QU" || soundRating == "M")
                {
                    foreach (Appliance item in appliances)
                    {
                        if (item is Dishwasher)
                        {
                            Dishwasher dishwasher = (Dishwasher)item;
                            if (dishwasher.soundRating == soundRating)
                            {
                                Console.WriteLine(dishwasher);
                            }
                        }
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("the option you selected is not available in any of our items. You will be redirected to MENU");
                    Console.ReadLine();
                    displayMenu();
                    Console.ReadLine();
                }
            }
        }

        // display a random list of appliance by the amount the user wants to see
        static void display_random_list()
        {
            Console.WriteLine();
            Console.WriteLine("How many items do you want to see? ");
            int wantedAmount = int.Parse(Console.ReadLine());
            int i = 1;

            foreach (Appliance item in appliances)
            {
                if (i <= wantedAmount)
                {
                    Console.WriteLine($" {i,-3} - {item.ToString()}");
                    i++;
                }
                else
                {
                    continue;
                }
            }           
            displayMenu();
        }

        // save the modifications and exit
        static void save_exit()
        {
            string stringItem = "";
            foreach (Appliance item in appliances)
            {
                stringItem += item.formatforFile() + Environment.NewLine;
            }

            File.WriteAllText(path, stringItem);
        }

        // Display the mini menu to the user showing which number refers to each appliance type and return a char with the number of the choosen item
        static char display_menu_type()
        {
            Console.WriteLine("----- Available Appliances -------");
            Console.WriteLine("       [1] Refrigerator           ");
            Console.WriteLine("       [2] Vacuum                 ");
            Console.WriteLine("       [3] Microwave              ");
            Console.WriteLine("       [4] / [5] Dishwasher       ");

            Console.WriteLine("Please type your items type: ");
            string userAnswer = Console.ReadLine();
            char itemType = userAnswer[0];

            return itemType;
        }
    }
}

