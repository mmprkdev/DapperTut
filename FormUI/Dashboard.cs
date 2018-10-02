using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        List<Person> people;

        public Dashboard()
        {
            InitializeComponent();

            UpdateListBoxBinding(peopleFoundListBox, people, "FirstAndLastName");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var db = new DataAccess();

            people = db.GetPeople(lastNameText.Text);
            UpdateListBoxBinding(peopleFoundListBox, people, "FullData");

        }

        private void UpdateListBoxBinding(ListBox listbox, List<Person> list, string displayMember)
        {
            listbox.DataSource = list;
            listbox.DisplayMember = displayMember;
        }

        // TODO: Get rid of this.
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            var db = new DataAccess();

            db.InsertPerson(firstNameInsText.Text, lastNameInsText.Text, emailInsText.Text, phoneNumberInsText.Text);

            firstNameInsText.Text = "";
            lastNameInsText.Text = "";
            emailInsText.Text = "";
            phoneNumberInsText.Text = "";
        }
    }
}
