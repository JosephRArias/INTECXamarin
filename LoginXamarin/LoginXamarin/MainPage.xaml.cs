using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginXamarin
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			
		}
		async void VerifyData(Object ob, EventArgs arg)
		{
			if (string.IsNullOrEmpty(NameEntry.Text) && string.IsNullOrEmpty(PasswordEntry.Text))
			{
				await DisplayAlert("Error", "Ninguno de los campos puede estar vacio", "Ok");
			}
			else if (string.IsNullOrEmpty(NameEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
			{
				await DisplayAlert("Error", "El campo Name no puede estar vacio", "Ok");
			}
			else if (!string.IsNullOrEmpty(NameEntry.Text) && string.IsNullOrEmpty(PasswordEntry.Text))
			{
				await DisplayAlert("Error", "El campo Password no puede estar vacio", "Ok");
			}
			else
			{
				ShowMessage();
			}
		}
		async void ShowMessage()
		{
			await DisplayAlert("Bienvenido", $"Hola, {NameEntry.Text}", "Ok");
		}
		async void OnTapGestureRegister(Object ob, EventArgs eventArgs)
		{
			await Navigation.PushAsync(new RegisterPage());
		}
	}
}
