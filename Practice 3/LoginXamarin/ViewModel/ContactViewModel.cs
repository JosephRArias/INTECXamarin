using LoginXamarin.Models;
using LoginXamarin.View;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginXamarin.ViewModel
{
	[AddINotifyPropertyChangedInterface]
	public class ContactViewModel
	{
		public ContactModel Contact { get; set; }
		public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
		public ICommand AddCommand { get; set; }

		public ContactViewModel()
		{
			Contact = new ContactModel();
			AddCommand = new Command(async() =>
			{
				string Name = Contact.Nombre;
				string Phone = Contact.PhoneNumber;
				Contacts.Add(Contact);
				await App.Current.MainPage.Navigation.PushAsync(new HomePage());
				MessagingCenter.Subscribe<AddContactPage, ContactModel>(this, Contact.Nombre, ((sender, param) =>
				{

				}));

			});
			
		}
	}
}
