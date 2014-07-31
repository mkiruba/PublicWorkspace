using FluentNHibernate.Mapping;
using SimpleUserRegistration.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUserRegistration.Data.NHibernate.Maps
{
    public class UsersMap : ClassMap<UserEntity>
    {
        public UsersMap()
        {
            Schema("dbo");
            Id(x => x.Id).Column("UserId").GeneratedBy.Native().UnsavedValue(0);
            Map(x => x.Name);
            Map(x => x.EmailAddress);
            Map(x => x.AddressLine1);
            Map(x => x.AddressLine2);
            Map(x => x.Postcode);
            Table("Users");
        }
    }
}
