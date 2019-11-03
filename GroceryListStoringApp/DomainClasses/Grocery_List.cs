using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.DomainClasses
{
    //Fields from table Grocery_List
    public class Grocery_List
    {
        /*public Grocery_List(){
             groceryItem = new HashSet<Grocery_Item>();
         }
         public virtual ICollection<Grocery_Item> groceryItem { get; set; }*/

        public virtual int id_grocery_list { get; set; }
        public virtual int id_user_fk { get; set; }  
        public virtual string permissions { get; set; } 

       
    }
}
