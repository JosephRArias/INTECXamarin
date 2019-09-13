using Practice4.Models;
using Practice4.Services;
using Practice4.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Practice4.ViewModel
{
	public class PlaceViewModel
	{
		IApiServices apiService = new ApiService();
		
		public ICommand GetDataCommand { get; set; }

		string PlaceName { get; set; }

		PlaceModel placeModel { get; set; }

		public PlaceViewModel()
		{
			GetDataCommand = new Command(async () =>
			{
				var connection = Connectivity.NetworkAccess;
				if(connection == NetworkAccess.Internet)
				{
					var CandidateData = await apiService.GetPlace(PlaceName);
					placeModel = CandidateData;
					await App.Current.MainPage.Navigation.PushAsync(new PlacePage());
					
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Error", "Please check your internet connection", "Ok");
				}
			});
		}
	}
}
