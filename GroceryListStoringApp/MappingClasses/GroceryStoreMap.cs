using FluentNHibernate.Mapping;
using GroceryListStoringApp.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.MappingClasses
{
    public class GroceryStoreMap : ClassMap<Grocery_Store>
    {
        //Mapping Grocery Store table
        public GroceryStoreMap()
        {
            Id(c => c.id_grocery_list_fk);
            Map(c => c.id_grocery_item_fk);
        }
    }
}
