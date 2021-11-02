using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWeb.Model;

namespace FamilyWeb.Data
{
    public interface IFamiliesData
    {
        Task <IList<Adult>> GetAllAdults();
        Task<IList<FamilyObject>> GetAllFamilies();
        void NewAdult(FamilyObject family);
    }
}