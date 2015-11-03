using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using Controller.Shop;
using Domain.Shop;
using Shared.Structs;

namespace BakeryManagementSystem
{
    public partial class Shops : Form
    {
        public List<Control> OwnerBasicTextBoxes { get; set; }
        public List<Control> OwnerBasicButtons { get; set; }
        public List<Control> OwnerPhoneTextBoxes { get; set; }
        public List<Control> OwnerPhoneButtons { get; set; }
        public OwnerController OwnerController { get; set; }
        public Owner CurrentOwner { get; set; }
        public Phone? CurrentOwnerPhone { get; set; }

        public Shops()
        {
            InitializeComponent();
            OwnerBasicTextBoxes = new List<Control>()
            {
                codeTextBox,
                nameTextBox,
                taxIdentificationNumberTextBox,
                nationalEconomyRegisterTextBox,
                streetTextBox,
                postalCodeTextBox,
                cityTextBox,
                countryTextBox
            };

            OwnerBasicButtons = new List<Control>()
            {
                saveOwnerButton,
                removeOwnerButton,
                addNewPhoneButton
            };

            OwnerPhoneTextBoxes = new List<Control>()
            {
                countryPartTextBox,
                areaPartTextBox,
                numberTextBox
            };

            OwnerPhoneButtons = new List<Control>()
            {
                addPhoneButton,
                removePhoneButton
            };

            OwnerController = new OwnerController();
        }

        #region Helpers

        private void SwitchButtons(IEnumerable<Control> controlList, bool enabled)
        {
            foreach (var control in controlList)
            {
                control.Enabled = enabled;
            }
        }

        private void EmptyButtons(IEnumerable<Control> controlList)
        {
            foreach (var control in controlList)
            {
                control.Text = "";
            }
        }

        private void RefreshOwnerPhoneListBox()
        {
            var list = new List<Phone>(CurrentOwner.Phones);
            ownerPhonesListBox.DataSource = list;
        }

        private void NewCurrentOwner()
        {
            CurrentOwner = new Owner(OwnerController.NextOwnerId());            
        }

        private void EnsureCurrentOwner()
        {
            if (CurrentOwner == null)
            {
                NewCurrentOwner();
            }    
        }

        #endregion

        private void Shops_Load(object sender, EventArgs e)
        {

        }

        #region Owner phones management

        private void addNewPhoneButton_Click(object sender, EventArgs e)
        {
            SwitchButtons(OwnerPhoneTextBoxes, true);
            SwitchButtons(OwnerPhoneButtons, true);
            EmptyButtons(OwnerPhoneTextBoxes);
            CurrentOwnerPhone = null;
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            SwitchButtons(OwnerPhoneTextBoxes, false);
            SwitchButtons(OwnerPhoneButtons, false);

            var newPhone = new Phone(countryPartTextBox.Text, areaPartTextBox.Text, numberTextBox.Text);

            if (CurrentOwner.Phones == null)
            {
                CurrentOwner.Phones = new List<Phone>();
            }

            if (CurrentOwnerPhone != null)
            {
                CurrentOwner.Phones.Remove(CurrentOwnerPhone.Value);
            }

            CurrentOwner.Phones.Add(newPhone);
            RefreshOwnerPhoneListBox();

        }

        private void ownerPhonesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerPhonesListBox.SelectedItem == null)
            {
                return;
            }

            CurrentOwnerPhone = (Phone) ownerPhonesListBox.SelectedItem;

            countryPartTextBox.Text = CurrentOwnerPhone.Value.CountryCode;
            areaPartTextBox.Text = CurrentOwnerPhone.Value.RegionalCode;
            numberTextBox.Text = CurrentOwnerPhone.Value.Number;

            SwitchButtons(OwnerPhoneTextBoxes, true);
            SwitchButtons(OwnerPhoneButtons, true);
        }

        private void removePhoneButton_Click(object sender, EventArgs e)
        {
            if (CurrentOwnerPhone == null)
            {
                return;
            }

            CurrentOwner.Phones.Remove(CurrentOwnerPhone.Value);
            RefreshOwnerPhoneListBox();
        }

        #endregion

        private void addNewOwner_Click(object sender, EventArgs e)
        {
            SwitchButtons(OwnerBasicTextBoxes, true);
            SwitchButtons(OwnerBasicButtons, true);
            EmptyButtons(OwnerBasicTextBoxes);
            NewCurrentOwner();
        }

        private void saveOwnerButton_Click(object sender, EventArgs e)
        {
            EnsureCurrentOwner();

            Mapper.CreateMap<Shops, Owner>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.codeTextBox.Text))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.nameTextBox.Text))
                .ForMember(dest => dest.TaxIdentificationNumber, opt => opt.MapFrom(src => src.taxIdentificationNumberTextBox.Text))
                .ForMember(dest => dest.NationalEconomyRegister, opt => opt.MapFrom(src => src.nationalEconomyRegisterTextBox.Text))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(
                    streetTextBox.Text, postalCodeTextBox.Text, cityTextBox.Text, countryTextBox.Text
                )))
                .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.ownerPhonesListBox.Items.Cast<Phone>().ToList()))
            ;

            Mapper.Map(this, CurrentOwner);

            OwnerController.Save(CurrentOwner);
        }

    }
}
