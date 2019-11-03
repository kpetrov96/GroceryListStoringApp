using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroceryListStoringApp.DomainClasses;
using GroceryListStoringApp.MappingClasses;
using GroceryListStoringApp.RepositoryInteractions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Npgsql;

namespace GroceryListStoringApp
{
    public partial class Form1 : Form
    {
        Users user;
        LoadFromDB db;
        CreateUser cr_user;
        AddItemToList add_item;
        UserLogin user_login;
        public Form1()
        {
            InitializeComponent();
            EnableDisable(1);

            user = new Users();
            db = new LoadFromDB(user);
            cr_user = new CreateUser();
            add_item = new AddItemToList();
            user_login = new UserLogin();
            comboBox1.DataSource = db.Load_Grocery_List("public");
        }
        
        //Login 
        private void button1_Click(object sender, EventArgs e)
        {
            user = null;
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            user = user_login.UserLoginCheck(username, password);
            
            if (user == null){
                EnableDisable(1);
            }
            else {
                EnableDisable(0);
                label3.Text = "Username: " + user.username;
                db = new LoadFromDB(user);
                comboBox2.DataSource = db.Load_Items_List();
            }
            CleanBox();
        }

        //New User Create
        private void button3_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (username == "" || password == ""){ 
                MessageBox.Show("Username or password is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else{
                cr_user.CreateNewUser(username, password);
                CleanBox();
            }
        }

        //New Item create
        private void button4_Click(object sender, EventArgs e)
        {
            InsertItemForm form1 = new InsertItemForm();
            form1.ShowDialog();
        }

        //New Grocery list
        private void button5_Click(object sender, EventArgs e)
        {
            CreateListForm form1 = new CreateListForm(user);
            form1.ShowDialog();
        }

        //Load DataGrid on ComboBox Selection
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            dataGridView1.DataSource = db.Load_Data_Grid(selected);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Items";
        }

        //Exit user button
        private void button2_Click(object sender, EventArgs e)
        {
            user = null;
            EnableDisable(1);
            dataGridView1.DataSource = null;
            comboBox1.DataSource = null;
        }

        //Load Grocer List with permission public/private/shared
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            comboBox1.DataSource = null;
            
            if (radioButton1.Checked){
                comboBox1.DataSource = db.Load_Grocery_List("public");
                label4.Text = "Public Grocery Lists";
                button6.Enabled = false;
            }
            else if (radioButton2.Checked){
                comboBox1.DataSource = db.Load_Grocery_List("private");
                label4.Text = "User Grocery Lists";
                button6.Enabled = true;
            }
            else if (radioButton3.Checked){
                comboBox1.DataSource = db.Load_Grocery_List("shared");
                label4.Text = "Shared from other \n users Grocery Lists";
                button6.Enabled = false;
            }
        }

        //Add Item to list
        private void button6_Click(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string selected2 = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);

            add_item.AddNewItemToList(selected, selected2);

            dataGridView1.DataSource = db.Load_Data_Grid(selected);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Items";
        }

        private void EnableDisable(int n)
        {
            if (n == 1){
                label1.Show();
                label2.Show();
                usernameBox.Show();
                passwordBox.Show();
                button1.Show();
                button3.Show();
                button2.Hide();
                label5.Hide();
                label3.Hide();
                button5.Hide();
                groupBox1.Hide();
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                button6.Enabled = false;
                comboBox1.DataSource = null;
            }
            else if (n == 0){
                usernameBox.Hide();
                passwordBox.Hide();
                button1.Hide();
                button3.Hide();
                button2.Show();
                label5.Show();
                label3.Show();
                button5.Show();
                groupBox1.Show();
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                comboBox1.DataSource = null;
            }
        }

        private void CleanBox()
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }
    }


}
