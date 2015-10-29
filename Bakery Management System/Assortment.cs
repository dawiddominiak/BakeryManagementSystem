using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Controller.Assortment;
using Domain.Assortment;

namespace BakeryManagementSystem
{
    public partial class Assortment : Form
    {
        public Product CurrentProduct { get; set; }
        public List<TextBox> TextBoxes { get; set; }
        public ProductController Controller { get; set; }
        public List<Product> Products { get; set; } 
        
        public Assortment()
        {
            CurrentProduct = null;
            InitializeComponent();
            TextBoxes = new List<TextBox>
            {
                codeTextBox,
                nameTextBox,
                taxRateTextBox
            };
            Controller = new ProductController();
            ReloadProducts();
        }

        #region Events
        private void addNewButton_Click(object sender, EventArgs e)
        {
            CurrentProduct = null;
            TextBoxes.ForEach(el => el.Text = "");
            productListBox.ClearSelected();

            SwitchButtons(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            decimal taxRate;
            decimal.TryParse(taxRateTextBox.Text, out taxRate);

            if (CurrentProduct == null)
            {
                CurrentProduct = new Product
                {
                    Id = Controller.NextProductId()
                };
            }

            CurrentProduct.Code = codeTextBox.Text;
            CurrentProduct.Name = nameTextBox.Text;
            CurrentProduct.TaxRate = new TaxRate(taxRate);

            Controller.Save(CurrentProduct);
            ReloadProducts(CurrentProduct);
        }

        private void productListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productListBox.SelectedItem == null)
            {
                return;
            }

            var current = (KeyValuePair<string, string>)productListBox.SelectedItem;
            CurrentProduct = Products.Find(q => q.Code == current.Key);
            SwitchButtons(true);
            codeTextBox.Text = CurrentProduct.Code;
            nameTextBox.Text = CurrentProduct.Name;
            taxRateTextBox.Text = CurrentProduct.TaxRate.Rate.ToString(CultureInfo.CurrentCulture);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            productListBox.ClearSelected();
            if (CurrentProduct == null)
            {
                return;
            }

            Controller.Remove(CurrentProduct);
            CurrentProduct = null;
            ReloadProducts();
        }
        #endregion

        #region Helpers
        private void ReloadProducts(Product selected = null)
        {
            Products = Controller.GetAll();
            productListBox.DataSource = Products
                .Select(e => new KeyValuePair<string, string>(e.Code, e.Name))
                .ToList();

            if (selected == null)
            {
                return;
            }
            
            var index = Products.FindIndex(el => el.Code == selected.Code);
                
            productListBox.SetSelected(index, true);
        }

        private void SwitchButtons(bool enabled)
        {
            saveButton.Enabled = enabled;
            deleteButton.Enabled = enabled;
            foreach (var textBox in TextBoxes)
            {
                textBox.Enabled = enabled;
            }
        }
        #endregion

    }
}
