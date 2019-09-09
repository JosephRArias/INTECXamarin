using LoginXamarin.Models;
using LoginXamarin.View;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginXamarin.ViewModel
{
	[AddINotifyPropertyChangedInterface]
	public class LoginUserViewModel 
	{
		public RegisterUserModel userModel { get; set; }
		public ICommand SaveCommand { get; set; }
		public string ErrorIdentified { get; set; }
		public LoginUserViewModel()
		{
			userModel = new RegisterUserModel();
			SaveCommand = new Command(async () =>
			{
				string username = userModel.Username;
				string password = userModel.Password;
				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
					ErrorIdentified = "Hay uno o mas campos vacios. Por favor llene todos.";
				}
				else
				{
					await App.Current.MainPage.Navigation.PushAsync(new HomePage(null));
				}
			});
		}
	}
}
