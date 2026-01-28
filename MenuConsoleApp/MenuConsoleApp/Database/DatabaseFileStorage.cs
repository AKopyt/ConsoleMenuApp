using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using Newtonsoft.Json;
namespace MenuConsoleApp.Database
{
    public class DatabaseFileStorage
    {
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public IDatabase ReadDatabase(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException();
            }
           
            string json = File.ReadAllText(pathToFile);
            return JsonConvert.DeserializeObject<Database>(json, _jsonSettings) ?? new Database();
        }

        public void SaveDatabase(IDatabase database, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(database, Formatting.Indented, _jsonSettings));
        }
    }
}
