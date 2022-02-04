using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiringMusicDatabaseManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer a = new Customer();
            a.Visible = true;
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales a = new Sales();
            a.Visible = true;
        }

        private void rentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rentals a = new Rentals();
            a.Visible = true;
        }

        private void returnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Returns a = new Returns();
            a.Visible = true;
        }
    }
}
