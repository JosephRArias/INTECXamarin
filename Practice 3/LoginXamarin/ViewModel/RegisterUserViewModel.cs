using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using LoginXamarin.Models;
using LoginXamarin.View;
using Xamarin.Forms;

namespace LoginXamarin.ViewModel
{
	public class RegisterUserViewModel : INotifyPropertyChanged
	{
		public RegisterUserModel userModel { get; set; }
		public string cpassword { get; set; }
		public ICommand SaveCommand { get; set; }
		public string ErrorIdentified { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChaged(string ErrorIdentified)
		{
 			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ErrorIdentified));
		}
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
					OnPropertyChaged(nameof(ErrorIdentified));
				}
				else if (password != cpassword)
				{
					ErrorIdentified = "The passwords do not match";
					OnPropertyChaged(nameof(ErrorIdentified));
				}
				else
				{
					await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
				}
			});
		}
	}
}
