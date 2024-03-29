﻿using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;
using OnlineStoreMicroservices.AccountantsDepartment.Models;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Queries.GetUserProducts
{
    public class UserBillDto : IMapFrom<UserBill>
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserBill, UserBillDto>();
        }
    }
}