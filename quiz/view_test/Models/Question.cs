/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 28/03/2017
 * Time: 16:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace view_test.Models
{
	/// <summary>
	/// Description of Question.
	/// The object that the view will get its data from
	/// </summary>
	public class Question
	{
		// public Properties (Fields wont work with data binding)
		public string QuestionText { get; set; }
		public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
		
		// Constructor (to set the showcase Properties)
		public Question()
		{
			QuestionText = "Is this working?";
			Answer1 = "Yes.";
			Answer2 = "No.";
			Answer3 = "Maybe.";
		}
	}
}
