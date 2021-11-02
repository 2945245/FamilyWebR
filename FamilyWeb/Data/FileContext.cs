using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FamilyWeb.Model;

namespace FamilyWeb.Data
{
    public class FileContext
    {
        public IList<FamilyObject> Families { get;  private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        // private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<FamilyObject>(familiesFile) : new List<FamilyObject>();
            //  Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            Adults = File.Exists(familiesFile) ? ReadData<Adult>(familiesFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            //storing persons
            // string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // });
            // using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            // {
            //     outputFile.Write(jsonAdults);
            // }
        }
    }
}