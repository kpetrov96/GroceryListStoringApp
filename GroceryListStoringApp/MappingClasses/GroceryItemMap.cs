using FluentNHibernate.Mapping;
using GroceryListStoringApp.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.MappingClasses
{
    //Mapping Grocery Item table
    class GroceryItemMap : ClassMap<Grocery_Item>
    {
        public GroceryItemMap()
        {
            Id(c => c.id_grocery_item);
            Map(c => c.item_description);

          /*  HasManyToMany(c => c.groceryList)
                .Inverse()
                .Table("\"Grocery_Store\"")
                .ParentKeyColumn("id_grocery_item_fk")
                .ChildKeyColumn("id_grocery_list_fk")
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
          */
        }
    }
}
