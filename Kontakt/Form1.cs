using Kontakt.Konakter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Kontakt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Person> ppl = new List<Person>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Update();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // objeket som kommer åt egenskaperna 
            var obj = new Person();
            obj.Name = txtName.Text;
            obj.Addres = txtAddres.Text;
            obj.Phone= txtPhone.Text;
            obj.ZipCode = txtZipCode.Text;
            obj.City = txtCity.Text;
            obj.Email = txtEmail.Text;
            obj.Birthday = DTP.Value;
            using (var context = new PersonContext())
            {
                context.contact.Add(obj);
                context.SaveChanges();
            }
            ClearTextBox();
            Update();
        }
        private void ClearTextBox()
        {
            txtName.Clear();
            txtAddres.Clear();
            txtPhone.Clear();
            txtZipCode.Clear();
            txtCity.Clear();
            txtEmail.Clear();
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Information.SelectedIndex >=0)
                {
                    Person obj2 = ppl[Information.SelectedIndex];
                    using (var dbContext = new PersonContext())
                    {
                        dbContext.Entry(obj2).State = System.Data.Entity.EntityState.Deleted;
                        dbContext.SaveChanges();
                    }
                    ClearTextBox();
                    Update();
                }
                //Person obj2 = ppl[Information.SelectedIndex];
                //using (var dbContext = new PersonContext())
                //{
                //    dbContext.Entry(obj2).State = System.Data.Entity.EntityState.Deleted;
                //    dbContext.SaveChanges();
                //}
                //ClearTextBox();
                //Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show( "" + ex);
            }
            //Person obj2 = ppl[Information.SelectedIndex];
            //using (var dbContext = new PersonContext())
            //{
            //    dbContext.Entry(obj2).State = System.Data.Entity.EntityState.Deleted;
            //    dbContext.SaveChanges();
            //}
            //ClearTextBox();
            //Update();
        }
        private void Update()
        {
            Information.Items.Clear();
            using (var context = new PersonContext())
            {
                var x = context.contact.Select(s => s);
                foreach (var item in context.contact)
                {
                    ppl.Add(item);
                    Information.Items.Add(item.PersonId + " " + item.Name);
                }
            }
        }

        private void Information_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string contact = Information.SelectedItem.ToString();
                contact.Split(' ');
                string id = contact[0].ToString();
                int id2 = int.Parse(id);
                using (var context = new PersonContext())
                {
                    var character = (from s in context.contact
                                     where s.PersonId == id2
                                     select s).First();
                    txtName.Text = character.Name;
                    txtAddres.Text = character.Addres;
                    txtPhone.Text = character.Phone;
                    txtZipCode.Text = character.ZipCode;
                    txtCity.Text = character.City;
                    txtEmail.Text = character.Email;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("" + x);
            }
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            if (Information.SelectedItem != null)
            {
                Person person = ppl[Information.SelectedIndex];
                person.Name = txtName.Text;
                person.Addres = txtAddres.Text;
                person.Phone = txtPhone.Text;
                person.ZipCode = txtZipCode.Text;
                person.City = txtCity.Text;
                person.Email = txtEmail.Text;
                person.Birthday = DTP.Value;
                Information.Items.Add(person.Name);
                using (var dbContext = new PersonContext())
                {
                        dbContext.Entry(person).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                }
                ppl.Clear();
                ClearTextBox();
                Update();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            using (var context = new PersonContext())
            {
                Information.Items.Clear();
                if (cmdSearch != null)
                {
                    var resultat = (from s in context.contact
                                    where s.Name.ToLower().Contains(txtSearch.Text)
                                    select s).ToList();
                    foreach (var item in resultat)
                    {
                        Information.Items.Add(item.Name);
                    }
                 }
            }
        }
    }
}
