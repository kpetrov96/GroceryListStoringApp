using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.DomainClasses
{
    //Fields from table Grocery_Item
    public class Grocery_Item
    {
        /*public Grocery_Item() {
            groceryList = new HashSet<Grocery_List>();
        }
        public virtual ICollection<Grocery_List> groceryList { get; set; }*/
            
        public virtual int id_grocery_item { get; set; }
        public virtual string item_description { get; set; }

    }
}
