# Search Fight

## Running the project

The project was developed with .NET Core 3.1. You can use Visual Studio or .NET CLI to run it.

You need to provide your own [Google Search](https://developers.google.com/custom-search/v1/overview) and [Bing Search](https://docs.microsoft.com/en-us/bing/search-apis/bing-web-search/create-bing-search-service-resource) API keys and set them in the appsettings.json.

Once you build the code for release, you can use the terminal to run the project. For example:

```
./SearchFight.exe c# java
```

output example:

```
c#:
    Google: 768000 Bing: 3130000
java:
    Google: 8720000 Bing: 95700000

Google Winner: java
Bing Winner: java
Total Winner: java
```