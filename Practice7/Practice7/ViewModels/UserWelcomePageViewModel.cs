using Practice7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice7.ViewModels
{
	public class UserWelcomePageViewModel
	{
		public UserModel user { get; set; }
		public UserWelcomePageViewModel()
		{
			user = new UserModel();
			user.Name = "Marcos";
		}
	}
}
