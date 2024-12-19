// See https://aka.ms/new-console-template for more information
using drinks_info.Models;

namespace drinks_info
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            UserInput userInput = new();
            List<Category> categories = userInput.GetHttp();
            userInput.GetCategoriesInput(categories);
        }
    }
}
