using GroceryListStoringApp.DomainClasses;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryListStoringApp
{
    public partial class InsertItemForm : Form
    {
        public InsertItemForm()
        {
            InitializeComponent();
        }

        //Add new item to DB
        private void button4_Click(object sender, EventArgs e)
        {
            int n = 0;
            string item = textBoxItem.Text;

            if (item == "")
            {
                MessageBox.Show("Please enter item name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (ISession session = NHibernateHelper.OpenSession())
                    {
                        List<Grocery_Item> groceryItems = session.Query<Grocery_Item>().ToList();

                        for (var i = 0; i < groceryItems.Count; i++){
                            if (groceryItems[i].item_description == item){
                                MessageBox.Show(item + " exists. Enter new one!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                n++;
                            }
                        }

                        if (n == 0){
                            var new_item = new Grocery_Item { item_description = item };
                            using (ITransaction transaction = session.BeginTransaction())
                            {
                                session.Save(new_item);
                                transaction.Commit();
                            }
                            MessageBox.Show("Grocery Item " + item + " Created. You can add it to your list!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception msg){
                    MessageBox.Show("Unable to create item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    /*MessageBox.Show(msg.ToString());
                    throw;*/
                }
            }
            this.Close();
        }
    }
}
