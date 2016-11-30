using System;
using Xamarin.Forms;

namespace ComponentLibrary
{
	public class Component
	{
		// TODO: Replace w/ call from database
		public string _imageUri = "https://pbs.twimg.com/profile_images/1305033822/Morbo2.jpg";
		public string _name     = "Name: Morbo the Annihilator";
		public string _role     = "Role: News Anchor";



		/// <summary>
		/// Empty container to hold a person's attributes: Name, Role, Image, etc.,
		/// </summary>
		public StackLayout personContainer = new StackLayout()
		{
		};


		/// <summary>
		/// Creates a Label based on the user's name
		/// </summary>
		/// <returns>Label w/ user's name</returns>
		/// <param name="name">What is the name of this person?</param>
		public Label nameComp(string name)
		{
			Label _nameComp = new Label()
			{
				Text 				    = name,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor			    = Color.Black,
				Margin				    = new Thickness(0, 20, 0, 5),
				FontSize 				= 18
			};
			return _nameComp;
		}


		/// <summary>
		/// Creates a Label based on the user's role / position
		/// </summary>
		/// <returns>Label w/ user's role / position</returns>
		/// <param name="role">What is the role / position of this person?</param>
		public Label roleComp(string role)
		{
			Label _roleComp = new Label()
			{
				Text 					= role,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor			    = Color.Gray,
				Margin 					= new Thickness(0, 5, 0, 5),
				FontSize 				= 14
			};
			return _roleComp;
		}


		/// <summary>
		/// Creates a Image based on url passed in from user
		/// </summary>
		/// <returns>Image w/ user's mugshot</returns>
		/// <param name="imageUri">Mugshot of user</param>
		public Image photoComp(string imageUri)
		{
			Image _photo = new Image() 
			{
				Aspect = Aspect.AspectFit,
			    Source = ImageSource.FromUri(new Uri(imageUri))
				//Source = ImageSource.FromFile("Img/morbo.jpg")
			};
			return _photo;
		}

	}
}

