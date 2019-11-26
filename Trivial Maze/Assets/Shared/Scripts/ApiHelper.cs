using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using UnityEngine;

public static class ApiHelper
{
    public static string apiURL = "http://localhost:44379/api/";
    public static string MarkersController = "Markers";

    //get all items from the API
    public static string GetJsonFromAPI(string controller)
    {
        string json = string.Empty;

        using (WebClient client = new WebClient())
        {
            json = client.DownloadString(apiURL + controller);
        }

        return json;
    }

    //get data with using specifc arguments
    public static string GetJsonFromAPI(string controller, NameValueCollection arguments)
    {
        string json = string.Empty;

        using (WebClient client = new WebClient())
        {
            client.QueryString = arguments;
            json = client.DownloadString(apiURL + controller);
        }

        return json;
    }

    //upload new data to the API
    public static void PostDataToAPI(string controller, string json)
    {
        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(apiURL + controller, json);
        }
    }

    public static string ModifyJsonString(string json)
    {
        return "{\"Items\":" + json + "}";
    }

    //public static List<Marker> GetMarkers(string username, string zone)
    //{
    //    string json = string.Empty;

    //    using (WebClient client = new WebClient())
    //    {
    //        NameValueCollection args = new NameValueCollection();
    //        args.Add("username", username);
    //        args.Add("zoneName", zone);

    //        json = GetJsonFromAPI(MarkersController, args);
    //        json = ModifyJsonString(json);
    //        Debug.Log(json);
    //        return JsonUtility.FromJson<ListWrapper<Marker>>(json).Items;
    //    }
    //}
}


public class ListWrapper<T>
{
    public List<T> Items;
}

