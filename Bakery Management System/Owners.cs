using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using BakeryManagementSystem.Properties;
using Controller.Shop;
using Controller.Tools;
using Domain.Shop;
using Shared.Exceptions;
using Shared.Logger;
using Shared.Structs;

namespace BakeryManagementSystem
{
    public partial class Owners : Form
    {
        public List<Control> OwnerBasicTextBoxes { get; set; }
        public List<Control> OwnerBasicButtons { get; set; }
        public List<Control> OwnerPhoneTextBoxes { get; set; }
        public List<Control> OwnerPhoneButtons { get; set; }
        public OwnerController OwnerController { get; set; } = new OwnerController();
        public LoggerController LoggerController { get; set; } = new LoggerController();
        public Owner CurrentOwner { get; set; }
        public Phone? CurrentOwnerPhone { get; set; }

        public Owners()
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

            RefreshOwnerList();
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

        private void FillButtons(Owner owner)
        {
            if (owner != null)
            {
                codeTextBox.Text = owner.Code;
                nameTextBox.Text = owner.Name;
                taxIdentificationNumberTextBox.Text = owner.TaxIdentificationNumber;
                nationalEconomyRegisterTextBox.Text = owner.NationalEconomyRegister;
                streetTextBox.Text = owner.Address.Street;
                postalCodeTextBox.Text = owner.Address.PostalCode;
                cityTextBox.Text = owner.Address.City;
                countryTextBox.Text = owner.Address.Country;
            }
            
            RefreshOwnerPhoneListBox();
        }

        private void RefreshOwnerPhoneListBox()
        {
            if (CurrentOwner == null) return;
            var list = CurrentOwner.Phones ?? new List<Phone>();
            ownerPhonesListBox.DataSource = new List<Phone>(list);
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

        private void RefreshOwnerList()
        {
            ownerListBox.DataSource = OwnerController.GetAll();
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
            ownerPhonesListBox.SelectedItem = newPhone;
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
            SwitchButtons(OwnerPhoneTextBoxes, false);
            SwitchButtons(OwnerPhoneButtons, false);
            EmptyButtons(OwnerBasicTextBoxes);
            EmptyButtons(OwnerPhoneTextBoxes);
            NewCurrentOwner();
            RefreshOwnerPhoneListBox();
        }

        private void saveOwnerButton_Click(object sender, EventArgs e)
        {
            EnsureCurrentOwner();

            Mapper.CreateMap<Owners, Owner>()
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
            var newOwner = CurrentOwner;

            try
            {
                OwnerController.Save(CurrentOwner);
                RefreshOwnerList();
                ownerListBox.SelectedItem = ownerListBox
                    .Items
                    .Cast<Owner>()
                    .ToList()
                    .FirstOrDefault(owner => owner.Id.Equals(newOwner.Id));
            }
            catch (RepositoryException ex)
            {
                var logManager = LoggerController.Manager;
                Exception last = ex;

                while (last.InnerException != null)
                {
                    last = last.InnerException;
                }

                logManager.NewLog(
                    new Warning("There is a problem with repository: " + last.Message, ex.StackTrace)
                );
            }
        }

        private void ownerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmptyButtons(OwnerPhoneTextBoxes);
            SwitchButtons(OwnerPhoneTextBoxes, false);
            SwitchButtons(OwnerPhoneButtons, false);
            CurrentOwner = (Owner)ownerListBox.SelectedItem;
            FillButtons(CurrentOwner);
            SwitchButtons(OwnerBasicTextBoxes, true);
            SwitchButtons(OwnerBasicButtons, true);
        }

        private void removeOwnerButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                Resources.Shops_removeOwnerButton_Click_Are_you_sure_that_you_want_to_delete_owner__ + @" " + CurrentOwner.Name,
                Resources.Shops_removeOwnerButton_Click_Delete + @" " + CurrentOwner.Name,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
                ) == DialogResult.Yes)
            {
                try
                {
                    OwnerController.Remove(CurrentOwner);
                    RefreshOwnerList();
                }
                catch (RepositoryException ex)
                {
                    //TODO: upgrade this code
                    var logManager = LoggerController.Manager;
                    Exception last = ex;

                    while (last.InnerException != null)
                    {
                        last = last.InnerException;
                    }

                    logManager.NewLog(
                        new Warning("There is a problem with repository: " + last.Message, ex.StackTrace)
                    );
                }
            }
        }
    }
}
