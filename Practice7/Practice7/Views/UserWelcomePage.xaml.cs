using Practice7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practice7.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserWelcomePage : ContentPage
	{
		public UserWelcomePage()
		{
			InitializeComponent();
			BindingContext = new UserWelcomePageViewModel(); 
		}
	}
}