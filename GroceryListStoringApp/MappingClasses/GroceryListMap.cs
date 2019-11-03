using FluentNHibernate.Mapping;
using GroceryListStoringApp.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.MappingClasses
{
    public class GroceryListMap : ClassMap<Grocery_List>
    {
        //Mapping Grocery List table
        public GroceryListMap()
        {
            Id(c => c.id_grocery_list);
            Map(c => c.id_user_fk);
            Map(c => c.permissions);

            /*HasManyToMany(c => c.groceryItem)
                //.Inverse()
                .Table("\"Grocery_Store\"")
                .ParentKeyColumn("id_grocery_list_fk")
                .ChildKeyColumn("id_grocery_item_fk")
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
                */
        }
    }
}
