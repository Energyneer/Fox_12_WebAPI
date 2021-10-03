using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System.Collections.Generic;

namespace Task12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeController : ControllerBase
    {
        private ITypeService _typeService;
        private IAccountService _accountService;

        public TypeController(ITypeService typeService, IAccountService accountService)
        {
            _typeService = typeService;
            _accountService = accountService;
        }

        [HttpGet]
        public IEnumerable<TypeDto> GetAll(string target, bool std, bool usr, bool income, bool expend)
        {
            return _typeService.GetAll(_accountService.GetByUserName(User.Identity.Name), std, usr, income, expend);
        }

        [HttpGet("{id}")]
        public TypeDto Get(int id)
        {
            return _typeService.Get(_accountService.GetByUserName(User.Identity.Name), id);
        }

        [HttpPost]
        public void Post([FromBody] TypeDto type)
        {
            User currentUser = _accountService.GetByUserName(User.Identity.Name);
            _typeService.InsertType(currentUser, type);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TypeDto type)
        {
            _typeService.UpdateType(_accountService.GetByUserName(User.Identity.Name), type, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _typeService.DeleteType(_accountService.GetByUserName(User.Identity.Name), id);
        }
    }
}
