using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form3 : Form
    {
        ContactItem item = null;
        public Form3(ContactItem item)
        {
            InitializeComponent();
            this.item = item;
            Edit();
        }

        public void Edit()
        {
            name2.Text = item.name;
            surname.Text = item.surname;
            phone.Text = item.phoneNumber;
            address.Text = item.address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.name = name2.Text;
            item.surname = surname.Text;
            item.phoneNumber = phone.Text;
            item.address = address.Text;        
        }
    }
}
