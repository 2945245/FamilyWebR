using System.Collections.Generic;

namespace FamilyWeb.Model
{
    public class FamilyObject
    {
      
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber{ get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children{ get; set; }
        public List<Pet> Pets{ get; set; }
        public string Address { get; set; }
        
        

        public FamilyObject()
        {
            Adults = new List<Adult>();
        }

        public void SetAddress()
        {
            Address= $"{StreetName} {HouseNumber}";

        }  
    }
}