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
		public ICommand CreateNewContactCommand { get; set; }

		public ContactViewModel(ContactModel contact)
		{
			Contact = contact;
			CreateNewContactCommand = new Command(async() =>
			{
				MessagingCenter.Send<ContactViewModel, ContactModel>(this, "ContactBeingAdded", Contact);
				await App.Current.MainPage.Navigation.PopAsync();
			});
			
		}
	}
}
