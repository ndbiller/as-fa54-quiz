/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 03/28/2017
 * Time: 22:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using view_test.Models;
using System.Windows.Media;

namespace view_test.ViewModels
{
	/// <summary>
	/// Description of BackgroundViewModel.
	/// </summary>
	public class BackgroundViewModel : ObservableObject
	{
		private Brush color;
		
		public Brush Color
		{
			get
			{
				if(color == null)
					return Brushes.Crimson;
				
				return color;
			}
			set
			{
				color = value;
				OnPropertyChanged("Color");
			}
		}
	}
}
