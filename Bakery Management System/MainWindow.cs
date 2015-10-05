using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, Form> ChildWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ChildWindow = new Dictionary<string, Form>();
        }

        private void newWorkingDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void assortmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form assortmentWindow;
            if(!ChildWindow.TryGetValue("Assortment", out assortmentWindow))
            {
                assortmentWindow = new Assortment();
                ChildWindow.Add("Assortment", assortmentWindow);
            }
            if(!assortmentWindow.Visible)
            {
                assortmentWindow.Show(this);
            }
        }
    }
}
