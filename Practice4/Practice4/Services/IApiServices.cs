using Practice4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Services
{
	interface IApiServices
	{
		Task<PlaceModel> GetPlace(string name);
	}
}
