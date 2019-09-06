﻿using LoginXamarin.ViewModel;
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
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
			BindingContext = new ContactViewModel();
		}
		void Item_Tapped(object obj, EventArgs args)
		{
			Navigation.PushAsync(new AddContactPage());
		}
		void OnMore(object obj, EventArgs args)
		{

		}
		void OnDelete(object obj, EventArgs args)
		{

		}
	}
}