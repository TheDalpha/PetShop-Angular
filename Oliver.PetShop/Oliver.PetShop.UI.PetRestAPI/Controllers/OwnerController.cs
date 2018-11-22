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
    public class OwnerController : ControllerBase
    {

        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET: api/Owner/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // POST: api/Owner
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _ownerService.AddOwner(owner);
        }

        // PUT: api/Owner/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            return _ownerService.UpdateOwner(id, owner);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}