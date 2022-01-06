using PeakyBarbers.Data.Entities;
using System;
using System.Linq.Expressions;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.BLL.ExpressionMappers
{
    public static class ServiceExpressions
    {
        /// <summary>
        /// ServiceDelete Selector
        /// </summary>
        public static Expression<Func<Service, ServiceDelete>> ServiceDeleteSelector = s => new ServiceDelete
        {
            Id = s.Id,
            ServiceName = s.ServiceName,
            ServiceFee = s.ServiceFee,
            ServiceDescription = s.ServiceDescription,
            ApproximateServiceDurationInMinutes = s.ApproximateServiceDurationInMinutes

        };

        /// <summary>
        /// ServiceEdit Selector
        /// </summary>
        public static Expression<Func<Service, ServiceEdit>> ServiceEditSelector = s => new ServiceEdit
        {
            Id = s.Id,
            ServiceName = s.ServiceName,
            ServiceFee = s.ServiceFee,
            ServiceDescription = s.ServiceDescription,
            ApproximateServiceDurationInMinutes = s.ApproximateServiceDurationInMinutes

        };

        /// <summary>
        /// ServiceHeader Selector
        /// </summary>
        public static Expression<Func<Service, ServiceHeader>> ServiceHeaderSelector = s => new ServiceHeader
        {
            Id = s.Id,
            ServiceName = s.ServiceName,
            ServiceFee = s.ServiceFee,
            ApproximateServiceDurationInMinutes = s.ApproximateServiceDurationInMinutes
            
        };

    }
}
