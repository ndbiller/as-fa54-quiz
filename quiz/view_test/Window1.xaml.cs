/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 28/03/2017
 * Time: 16:14
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

// add the Models folder to the view context
using view_test.Models;

namespace view_test
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// Commented to showcase view and model interactions in wpf to backend and database specialists
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			
			// instantiate the object
			Question question = new Question();
			
			// bind the object to the view elements DataContext
			btn_answer1.DataContext = question;
			btn_answer2.DataContext = question;
			btn_answer3.DataContext = question;
		}
		
		// here we have subscribed events for Window1
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// executes this when window has loaded event fires
			mainGrid.Background = Brushes.Crimson;
		}
	}
}