/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 28/03/2017
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using view_test.ViewModels;

namespace view_test
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		MainViewModel main = new MainViewModel();
		
		public Window2()
		{
			InitializeComponent();
			DataContext = main;
		}
		
		// here we have subscribed events for Window1
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// executes this when window has loaded event fires
		}
		
		void SubmitClicked(object sender, RoutedEventArgs e)
		{
			main.SetBackground(Brushes.Orange);
		}
	}
}

// more infos on commands: https://www.youtube.com/watch?v=8WfD2cFRymM&list=PLKShHgmYjjFwmuUZ46GxeSTA2zKZF-8nv&index=4#t=1116.613265