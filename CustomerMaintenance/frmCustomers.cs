using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ************************************************
 * CIS123: Intro to Object-oriented Programming
 * Murach C#, 7th ed. pp. 456 - 458
 * Chapter 13: How to work with indexers
 *    delegates, events & operators
 * Dominique Tepper, 17JUN2022
 * 
 * Exercise 13-1
 * 7a. Modify frmCustomers to use CustomerList class.
 * 7b. Use CustomerList object Fill()
 * 7c. Use CustomerList object Save()
 * 7d. Use a for loop instead of foreach
 * 
 * Exercise 13-2
 * 3. Modify frmCustomer to use operator instead of
 *    methods
 *    a. Add()
 *    b. Remove()
 * ************************************************/

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        //7a. Modify frmCustomers to use CustomerList class.
        private CustomerList customers = new CustomerList();

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            //7b.Use CustomerList object Fill()
            //Tepper, 17JUN2022
            customers.Fill();
            FillCustomerListBox();
        }

        private void FillCustomerListBox()
        {
            lstCustomers.Items.Clear();

            //7d.Use a for loop instead of foreach
            //Tepper, 17JUN2022
            for (int i = 0; i < customers.Count; i++)
            {
                Customer c = customers[i];
                lstCustomers.Items.Add(c.GetDisplayText());
            }
        }
/* ************************************************
* CIS123: Intro to Object-oriented Programming
* Murach C#, 7th ed. pp. 456 - 458
* Chapter 13: How to work with indexers
*    delegates, events & operators
* Dominique Tepper, 17JUN2022
* 
* Exercise 13-2
* 3. Modify frmCustomer to use operator instead of
*    methods
*    a. Add()
*    b. Remove()
* ************************************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer addCustomerForm = new frmAddCustomer();
            Customer customer = addCustomerForm.GetNewCustomer();
            if (customer != null)
            {
                
                //Ex13-2.3a + operator
                //Tepper, 17JUN2022
                customers += customer;

                //7c.CustomerList object Save()
                //Tepper, 17JUN2022
                customers.Save();

                FillCustomerListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstCustomers.SelectedIndex;
            if (i != -1)
            {
                Customer customer = (Customer)customers[i];
                string message = "Are you sure you want to delete "
                    + customer.FirstName + " " + customer.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    //Ex13-2.3b - operator
                    //Tepper, 17JUN2022
                    customers -= customer;

                    //7c.CustomerList object Save()
                    //Tepper, 17JUN2022
                    customers.Save();
                    
                    FillCustomerListBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
