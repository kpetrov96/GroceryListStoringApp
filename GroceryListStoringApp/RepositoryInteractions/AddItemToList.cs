using GroceryListStoringApp.DomainClasses;
using NHibernate;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryListStoringApp.RepositoryInteractions
{
    class AddItemToList
    {
        //Add new item to existing grocery list
        public void AddNewItemToList(string selected, string selected2) {
            try
            {
                int selectedInt = 0;
                int selected2Int = 0;
                int n = 0;
                if (selected == "" || selected2 == "")
                {
                    MessageBox.Show("Choose List and Item from combo Boxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selectedInt = Int32.Parse(selected);

                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Grocery_Item> grocereriesItemsAll = session.Query<Grocery_Item>().ToList();

                    //Searching for id of selected item
                    for (var i = 0; i < grocereriesItemsAll.Count; i++){
                        if (grocereriesItemsAll[i].item_description.ToString() == selected2){
                            selected2Int = grocereriesItemsAll[i].id_grocery_item;
                            n++;
                        }
                    }

                    if (n == 1){
                        //NHibernate Grocery_Store Query error  
                        /*Grocery_Store add_item_to_list = new Grocery_Store { id_grocery_list_fk = selectedInt , id_grocery_item_fk = selected2Int };
                        using (ITransaction transaction = session.BeginTransaction()){
                            session.Save(add_item_to_list);
                            transaction.Commit();
                        }*/

                        //NpgSqlCommand used
                        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1 ; Port=5432 ; User Id=postgres; Password=root; Database=GroceryListStoringDB;");
                        conn.Open();
                        NpgsqlCommand command = new NpgsqlCommand($"INSERT into \"Grocery_Store\" (id_grocery_list_fk, id_grocery_item_fk) values ('{selectedInt}', '{selected2Int}'); ", conn);
                        NpgsqlDataReader dataReader = command.ExecuteReader();
                        MessageBox.Show("Grocery list item added.", "Information" , MessageBoxButtons.OK ,MessageBoxIcon.Information);
                        conn.Close();
                    }
                }
            }
            catch (Exception msg){
                MessageBox.Show("Item is already added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                /*MessageBox.Show(msg.ToString());
                throw;*/
            }
        }
    }
    
}
