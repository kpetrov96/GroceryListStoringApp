using GroceryListStoringApp.DomainClasses;
using NHibernate;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryListStoringApp
{
    class LoadFromDB
    {
        Users user = new Users();
        public LoadFromDB(Users user) {
            this.user = user;
        }

        //Load All Items to ComboBox2
        public List<String> Load_Items_List()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Grocery_Item> grocereriesItemsAll = session.Query<Grocery_Item>().ToList();
                    List<String> groceriesDescription = new List<String>();

                    for (var i = 0; i < grocereriesItemsAll.Count; i++)
                    {
                        groceriesDescription.Add(grocereriesItemsAll[i].item_description.ToString());
                    }
                    return groceriesDescription;
                }
            }
            catch (Exception msg){
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        //Load All Lists to ComboBox1
        public List<String> Load_Grocery_List(string permissionList)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Grocery_List> grocereriesListAll = session.Query<Grocery_List>().ToList();
                    List<String> listsForPublic = new List<String>();
                    List<String> listsForPrivate = new List<String>();
                    List<String> listsForShared = new List<String>();

                    for (var i = 0; i < grocereriesListAll.Count; i++)
                    {
                        if (grocereriesListAll[i].permissions == "public"){
                            listsForPublic.Add(grocereriesListAll[i].id_grocery_list.ToString());
                        }
                        else if (grocereriesListAll[i].id_user_fk == user.id_user){
                            listsForPrivate.Add(grocereriesListAll[i].id_grocery_list.ToString());
                        }
                        else if (grocereriesListAll[i].permissions == "shared" && grocereriesListAll[i].id_user_fk != user.id_user){
                            listsForShared.Add(grocereriesListAll[i].id_grocery_list.ToString());
                        }
                    }

                    if (permissionList == "public")
                    { return listsForPublic; }
                    else if (permissionList == "private")
                    { return listsForPrivate; }
                    else if (permissionList == "shared")
                    { return listsForShared; }
                    else { return listsForPublic; }
                }
            }
            catch (Exception msg){
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        //Load All items from list into DataGridView1
        public List<Grocery_Item> Load_Data_Grid(string selected)
        {
            try
            {
                //NHibernate Grocery_Store Query error  
                /*using (ISession session = NHibernateHelper.OpenSession()){
                        List<Grocery_Store> grocereriesStore = session.Query<Grocery_Store>().ToList();
                        List<Grocery_Store> listsForGrid = new List<Grocery_Store>();

                    for (int i = 0; i < grocereriesStore.Count; i++){
                        for (int i = 0; i < groceriesStore.Count; i++){
                             if (groceriesStore[i].id_grocery_list_fk.ToString() == selected){
                                listsForId.Add(groceriesStore[i]);
                             }
                        }
                    }
                }*/

                //NpgSqlCommand used
                List<Grocery_Store> groceriesStore = new List<Grocery_Store>();
                List<Grocery_Store> listsForId = new List<Grocery_Store>();

                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1 ; Port=5432 ; User Id=postgres; Password=root; Database=GroceryListStoringDB;");
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(" SELECT * FROM \"Grocery_Store\"", conn);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                //Filling grocereriesStore list from DB
                for (int i = 0; dataReader.Read(); i++){
                    Grocery_Store grocery = new Grocery_Store { id_grocery_list_fk = Int32.Parse(dataReader[0].ToString()), id_grocery_item_fk = Int32.Parse(dataReader[1].ToString()) };
                    groceriesStore.Add(grocery);
                }

                //Finding selected list items
                for (int i = 0; i < groceriesStore.Count; i++){
                    if (groceriesStore[i].id_grocery_list_fk.ToString() == selected){
                        listsForId.Add(groceriesStore[i]);
                    }
                }
                conn.Close();

                using (ISession session = NHibernateHelper.OpenSession())
                {
                    List<Grocery_Item> grocereriesItemsAll = session.Query<Grocery_Item>().ToList();
                    List<Grocery_Item> groceriesList = new List<Grocery_Item>();

                    //Find grocery items description 
                    for (int i = 0; i < listsForId.Count; i++){
                        for (int j = 0; j < grocereriesItemsAll.Count; j++){
                            if (listsForId[i].id_grocery_item_fk == grocereriesItemsAll[j].id_grocery_item){
                                groceriesList.Add(grocereriesItemsAll[j]);
                            }
                        }
                    }
                    return groceriesList;
                }
            }
            catch (Exception msg){
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
