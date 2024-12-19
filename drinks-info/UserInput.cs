
using drinks_info.Models;
using Microsoft.VisualBasic;

namespace drinks_info
{
    public class UserInput
    {
        DrinksService drinksService = new();

        internal List<Category> GetHttp()
        {
            List<Category> categories = drinksService.GetCategories();
            return categories;
        }

        internal void GetCategoriesInput(List<Category> categories) {
                        
            string category = "";

            while(category != "exit"){

                TableVisualistionEngine.ShowTable(categories, "Categories Menu");

                Console.WriteLine("Choose category (Type 'exit' to exit or 'r' to refresh)");

                category = Console.ReadLine();

                while(!Validator.IsStringValid(category))
                {
                    Console.WriteLine("\nInvalid category");
                    category = Console.ReadLine();
                }

                if(!categories.Any(x => x.strCategory == category) && category != "exit" && category != "r")
                {
                    Console.WriteLine("Category does not exist.");
                }

                if (category != "exit" && category != "r"){
                    GetDrinksInput(category, categories);
                }
                else if(category == "r")
                {
                    categories = GetHttp();
                }
            }
            
        
        }

        private void GetDrinksInput(string category, List<Category> categories)
        {
            var drinks = drinksService.GetDrinksByCategory(category);
            
            Console.WriteLine("Choose a drink or go back by typing 0: ");

            string drink = Console.ReadLine();

            if (drink == "0") return;

            while(!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if(!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                return;
            }

            drinksService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
        }
    }
}