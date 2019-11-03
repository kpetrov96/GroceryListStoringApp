using FluentNHibernate.Mapping;
using GroceryListStoringApp.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.MappingClasses
{
    public class UsersMap : ClassMap<Users>
    {
        //Mapping Users table
        public UsersMap()
        {
            Id(c => c.id_user);
            Map(c => c.username);
            Map(c => c.password);
        }
    }
}
