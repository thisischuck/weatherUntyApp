using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeatherInformation;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeatherVisualization : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Button resetButton;
    public GameObject temperature;
    public TextMeshProUGUI maxima;
    public TextMeshProUGUI minima;


    WeatherInfo info;

    IEnumerator GetTexture(string icon)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture($"http://openweathermap.org/img/wn/{icon}@2x.png");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite s = Sprite.Create(myTexture, new Rect(0f, 0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            spriteRenderer.sprite = s;
        }
    }

    public WeatherInfo Info
    {
        set
        {
            info = value;
            ParseInfo();
        }
    }

    void Start()
    {
        resetButton.onClick.AddListener(Reset);
    }

    void Reset()
    {
        temperature.SetActive(false);
    }

    void ParseInfo()
    {
        //Get Temperature
        float maxInCelcius = info.main.temp_max - 273.15f;
        float minInCelcius = info.main.temp_min - 273.15f;

        maxima.text = ((int)maxInCelcius).ToString() + "°";
        minima.text = ((int)minInCelcius).ToString() + "°";

        //Get Icon
        StartCoroutine(GetTexture(info.weather[0].icon));
    }

    void OnMouseDown()
    {
        temperature.SetActive(true);
        //Focus Camera on Me and Zoom
        Camera.main.GetComponent<CameraMove>().NewPositon = this.transform.position + new Vector3(0, 0, -0.40f);
    }

}
