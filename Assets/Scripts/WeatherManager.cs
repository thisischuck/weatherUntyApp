using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using WeatherInformation;
using TMPro;

public class WeatherManager : MonoBehaviour
{
    private const string apikey = "982d0bb3873a13a54c38b33a5186cb27";

    const int Lisboa = 2267056;
    const int Leiria = 2267094;
    const int Coimbra = 2740636;
    const int Porto = 2735941;
    const int Faro = 2268337;
    const int Angra = 3373348;

    public Transform map;
    public GameObject ErrorVisualization;

    private WeatherInfo info;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeatherData(Lisboa));
        StartCoroutine(GetWeatherData(Leiria));
        StartCoroutine(GetWeatherData(Coimbra));
        StartCoroutine(GetWeatherData(Porto));
        StartCoroutine(GetWeatherData(Faro));
        StartCoroutine(GetWeatherData(Angra));
    }

    IEnumerator GetWeatherData(int city)
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/weather?id={city}&APPID={apikey}");
        //UnityWebRequest www = UnityWebRequest.Get($"http://api.openweathermap.org/data/2.5/forecast?id={Lisboa}&APPID={apikey}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            ErrorVisualization.SetActive(true);
            ErrorVisualization.GetComponentInChildren<TextMeshProUGUI>().text = www.error;
        }
        else
        {
            string data = www.downloadHandler.text;
            info = JsonUtility.FromJson<WeatherInfo>(data);
            Transform t = map.Find(city.ToString());
            var src = t.GetComponent<WeatherVisualization>();
            src.Info = info;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
