/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 03/28/2017
 * Time: 21:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using view_test.Models;

namespace view_test.ViewModels
{
	/// <summary>
	/// Description of UserViewModel.
	/// </summary>
	public class UserViewModel : ObservableObject
	{
		private string name;
		
		public string Name
		{
			get 
			{
				if(string.IsNullOrEmpty(name))
					return "Unknown User";
				
				return name;
			}
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
	}
}
