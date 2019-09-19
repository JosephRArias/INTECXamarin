using Practice5.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Practice5.ViewModels
{
	public class HomePageViewModel
	{
		public ICommand GetDeviceOrientationCommand { get; set; }
		public HomePageViewModel()
		{
			GetDeviceOrientationCommand = new Command(async () =>
			{

				IDeviceOrientationService service = DependencyService.Get<IDeviceOrientationService>();
				DeviceOrientation orientation = service.GetOrientation();
				if (orientation.IsLandscape())
				{
					await App.Current.MainPage.DisplayAlert("Orientation", "The device orientation is Landscape", "Ok");
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Orientation", "The device orientation is Portrait", "Ok");
				}


			});
		}



	}
}
