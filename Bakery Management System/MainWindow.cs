using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newWorkingDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void assortmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var assortmentWindow = new Assortment();
            assortmentWindow.ShowDialog(this);
        }

    }
}
