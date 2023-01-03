using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{
    private const string apikey = "982d0bb3873a13a54c38b33a5186cb27";

    const int Lisboa = 2267056;
    const int Leira = 2267094;
    const int Coimbra = 2740636;
    const int Porto = 2735941;
    const int Faro = 2268337;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    IEnumerator GetWeatherData()
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/forecast?id={Lisboa}&APPID={apikey}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string data = www.downloadHandler.ToString();
            Debug.Log(data);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
