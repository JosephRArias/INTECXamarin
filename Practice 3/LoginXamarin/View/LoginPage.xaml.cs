using LoginXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginXamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			BindingContext = new LoginUserViewModel();
		}
		void TapGestureRecognizer_Tapped(object obj, EventArgs args)
		{
			Navigation.PushAsync(new RegisterPage());
		}
	}
}