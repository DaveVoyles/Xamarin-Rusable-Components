using Xamarin.Forms;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace ComponentLibrary
{
	public partial class ComponentLibraryPage : ContentPage
	{
		// Root of page where everything will be drawn to
		StackLayout PageRoot;
		Component myComponent;
		RootObject myRootObj;

		public ComponentLibraryPage()
		{
			InitializeComponent();
			makeWebRequest();
			Console.WriteLine(myRootObj.name);

			// Create a new component from Component.cs library
			myComponent  = new Component();
			var myPerson = myComponent.personComp;

			// Add all of the components needed for a person
			myPerson.Children.Add(myComponent.nameComp(myComponent._name));
			myPerson.Children.Add(myComponent.roleComp(myComponent._role));
			myPerson.Children.Add(myComponent.photoComp(myComponent._imageUri));


			// Add person to the main page (DRAW IT!)
			this.PageRoot = this.FindByName<StackLayout>("StackLayout_comp");
			this.PageRoot.Children.Add(myPerson);
			//this.PageRoot.Children.Add(createStarWarsComponent());
		}


		private View createStarWarsComponent() { 
			myComponent  = new Component();
			var myPerson = myComponent.personComp;

			Console.WriteLine(myRootObj);

			// Add all of the components needed for a person
			myPerson.Children.Add(myComponent.nameComp(myRootObj.name));
			myPerson.Children.Add(myComponent.roleComp(myComponent._role));
			myPerson.Children.Add(myComponent.photoComp(myComponent._imageUri));

			return myPerson;
		}


		/// <summary>
		/// Retrieve JSON data from http request
		/// </summary>
		 public void makeWebRequest() { 
			var client      = new RestClient("http://swapi.co/api/");
			var request     = new RestRequest("people/1", Method.GET);

			// Automatically deserialize result
			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			IRestResponse<RootObject> response2 = client.Execute<RootObject>(request);
			myRootObj = response2.Data;
		}
	}
}
