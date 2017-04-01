﻿/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 28/03/2017
 * Time: 20:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace quiz
{
	/// <summary>
	/// Description of ObservableObject.
	/// Inherit from this to be able to react to Property changes
	/// Add the Method OnPropertyChanged to the setter and use the Property name as an argument
	/// </summary>
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
