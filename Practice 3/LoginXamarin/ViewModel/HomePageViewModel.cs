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
		public ICommand SeeMoreCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

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
			SeeMoreCommand = new Command<ContactModel>(async (ExistingContact) =>
			{
				string call = "Call this contact";
				string edit = "Edit this contact";
				string result = await App.Current.MainPage.DisplayActionSheet("What do you wanna do?", "Cancel", "Ok", call, edit);
				if(result == call)
				{
					Device.OpenUri(new Uri(String.Format("tel:{0}", ExistingContact.PhoneNumber)));
				}
				else
				{
					await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(ExistingContact));
				}


			});
			DeleteCommand = new Command<ContactModel>(async (ExistingContact) =>
			{
				string warning = "Do yo really wanna delete this contact?";
				bool response = await App.Current.MainPage.DisplayAlert("This action is irreversible", warning, "Yes", "No");
				if (response)
				{
					Contacts.Remove(ExistingContact);
				}
			});
		}
	}
}
