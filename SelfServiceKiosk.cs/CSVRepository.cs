using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SelfServiceKiosk.cs
{
    internal static class CSVRepository
    {
        private const string DATE_FILE_FOLDER = "DATE";
        private const string DATE_FILE_NAME = "food.csv";

        public static List<Fooditem> GetFooditemsfromCSV()
        {
            List<Fooditem> result = new();
            string PathtoDateFile = Path.Combine(DATE_FILE_FOLDER, DATE_FILE_NAME);
            string foodItemsContent = File.ReadAllText(PathtoDateFile);
            result = JsonSerializer.Deserialize<List<Fooditem>>(foodItemsContent);

            if(!File.Exists(PathtoDateFile))
            {
                Console.WriteLine($"fayl topilmadi:{PathtoDateFile}");
            }

            return result;
        }




    }
}