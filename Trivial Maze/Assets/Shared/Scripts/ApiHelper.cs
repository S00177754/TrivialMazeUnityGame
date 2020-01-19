using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using UnityEngine;

public static class ApiHelper
{
    public static string apiURL = "http://localhost:44342/api/";
    public static string PlayersController = "Players";
    public static string MessagesController = "Messages";
    public static string KeyPositionsController = "KeyPositions";
    public static string TimeScoresController = "TimeScores";
    public static string TriviaQuestionsController = "TriviaQuestions";

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
            client.Headers[HttpRequestHeader.Accept] = "text/html, image/png, image/jpeg, image/gif, */*;q=0.1";
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; de; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12";

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

    public static Player GetPlayer(string username)
    {
        string json = string.Empty;

        using (WebClient client = new WebClient())
        {
            NameValueCollection args = new NameValueCollection();
            args.Add("username", username);

            try
            {
                json = GetJsonFromAPI(PlayersController, args);
            }
            catch(WebException we) 
            {
                HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                if(errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }

            Debug.Log(json);
            var player = JsonUtility.FromJson<Player>(json);
            return player;
        }
    }

    public static void PostPlayer(string username,string password)
    {
        Player signup = new Player() { Username = username, Password = password };
        string json = JsonUtility.ToJson(signup);
        PostDataToAPI(PlayersController, json);
    }

    public static List<TimeScore> GetScores(int topAmount)
    {
        string json = string.Empty;

        using (WebClient client = new WebClient())
        {
            NameValueCollection args = new NameValueCollection();
            args.Add("amount", topAmount.ToString());

            try
            {
                json = GetJsonFromAPI(TimeScoresController, args);
            }
            catch (WebException we)
            {
                HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }
            json = ModifyJsonString(json);
            Debug.Log(json);
            return JsonUtility.FromJson<ListWrapper<TimeScore>>(json).Items;
        }

    }

    public static List<TimeScore> GetScores(string Username)
    {
        string json = string.Empty;

        using (WebClient client = new WebClient())
        {
            NameValueCollection args = new NameValueCollection();
            args.Add("username", Username);

            try
            {
                json = GetJsonFromAPI(TimeScoresController, args);
            }
            catch (WebException we)
            {
                HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }
            json = ModifyJsonString(json);
            Debug.Log(json);
            return JsonUtility.FromJson<ListWrapper<TimeScore>>(json).Items;
        }
    }

}


public class ListWrapper<T>
{
    public List<T> Items;
}

