using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Video;

public class MediaLoadManager : MonoBehaviour
{
    public string texture_url;
    public string video_url;

    public GameObject raw;
    public VideoPlayer vp;
    //public RawImage video;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartButton()
    {
        StartCoroutine(GetTexture());

        vp.url = video_url;
        vp.Prepare();
        vp.prepareCompleted += PlayVideo;
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(texture_url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            raw.GetComponent<MeshRenderer>().material.mainTexture = myTexture;
        }
    }

    void PlayVideo(VideoPlayer source)
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
