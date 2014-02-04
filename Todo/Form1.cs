using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApplication6
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.CheckBoxes = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            loadTaskFromDatabase();
            loadCotactFromDatabase();
        }

        LinkedList<ToDoListItem> list = new LinkedList<ToDoListItem>();
        LinkedList<ContactItem> list2 = new LinkedList<ContactItem>();

        private void Form_listView()
        {
            listView1.Items.Add(new ListViewItem());
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                ToDoListItem todoItem = eachItem.Tag as ToDoListItem;
                list.Remove(todoItem);
                listView1.Items.Remove(eachItem);
                int id = todoItem.id;

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM [list] WHERE  Id =" + id, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }       
        }

        public void refreshTaskView()
        {
            listView1.Items.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
               if ((comboBox1.Text != String.Empty && list.ElementAt(i).type != comboBox1.Text) && comboBox1.Text != "All")
                {
                    continue;
                }
                DateTime date;
                if (checkBox1.Checked && DateTime.TryParse(list.ElementAt(i).date, out date))
                {
                    var difference = monthCalendar1.SelectionRange.Start - date;
                    if (difference.TotalDays > 0)
                    {
                        continue;
                    }
                }
                var item = new ListViewItem();                
                item.Text = "";
                item.Tag = list.ElementAt(i);
                item.Checked = list.ElementAt(i).check;

                item.SubItems.Add(list.ElementAt(i).type);
                item.SubItems.Add(list.ElementAt(i).todo);
                item.SubItems.Add(list.ElementAt(i).date);

                UpdateColors(list.ElementAt(i), item);
                                
                listView1.Items.Add(item);
                listView1.Tag = item;                
            }
        }

        private void UpdateColors(ToDoListItem toDoListItem, ListViewItem item)
        {
            DateTime dt;
            if (DateTime.TryParse(toDoListItem.date, out dt))
            {
                TimeSpan difference = dt - DateTime.Now;
                item.SubItems.Add(difference.Days.ToString());

                if (item.Checked)
                {
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Gray;
                }
                else
                {
                    item.ForeColor = Color.Black;
                    if (difference.TotalDays > 1)
                    {
                        item.BackColor = Color.Green;
                    }
                    else if (difference.TotalDays >= 0)
                    {
                        item.BackColor = Color.Yellow;
                    }
                    else
                    {
                        item.BackColor = Color.Red;
                    }
                }
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            (item.Tag as ToDoListItem).check = item.Checked;
            UpdateColors(item.Tag as ToDoListItem, item);
            int id = (item.Tag as ToDoListItem).id;
            int check = Convert.ToInt16((item.Tag as ToDoListItem).check);
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
            {
                conn.Open();
                using (var command = new SqlCommand("UPDATE [list] SET [Check] = @check WHERE Id =" + id, conn))
                {
                    command.Parameters.AddWithValue("@check", check);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void editTask_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ToDoListItem todo = listView1.SelectedItems[0].Tag as ToDoListItem;
                Form2 secondForm = new Form2(todo);
                if (secondForm.ShowDialog(this) == DialogResult.OK)
                {
                    int id = todo.id;
                    int check = Convert.ToInt16(todo.check);
                    string type = todo.type;
                    string task = todo.todo;
                    string date = todo.date;
                    refreshTaskView();
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
                    {
                        conn.Open();
                        using (var command = new SqlCommand("UPDATE [list] SET [Check]=@check, [Type]=@type, [Todo]=@task, [Date]=@date WHERE Id =" + id, conn))
                        {
                            command.Parameters.AddWithValue("@check", check);
                            command.Parameters.AddWithValue("@type", type);
                            command.Parameters.AddWithValue("@task", task);
                            command.Parameters.AddWithValue("@date", date);

                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                    }                
                }
            }
            else
            {
                MessageBox.Show("Select only one");
            }
         }

        private void editContact_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                ContactItem contact = listView2.SelectedItems[0].Tag as ContactItem;
                Form3 thirdForm = new Form3(contact);
                if (thirdForm.ShowDialog(this) == DialogResult.OK)
                {
                    int id = contact.id;
                    string name = contact.name;
                    string surname = contact.surname;
                    string phone = contact.phoneNumber;
                    string address = contact.address;
                    refreshContact();
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
                    {
                        conn.Open();
                        using (var command = new SqlCommand("UPDATE [contact] SET [Name]=@name, [Surname]=@surname, [PhoneNumber]=@phone, [Address]=@address WHERE Id =" + id, conn))
                        {
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@surname", surname);
                            command.Parameters.AddWithValue("@phone", phone);
                            command.Parameters.AddWithValue("@address", address);
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                    }                      
                }
            }
            else
            {
                MessageBox.Show("Select only one");
            }
        }

        private void addContact_Click(object sender, EventArgs e)
        {           
                ContactItem contact = new ContactItem(0,"","","","");
                Form3 thirdForm = new Form3(contact);
                if (thirdForm.ShowDialog(this) == DialogResult.OK)
                {
                    var item = new ListViewItem();
                    item.Tag = contact;
                    item.SubItems.Add(contact.name);
                    item.SubItems.Add(contact.surname);
                    item.SubItems.Add(contact.phoneNumber);
                    item.SubItems.Add(contact.address);
                    listView2.Items.Add(item);
                    list2.AddLast(contact);
                }
                writeContactsToDatabase();
        }

        public void refreshContact()
        {
            foreach (ListViewItem item in listView2.Items)
            {
                listView2.Items.Remove(item);
            }

            for (int i = 0; i <= list2.Count() - 1; i++)
            {
                var item = new ListViewItem();
                item.Tag = list2.ElementAt(i);
                item.SubItems.Add(list2.ElementAt(i).name);
                item.SubItems.Add(list2.ElementAt(i).surname);
                item.SubItems.Add(list2.ElementAt(i).phoneNumber);
                item.SubItems.Add(list2.ElementAt(i).address);
                listView2.Items.Add(item);
            }
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            ToDoListItem todo = new ToDoListItem(false, 0, "", "", "");
            Form2 secondForm = new Form2(todo);
            if (secondForm.ShowDialog(this) == DialogResult.OK)
            {
                var item = new ListViewItem();
                item.Tag = todo;
                item.Checked = todo.check;
                item.SubItems.Add(todo.type);
                item.SubItems.Add(todo.todo);
                if (!String.IsNullOrEmpty(todo.date))
                {
                    DateTime temp;
                    if (DateTime.TryParse(todo.date, out temp))
                    {
                        DateTime dt = DateTime.Parse(todo.date);
                        TimeSpan difference = dt - DateTime.Now;
                        item.SubItems.Add(todo.date);
                        item.SubItems.Add(difference.Days.ToString());
                    }
                }
                list.AddLast(todo);
                listView1.Items.Add(item);
                refreshTaskView();
                writeTasksToDatabase();               
            }
        }

        private void loadTaskFromDatabase()
        {           
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM list", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id  = reader.GetInt32(0);    
                        bool check = reader.GetBoolean(1);  
                        string type = reader.GetString(2);
                        string task = reader.GetString(3);
                        string date = reader.GetString(4);
                        ToDoListItem todo = new ToDoListItem(check, id, type, task, date);
                        list.AddLast(todo);
                    }                        
                }
            }
            refreshTaskView();           
        }


        private void loadCotactFromDatabase()
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM contact", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string phone = reader.GetString(3);
                        string address = reader.GetString(4);
                        ContactItem contact = new ContactItem(id, name, surname, phone, address);
                        list2.AddLast(contact);
                    }
                }
            }
            refreshContact();   
        }

        private void writeTasksToDatabase()
        {

            int check = Convert.ToInt16(list.Last().check);
            string type = list.Last().type;
            string todo = list.Last().todo;
            string date = list.Last().date.ToString();

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [list] ([Check], Type, Todo, Date) OUTPUT INSERTED.Id VALUES (@check, @type, @todo, @date)" , con);
                con.Open();
                command.Parameters.AddWithValue("@check", check);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@todo", todo);
                command.Parameters.AddWithValue("@date", date);
                int newId = (int)command.ExecuteScalar();
                list.Last().id = newId;               
                con.Close();
            }
        }

        private void writeContactsToDatabase()
        {
            string name = list2.Last().name;
            string surname = list2.Last().surname;
            string phone = list2.Last().phoneNumber;
            string address = list2.Last().address;

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [contact] (Name, Surname, PhoneNumber, Address) OUTPUT INSERTED.Id VALUES ( @name, @surname, @phone, @address)", conn);
                conn.Open();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                int newId = (int)command.ExecuteScalar();
                list2.Last().id = newId;
                conn.Close();
            }
        }

        private void deleteContact_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                ContactItem contact = eachItem.Tag as ContactItem;
                list2.Remove(contact);
                listView2.Items.Remove(eachItem);
                int id = contact.id;

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Roba\Documents\Visual Studio 2013\Projects\Todo+duomb\WindowsFormsApplication6\Database.mdf;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM [contact] WHERE  Id =" + id, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }   

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            refreshTaskView();
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (checkBox1.Checked)
            {
                refreshTaskView();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            refreshTaskView();
        }
    }
    
    public class ToDoListItem
    {
        public bool check { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string todo { get; set; }
        public string date { get; set; }

        public ToDoListItem(bool Check, int Id, string Type, string Todo, string Date)
        {
            check = Check;
            id = Id;
            type = Type;
            todo = Todo;
            date = Date;
        }
    }
    public class ContactItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }

    
        public ContactItem(int id, string name, string surname, string phoneNumber, string address)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

    }
}


