﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
	internal class UserService
	{
		public void SaveUsername(string username)
		{
			if (String.IsNullOrEmpty(username))
			{
				return;
			}

			Properties.Settings.Default.currentUser = username;
			Properties.Settings.Default.Save();
		}

		public string GetUsername()
		{
			var username = Properties.Settings.Default.currentUser;
			return username;
		}

		public void RemoveUserName()
		{
			Properties.Settings.Default.currentUser = "";
			Properties.Settings.Default.Save();
		}
	}
}