# Xamarin-Rusable-Components

### Author(s): Dave Voyles | [@DaveVoyles](http://www.twitter.com/DaveVoyles)
### URL: [www.DaveVoyles.com][1]

Small widgets to create a dynamic UI based on a config file
----------
### About
This was created as part of a Xamarin hackfest hosted by Microsoft in NYC on the week of November 28th. 

The idea is to create small UI components in C#, which then generate XAML. Right now there are two days of doing this in the project:

1. Pass in some hardcoded values *(font sizes, image url, etc.)*
2. Make a web request to an API and pull down data, and pass that data as paramters to these C# components

----------
### How to use
1. Pull down the [Restsharp NuGet package](https://github.com/restsharp/RestSharp)
2. Run the project

I've tested this on iOS and Android and both work fine.

----------
### How it works

I'm making one call to the [Star Wars API](https://swapi.co/), simply to show how pulling data from an API works. The name and role of a character is set using this data. 

When you are ready with your own API, pass in the credentials in the ComponentLibraryPage.cs class by placing them in the API credentials section:

```Javascript
		// API CREDENTIALS
		string _contentType = "application/x-www-form-urlencoded";
		string _loginName   = "";
		string _password    = "";
		string _bRememberMe = "";
```

You will also need to uncomment this:

```Javascript
			// TODO: Uncomment this when you want to test out YOUR API
			makeWebRequest   	     (_domainUrl, _requestUrl);
			GetWebRequestWithCookie(_domainUrl, _fileUrl   );
```

There are additional instructions in the Component.cs file as well.

The top "component" here is just using local data. The second component is using data pulled down from the API. 


![Morbo](https://www.dropbox.com/s/e78rqr64q7fe6dq/Morbo-Xamarin-Reusable-Components.png?raw=1 "Morbo Xamarin")



  [1]: http://www.daveVoyles.com "My website"
