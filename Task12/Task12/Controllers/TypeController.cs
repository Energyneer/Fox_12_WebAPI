using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeController : ControllerBase
    {
        private ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }


        // GET: api/<TypeController>
        [HttpGet]
        public IEnumerable<TypeDto> Get()
        {
            string userName = User.Identity.Name;
            return _typeService.GetType(userName);
        }

        // POST api/<TypeController>
        [HttpPost]
        public void Post(TypeDto type)
        {
            _typeService.InsertType(type, User.Identity.Name);
        }

        // PUT api/<TypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, TypeDto type)
        {
            _typeService.UpdateType(id, type, User.Identity.Name);
        }

        // DELETE api/<TypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _typeService.DeleteType(id, User.Identity.Name);
        }
    }
}
