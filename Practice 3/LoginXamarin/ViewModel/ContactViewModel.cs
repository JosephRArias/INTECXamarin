using LoginXamarin.Models;
using LoginXamarin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginXamarin.ViewModel
{
	class ContactViewModel
	{
		ContactModel contact = new ContactModel();
		public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
		public ICommand AddCommand { get; set; }

		public ContactViewModel()
		{
			ContactModel myContact = new ContactModel();
			myContact.Nombre = "Fredo";
			myContact.PhoneNumber = "8490502012";
			Contacts.Add(myContact);

			AddCommand = new Command(async() =>
			{
				string Name = contact.Nombre;
				string Phone = contact.PhoneNumber;
				Contacts.Add(contact);
				await App.Current.MainPage.Navigation.PushAsync(new HomePage());

			});
			
		}
	}
}
