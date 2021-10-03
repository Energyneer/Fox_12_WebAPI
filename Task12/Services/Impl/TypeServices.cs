using Domain;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;

namespace Services.Impl
{
    public class TypeServices : ITypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IAccountRepository _accountRepository;

        public TypeServices(IUserTypeRepository userTypeRepository, IAccountRepository accountRepository)
        {
            _userTypeRepository = userTypeRepository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<TypeDto> GetAll(User user, bool standarts = true, bool users = true, bool income = true, bool expend = true)
        {
            IEnumerable<OrderType> typesFromDB = _userTypeRepository.GetAll(user, standarts, users, income, expend);
            List<TypeDto> result = new List<TypeDto>();
            foreach (OrderType type in typesFromDB)
            {
                result.Add(Mapper.TypeToDto(type));
            }
            return result;
        }

        public TypeDto Get(User user, int id)
        {
            OrderType type = _userTypeRepository.Get(id);
            if (type.UserId == user.Id || type.UserId == _accountRepository.SystemUser.Id ||
                _accountRepository.isAdmin(user))
            {
                return Mapper.TypeToDto(type);
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public void InsertType(User user, TypeDto type)
        {
            if (type == null || string.IsNullOrEmpty(type.Name))
                throw new ArgumentNullException();

            if (type.Variety == TypeVariety.STANDART && !_accountRepository.isAdmin(user))
                throw new UnauthorizedAccessException();

            OrderType existTypes = _userTypeRepository.GetByName(user, type.Name);

            if (existTypes != null)
                throw new ArgumentException("Order type name is already exist");

            OrderType entity = Mapper.OrderTypeFromDto(user, type);
            _userTypeRepository.Insert(entity);
        }

        public void UpdateType(User user, TypeDto type, int id)
        {
            if (type == null || string.IsNullOrEmpty(type.Name))
                throw new ArgumentNullException();

            OrderType typeFromDB = _userTypeRepository.Get(id);
            if (typeFromDB == null)
                throw new ArgumentException("Type with Id: " + id + " is not exist");

            if (!(typeFromDB.UserId == user.Id ||
                (type.Variety == TypeVariety.STANDART && _accountRepository.isAdmin(user))))
            {
                throw new UnauthorizedAccessException();
            }

            OrderType existTypes = _userTypeRepository.GetByName(user, type.Name);

            if (existTypes != null)
                throw new ArgumentException("Order type name is already exist");

            typeFromDB.Name = type.Name;
            typeFromDB.OperationCategory = type.OperationCategory;
            _userTypeRepository.Update(typeFromDB);
        }

        public void DeleteType(User user, int id)
        {
            OrderType typeFromDB = _userTypeRepository.Get(id);
            if (typeFromDB == null)
                throw new ArgumentException("Type with Id: " + id + " is not exist");

            if (typeFromDB.UserId != user.Id && !_accountRepository.isAdmin(user))
            {
                throw new UnauthorizedAccessException();
            }

            _userTypeRepository.Delete(typeFromDB);
        }
    }
}
