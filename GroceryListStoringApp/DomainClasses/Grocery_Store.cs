using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.DomainClasses
{
    //Fields from table Grocery Store
    public class Grocery_Store
    {
        public virtual int id_grocery_list_fk { get; set; } 
        public virtual int id_grocery_item_fk { get; set; } 
    }
}
