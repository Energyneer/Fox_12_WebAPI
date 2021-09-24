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
        IEnumerable<TypeDto> GetType();
        IEnumerable<TypeDto> GetType(string userName);
        void InsertType(TypeDto type, string userName);
        void UpdateType(int ID, TypeDto type, string userName);
        void DeleteType(int ID, string typeName);
    }
}
