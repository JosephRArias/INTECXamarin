using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using LoginXamarin.Models;
using LoginXamarin.View;
using PropertyChanged;
using Xamarin.Forms;

namespace LoginXamarin.ViewModel
{
	[AddINotifyPropertyChangedInterface]
	public class RegisterUserViewModel
	{
		public RegisterUserModel userModel { get; set; }
		public string cpassword { get; set; }
		public ICommand SaveCommand { get; set; }
		public string ErrorIdentified { get; set; }
		public RegisterUserViewModel()
		{
			userModel = new RegisterUserModel();
			SaveCommand = new Command(async() => 
			{
				string username = userModel.Username;
				string password = userModel.Password;
				if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cpassword))
				{
					ErrorIdentified = "Hay uno o mas campos vacios. Por favor llene todos.";
				}
				else if (password != cpassword)
				{
					ErrorIdentified = "The passwords do not match";
				}
				else
				{
					await App.Current.MainPage.Navigation.PushAsync(new HomePage());
				}
			});
		}
	}
}
