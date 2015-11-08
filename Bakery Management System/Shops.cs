using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Shop;
using Shared.Structs;

namespace BakeryManagementSystem
{
    public partial class Shops : Form
    {
        public List<Control> ShopBasicTextBoxes { get; set; } = new List<Control>();
        public List<Control> ShopBasicButtons { get; set; } = new List<Control>();
        public List<Control> ShopModificationButtons { get; set; } = new List<Control>();
        public List<Control> ShopPhoneTextBoxes { get; set; } = new List<Control>();
        public List<Control> ShopPhoneButtons { get; set; } = new List<Control>();
        public Shop CurrentShop { get; set; }
        public Phone? CurrentShopPhone { get; set; }

        public Shops()
        {
            InitializeComponent();
            ShopBasicTextBoxes = new List<Control>
            {
                codeTextBox,
                nameTextBox,
                ownerComboBox,
                streetTextBox,
                postalCodeTextBox,
                cityTextBox,
                countryTextBox
            };
            ShopBasicButtons = new List<Control>
            {
                savePhoneButton,
                removePhoneButton,
                addNewPhoneButton
            };
            ShopModificationButtons = new List<Control>
            {
                saveShopButton,
                deleteShopButton
            };
            ShopPhoneTextBoxes = new List<Control>
            {
                countryPartTextBox,
                areaPartTextBox,
                numberPartTextBox
            };
            ShopPhoneButtons = new List<Control>
            {
                addNewPhoneButton,
                removePhoneButton
            };
            //TODO: refresh function
        }

        private void addNewShop_Click(object sender, EventArgs e)
        {

        }
    }
}
