/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 03/28/2017
 * Time: 22:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;

namespace view_test.ViewModels
{
	/// <summary>
	/// Description of MainViewModel.
	/// </summary>
	public class MainViewModel
	{
		public UserViewModel User { get; private set; }
		public BackgroundViewModel Background { get; private set;}
		
		public MainViewModel()
		{
			User = new UserViewModel();
			Background = new BackgroundViewModel();
		}
		
		public void SetBackground(Brush brushColor)
		{
			Background.Color = brushColor;
		}
	}
}
