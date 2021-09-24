using Domain;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class TypeServices : ITypeService
    {
        private UsersRepository _userIdentRepository;
        private IDataRepository<StandartType> _standartTypeRepository;
        private IDataRepository<UserType> _userTypeRepository;

        public TypeServices(UsersRepository userIdentRepository, IDataRepository<StandartType> standartTypeRepository, IDataRepository<UserType> userTypeRepository)
        {
            _userIdentRepository = userIdentRepository;
            _standartTypeRepository = standartTypeRepository;
            _userTypeRepository = userTypeRepository;
        }

        public IEnumerable<TypeDto> GetType()
        {
            IEnumerable<StandartType> standartTypes = _standartTypeRepository.GetAll();
            List<TypeDto> result = new List<TypeDto>();
            foreach (StandartType item in standartTypes)
            {
                result.Add(Mapper.TypeToDto(item));
            }
            return result;
        }

        public IEnumerable<TypeDto> GetType(string userName)
        {
            List<TypeDto> result = GetType().ToList();

            User user = _userIdentRepository.Get(userName);
            IEnumerable<UserType> userTypes = from item in _userTypeRepository.GetAll() where item.Owner.Equals(user) select item;
            foreach (UserType item in userTypes)
            {
                result.Add(Mapper.TypeToDto(item));
            }

            return result;
        }

        public void InsertType(TypeDto type, string userName)
        {
            User user = _userIdentRepository.Get(userName);
            _userTypeRepository.Insert(new UserType { OperationType = type.OperationType, Name = type.Name, Owner = user });
        }

        public void UpdateType(int ID, TypeDto type, string userName)
        {
            UserType typeFromDB = _userTypeRepository.Get(ID);
            CheckAccessRights(typeFromDB, userName);

            typeFromDB.OperationType = type.OperationType;
            typeFromDB.Name = type.Name;
            _userTypeRepository.Update(typeFromDB);
        }

        public void DeleteType(int ID, string typeName)
        {
            UserType typeFromDB = _userTypeRepository.Get(ID);
            CheckAccessRights(typeFromDB, typeName);
            _userTypeRepository.Delete(typeFromDB);
        }

        private void CheckAccessRights(UserType type, string userName)
        {
            User user = _userIdentRepository.Get(userName);
            if (type.Owner != user)
                throw new UnauthorizedAccessException();
        }
    }
}
