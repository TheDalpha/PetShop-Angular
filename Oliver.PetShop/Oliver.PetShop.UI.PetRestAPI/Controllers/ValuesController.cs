using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.Entity;

namespace Oliver.PetShop.UI.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pet
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {

            return _petService.GetPets();
        }

        // GET api/pet/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.ReadById(id);
        }

        // POST api/pet
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {

            return _petService.AddPet(pet);
        }

        // PUT api/pet/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public void Put([FromBody] Pet pet)
        {
            _petService.UpdatePet(pet);
        }

        // DELETE api/pet/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
