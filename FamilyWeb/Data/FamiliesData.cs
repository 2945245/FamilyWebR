using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWeb.Model;

namespace FamilyWeb.Data
{
    public class FamiliesData:IFamiliesData
    {
        private IList<Adult> allAdults;
        private IList<FamilyObject> allFamilies;
        private FileContext fileContext;
        
        public FamiliesData()
        {
         
            if (fileContext == null)
            {
                fileContext = new FileContext();
            }
            allAdults = fileContext.Adults;
            allFamilies = fileContext.Families;

        }

        public async Task<IList<Adult>> GetAllAdults()
        {
            List<Adult> allAdultsTmp = new List<Adult>();
            foreach (var family in allFamilies)
            {
                foreach (var adult in family.Adults)
                {
                    allAdultsTmp.Add(adult);
                }
            }

            return allAdultsTmp;
        }

        public async Task<IList<FamilyObject>> GetAllFamilies()
        {
            
            foreach (var family in allFamilies)
            {
                family.SetAddress();
            }

            return allFamilies;

        }

        public void NewAdult(FamilyObject familyObject)
        {
            allFamilies.Add(new FamilyObject()
            {
                Address = familyObject.Address,
                HouseNumber = familyObject.HouseNumber,
                StreetName = familyObject.StreetName,
                Pets = familyObject.Pets,
                Children = familyObject.Children,
                Adults = familyObject.Adults

            });
                
            fileContext.SaveChanges();
        }
    }
}