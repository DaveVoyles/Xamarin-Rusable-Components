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

		// Massaged instance
		StarWarsObject starWarsObject;

		// API authentication
		string endPoint   = "";
		string requestUrl = "";


		public ComponentLibraryPage()
		{
			InitializeComponent();
			makeStarWarsWebRequest();
			Console.WriteLine(starWarsObject.name);


			// Add person to the main page & draw it
			this.PageRoot = this.FindByName<StackLayout>("StackLayout_comp");
			this.PageRoot.Children.Add(createPerson());            // Local
			this.PageRoot.Children.Add(createStarWarsPerson());    // Star Wars API
		}



		/// <summary>
		/// Create a person (StackLayout) from local data
		/// </summary>
		/// <returns>The person.</returns>
		private StackLayout createPerson() { 
			// Create a new component from Component.cs library
			myComponent  = new Component();
			var myPerson = myComponent.personComp;

			// Add all of the components needed for a person
			myPerson.Children.Add(myComponent.nameComp(myComponent._name));
			myPerson.Children.Add(myComponent.roleComp(myComponent._role));
			myPerson.Children.Add(myComponent.photoComp(myComponent._imageUri));

			return myPerson;
		}



		/// <summary>
		/// Create a person (StackLayout) from API data
		/// </summary>
		private View createStarWarsPerson() { 
			myComponent  = new Component();
			var myPerson = myComponent.personComp;

			Console.WriteLine(starWarsObject);

			// Add all of the components needed for a person
			myPerson.Children.Add(myComponent.nameComp(starWarsObject.name));
			myPerson.Children.Add(myComponent.roleComp(myComponent._role));
			myPerson.Children.Add(myComponent.photoComp(myComponent._imageUri));

			return myPerson;
		}


		/// <summary>
		/// Retrieve JSON data from http request
		/// </summary>
		 public void makeStarWarsWebRequest() { 
			var client      = new RestClient("http://swapi.co/api/");
			var request     = new RestRequest("people/1", Method.GET);

			// Automatically deserialize result
			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			IRestResponse<StarWarsObject> response2 = client.Execute<StarWarsObject>(request);
			starWarsObject = response2.Data;
		}


		/// <summary>
		/// MUST MAKE POST REQUEST
		/// </summary>
		public void makeWebRequest()
		{
			var client = new RestClient("http://swapi.co/api/");
			var request = new RestRequest("people/1", Method.POST);

			// Automatically deserialize result
			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			IRestResponse<StarWarsObject> response2 = client.Execute<StarWarsObject>(request);
			starWarsObject = response2.Data;
		}
	}
}
