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
    public partial class CreateListForm : Form
    {
        Users user = new Users();
        string selectedRB;
        public CreateListForm(Users user)
        {
            InitializeComponent();
            this.user = user;
        }

        //Create new grocery list
        private void button1_Click(object sender, EventArgs e)
        {
            try{
                if (radioButton1.Checked){
                    selectedRB = "public";
                }
                else if (radioButton2.Checked){
                    selectedRB = "private";
                }
                else if (radioButton3.Checked){
                    selectedRB = "shared";
                }

                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var new_list = new Grocery_List { id_user_fk = user.id_user, permissions = selectedRB };

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(new_list);
                        transaction.Commit();
                    }
                    MessageBox.Show("Grocery list created. You can add items to your list!", "Informatio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception msg){
                MessageBox.Show("Error creating list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /* MessageBox.Show(msg.ToString());
                 throw;*/
            }
            this.Close();
        }
    }
}
