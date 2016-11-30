using Xamarin.Forms;
using RestSharp;
using System;

namespace ComponentLibrary
{
	public partial class ComponentLibraryPage : ContentPage
	{
		// Root of page where everything will be drawn to
		StackLayout _pageRoot;
		Component   _component;

		// Massaged instance
		StarWarsObject _starWarsObject;
		RequestObject  _requestObject;

		// API authentication
		string _endPoint   = "";
		string _requestUrl = "";


		public ComponentLibraryPage()
		{
			InitializeComponent();

			// Web requests
			makeStarWarsWebRequest();
			Console.WriteLine(_starWarsObject.name);
			makeWebRequest(_endPoint, _requestUrl);
			Console.WriteLine(_requestObject);

			// Get ref to XAML, add person to the main page & draw it
			this._pageRoot = this.FindByName<StackLayout>("StackLayout_comp");
			this._pageRoot.Children.Add(createPerson());            // Local
			this._pageRoot.Children.Add(createStarWarsPerson());    // Star Wars API
		}


		/// <summary>
		/// Create a person (StackLayout) from local data
		/// </summary>
		/// <returns>The person.</returns>
		private StackLayout createPerson() 
		{ 
			// Create a new component from Component.cs library
			_component   = new Component();
			var myPerson = _component.personContainer;

			// Add all of the components needed for a person
			myPerson.Children.Add(_component.nameComp(_component._name	   ));
			myPerson.Children.Add(_component.roleComp(_component._role	   ));
			myPerson.Children.Add(_component.photoComp(_component._imageUri));

			return myPerson;
		}


		/// <summary>
		/// Create a person (StackLayout) from API data
		/// </summary>
		private View createStarWarsPerson()
		{ 
			_component  = new Component();
			var myPerson = _component.personContainer;

			Console.WriteLine(_starWarsObject);

			// Add all of the components needed for a person
			myPerson.Children.Add(_component.nameComp(_starWarsObject.name ));
			myPerson.Children.Add(_component.roleComp(_component._role     ));
			myPerson.Children.Add(_component.photoComp(_component._imageUri));

			return myPerson;
		}


		/// <summary>
		/// Retrieve JSON data from http request
		/// </summary>
	    public void makeStarWarsWebRequest()
		{ 
			var client      = new RestClient("http://swapi.co/api/");
			var request     = new RestRequest("people/1", Method.GET);

			// Automatically deserialize result
			IRestResponse<StarWarsObject> response2 = client.Execute<StarWarsObject>(request);
			_starWarsObject 					    = response2.Data;
		}


		/// <summary>
		/// MUST MAKE POST REQUEST
		/// </summary>
		public void makeWebRequest(string endPoint, string requestUrl)
		{
			var client  = new RestClient(endPoint);
			var request = new RestRequest(requestUrl, Method.POST);

			// Automatically deserialize result
			IRestResponse<StarWarsObject> response2 = client.Execute<StarWarsObject>(request);
			_starWarsObject 						= response2.Data;
		}
	}
}
