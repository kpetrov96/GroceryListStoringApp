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
    class CreateUser
    {
        //Create new user
        public void CreateNewUser(string userP, string passP) {
            int n = 0;
            string username = userP;
            string password = passP;

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Users> usersList = session.Query<Users>().ToList();
                    for (var i = 0; i < usersList.Count; i++){
                        if (usersList[i].username == username){
                            MessageBox.Show("Username taken!");
                            n++;
                        }
                    }

                    if (n == 0){
                        Users user = new Users { username = username, password = password };

                        using (ITransaction transaction = session.BeginTransaction()){
                            session.Save(user);
                            transaction.Commit();
                        }
                        MessageBox.Show("User Created. You can login now!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception msg){
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
