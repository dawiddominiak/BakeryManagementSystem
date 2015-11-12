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

        private void RefreshShopPhoneListBox()
        {
            if (CurrentShop == null) return;
            var list = CurrentShop.Phones ?? new List<Phone>();
            phonesListBox.DataSource = new List<Phone>(list);
            //TODO: consider phonesListBox.Refresh();
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

        private void addNewPhoneButton_Click(object sender, EventArgs e)
        {
            ControlsManager.SwitchButtons(ShopPhoneTextBoxes, true);
            ControlsManager.SwitchButtons(ShopPhoneButtons, true);
            ControlsManager.EmptyButtons(ShopPhoneTextBoxes);
            CurrentShopPhone = null;
        }

        //TODO: IPhoneManagement interface or abstract class
        private void savePhoneButton_Click(object sender, EventArgs e)
        {
            ControlsManager.SwitchButtons(ShopPhoneTextBoxes, false);
            ControlsManager.SwitchButtons(ShopPhoneButtons, false);

            var newPhone = new Phone(countryPartTextBox.Text, areaPartTextBox.Text, numberPartTextBox.Text);

            if (CurrentShop.Phones == null)
            {
                CurrentShop.Phones = new List<Phone>();
            }

            if (CurrentShopPhone != null)
            {
                CurrentShop.Phones.Add(newPhone);
            }

            CurrentShop.Phones.Add(newPhone);
            RefreshShopPhoneListBox();
            phonesListBox.SelectedItem = newPhone;
        }

        private void phonesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phonesListBox.SelectedItem == null)
            {
                return;
            }

            CurrentShopPhone = (Phone) phonesListBox.SelectedItem;

            countryPartTextBox.Text = CurrentShopPhone.Value.CountryCode;
            areaPartTextBox.Text = CurrentShopPhone.Value.RegionalCode;
            numberPartTextBox.Text = CurrentShopPhone.Value.Number;

            ControlsManager.SwitchButtons(ShopPhoneTextBoxes, true);
            ControlsManager.SwitchButtons(ShopPhoneTextBoxes, true);
        }
    }
}
