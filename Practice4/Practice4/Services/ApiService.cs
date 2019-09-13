using Newtonsoft.Json;
using Practice4.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Services
{
	class ApiService:IApiServices
	{
		static string ApiKey = "AIzaSyBvhCtMUXrHTRz0MWxWWXmAhLRjW_p_asE";
		static string coord = "18.4855, -69.8731";
		public async Task<PlaceModel> GetPlace(string place_name)
		{
			string url = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={place_name}&inputtype=textquery&key=AIzaSyBvhCtMUXrHTRz0MWxWWXmAhLRjW_p_asE&fields=price_level,formatted_address,name&locationbias=point:{coord}";
			HttpClient httpClient = new HttpClient();
			string text = await httpClient.GetStringAsync(url);
			var returned = JsonConvert.DeserializeObject<PlaceModel>(text);
			return returned;
		}
	}
}
