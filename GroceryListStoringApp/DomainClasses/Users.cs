using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp.DomainClasses
{
    //Fields from table Users
    public class Users
    {
        public virtual int id_user { get; set; } 
        public virtual string username { get; set; }
        public virtual string password { get; set; }
    }
}
