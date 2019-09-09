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
	public class HomePageViewModel
	{
		public ContactModel Contact { get; set; }
		public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
		public ICommand AddCommand { get; set; }
		
		public HomePageViewModel(ContactModel contact)
		{
			Contact = contact;
			AddCommand = new Command(async () =>
			{
				MessagingCenter.Subscribe<ContactViewModel, ContactModel>(this, "ContactBeingAdded", ((sender, param) =>
				{
					Contacts.Add(param);
					MessagingCenter.Unsubscribe<ContactViewModel, ContactModel>(this, "ContactBeingAdded");

				}));
				await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(new ContactModel()));

			});
		}
	}
}
