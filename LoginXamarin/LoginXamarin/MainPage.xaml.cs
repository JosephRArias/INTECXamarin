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
			
			if (EmailEntry.Text != null && PasswordEntry.Text != null)
			{
				ShowMessage();
			}
			else if (EmailEntry.Text == null && PasswordEntry.Text != null)
			{
				await DisplayAlert("Error", "El campo Email no puede estar vacio", "Ok");
			}
			else if (EmailEntry.Text != null && PasswordEntry.Text == null)
			{
				await DisplayAlert("Error", "El campo Password no puede estar vacio", "Ok");
			}
			else
			{
				await DisplayAlert("Error", "Ninguno de los campos puede estar vacio", "Ok");
			}
		}
		public void ShowMessage()
		{
			var user = "Hola " + EmailEntry.Text;
			DisplayAlert("Bienvenido", user, "Ok");
		}
	}
}
