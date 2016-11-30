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


		public StackLayout personComp = new StackLayout()
		{
		};


		public Label nameComp(string name)
		{
			Label _nameComp = new Label()
			{
				Text = name,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.Black,
				Margin = new Thickness(0, 20, 0, 5),
				FontSize = 18
			};
			return _nameComp;
		}



		public Label roleComp(string role)
		{
			Label _roleComp = new Label()
			{
				Text = role,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.Gray,
				Margin = new Thickness(0, 5, 0, 5),
				FontSize = 14
			};
			return _roleComp;
		}


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

