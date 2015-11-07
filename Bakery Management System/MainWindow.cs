using System;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void assortmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var assortmentWindow = new Assortment();
            assortmentWindow.ShowDialog(this);
        }
        
        private void ownersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ownersWindow = new Owners();
            ownersWindow.ShowDialog(this);
        }

        private void shopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var shopsWindow = new Shops();
            shopsWindow.ShowDialog(this);
        }
    }
}
