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
        public Product? CurrentProduct { get; set; }
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

            var product = new Product(
                codeTextBox.Text,
                nameTextBox.Text,
                new TaxRate(taxRate)
            );

            if (CurrentProduct != null)
            {
                Controller.Edit(CurrentProduct.Value.Code, product);
            }
            else
            {
                Controller.Add(product);
                CurrentProduct = product;
            }

            ReloadProducts(product);
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
            codeTextBox.Text = CurrentProduct.Value.Code;
            nameTextBox.Text = CurrentProduct.Value.Name;
            taxRateTextBox.Text = CurrentProduct.Value.TaxRate.Rate.ToString(CultureInfo.CurrentCulture);
        }
        #endregion

        #region Helpers
        private void ReloadProducts(Product? selected = null)
        {
            Products = Controller.Get().Products;
            productListBox.DataSource = Products
                .Select(e => new KeyValuePair<string, string>(e.Code, e.Name))
                .ToList();
            
            if (selected != null)
            {
                var index = Products.FindIndex(el => el.Code == selected.Value.Code);
                
                productListBox.SetSelected(index, true);
            }
        }

        private void SwitchButtons(bool enabled)
        {
            saveButton.Enabled = enabled;
            foreach (var textBox in TextBoxes)
            {
                textBox.Enabled = enabled;
            }
        }
        #endregion
    }
}
