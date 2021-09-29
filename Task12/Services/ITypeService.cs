using Domain;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITypeService
    {
        IEnumerable<TypeDto> GetAll(User user, bool standarts, bool users, bool income, bool expend);
        TypeDto Get(User user, int id);
        //bool AccessRights(User user, int id);
        void InsertType(User user, TypeDto type);
        void UpdateType(User user, TypeDto type, int id);
        void DeleteType(User user, int id);
    }
}
