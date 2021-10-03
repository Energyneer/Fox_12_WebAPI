using Domain;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;

namespace Services.Impl
{
    public class ReportService : IReportService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IOrderRepository _orderRepository;

        public ReportService(IUserTypeRepository userTypeRepository, IOrderRepository orderRepository)
        {
            _userTypeRepository = userTypeRepository;
            _orderRepository = orderRepository;
        }

        public ReportDto Get(User user, string typeName = null, DateTime? startTime = null, DateTime? endTime = null)
        {
            if (startTime != null && (startTime < DateTime.UnixEpoch || startTime > DateTime.Now))
                throw new ArgumentException("Start time is not correct");

            if (endTime != null && (endTime < DateTime.UnixEpoch || endTime > startTime))
                throw new ArgumentException("End time is not correct");

            if (typeName != null)
            {
                OrderType type = CheckAndGetType(user, typeName);
                return OneType(user, type, startTime, endTime);
            }
            else
            {
                return AllTypes(user, startTime, endTime);
            }
        }

        private OrderType CheckAndGetType(User user, string typeName)
        {
            OrderType type = _userTypeRepository.GetByName(user, typeName);
            if (type != null)
            {
                return type;
            }
            else
            {
                throw new ArgumentException("Type with name: " + typeName + " is not exist");
            }
        }

        private ReportDto OneType(User user, OrderType type, DateTime? startTime = null, DateTime? endTime = null)
        {
            ReportDto report = new ReportDto();
            OneTypeProcessing(user, type, report, startTime, endTime);
            return report;
        }

        private ReportDto AllTypes(User user, DateTime? startTime = null, DateTime? endTime = null)
        {
            IEnumerable<OrderType> userTypes = _userTypeRepository.GetAll(user);
            ReportDto report = new ReportDto();
            foreach (OrderType t in userTypes)
            {
                OneTypeProcessing(user, t, report, startTime, endTime);
            }
            return report;
        }

        private void OneTypeProcessing(User user, OrderType type, ReportDto report,
            DateTime? startTime = null, DateTime? endTime = null)
        {
            decimal amount = startTime.HasValue && endTime.HasValue ?
                _orderRepository.SumByType(user, type, startTime.Value, endTime.Value) :
                _orderRepository.SumByType(user, type);
            report.Details.Add(type.Name, amount);

            report.Balance = type.OperationCategory == Category.INCOME ?
                report.Balance + amount : report.Balance - amount;

            report.TotalIncome = type.OperationCategory == Category.INCOME ?
                report.TotalIncome + amount : report.TotalIncome;

            report.TotalExpend = type.OperationCategory == Category.INCOME ?
                report.TotalExpend : report.TotalExpend + amount;
        }
    }
}
