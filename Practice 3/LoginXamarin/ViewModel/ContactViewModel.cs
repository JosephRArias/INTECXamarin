using LoginXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LoginXamarin.ViewModel
{
	class ContactViewModel
	{
		ContactModel contact = new ContactModel();
		public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

		public ContactViewModel()
		{
			ContactModel myContact = new ContactModel();
			myContact.Nombre = "Fredo";
			myContact.PhoneNumber = "8490502012";
			Contacts.Add(myContact);
		}
	}
}
