using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyWeb.Data;
using FamilyWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace FamilyWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController:ControllerBase
    {
        public IFamiliesData FamiliesData;

        public FamiliesController(IFamiliesData familiesData)
        {
            FamiliesData = familiesData;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<FamilyObject>>>
            GetFamilies([FromQuery] int? familyAddress, [FromQuery] Child? children)
        {
            try
            {
                IList<FamilyObject> families = await FamiliesData.GetAllFamilies();
                if (familyAddress != null)
                {
                    families = families.Where(todo => children != null).ToList();
                }
                

                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}