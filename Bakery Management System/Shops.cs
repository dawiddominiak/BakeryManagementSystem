using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BakeryManagementSystem.HelperClasses;
using Controller.Shop;
using Domain.Shop;
using Shared.Structs;

namespace BakeryManagementSystem
{
    public partial class Shops : Form
    {
        public List<Control> ShopBasicTextBoxes { get; set; }
        public List<Control> ShopBasicButtons { get; set; }
        public List<Control> ShopModificationButtons { get; set; }
        public List<Control> ShopPhoneTextBoxes { get; set; }
        public List<Control> ShopPhoneButtons { get; set; }
        public Shop CurrentShop { get; set; }
        public Phone? CurrentShopPhone { get; set; }
        public ShopController ShopController { get; set; } = new ShopController();

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
                savePhoneButton,
                removePhoneButton
            };
            //TODO: refresh function
        }

        #region Helpers
        private void NewCurrentShop()
        {
            CurrentShop = new Shop(ShopController.NextShopId());
        }
        #endregion


        private void addNewShop_Click(object sender, EventArgs e)
        {
            ControlsManager.SwitchButtons(ShopBasicButtons, true);
            ControlsManager.SwitchButtons(ShopModificationButtons, true);
            ControlsManager.SwitchButtons(ShopBasicTextBoxes, true);
            ControlsManager.SwitchButtons(ShopPhoneTextBoxes, false);
            ControlsManager.SwitchButtons(ShopPhoneButtons, false);
            NewCurrentShop();
            //TODO: refresh phone list function
        }


    }
}
