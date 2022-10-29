using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Context.Configuration
{
    public class UserBillConfiguration : IEntityTypeConfiguration<UserBill>
    {
        public void Configure(EntityTypeBuilder<UserBill> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
