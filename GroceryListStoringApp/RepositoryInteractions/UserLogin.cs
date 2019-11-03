using GroceryListStoringApp.DomainClasses;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryListStoringApp.RepositoryInteractions
{
    class UserLogin
    {
        Users user;
        public UserLogin() {
            user = new Users();
        }

        //User Login
        public Users UserLoginCheck(string username, string password)
        {
            user = null;
            try
            {
                int n = 0;
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Users> usersList = session.Query<Users>().ToList();

                    for (var i = 0; i < usersList.Count; i++){
                        if (usersList[i].username == username && usersList[i].password == password){
                           user = usersList[i];
                           n++;
                           break; 
                        }
                    }
                }

                if (n == 0){
                    MessageBox.Show("User Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return user;
                }
                else {
                    return user;
                }
            }
            catch (Exception msg){
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
