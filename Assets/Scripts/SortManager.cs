using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SortManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject dummmy;
    public GameObject dummmySorted;
    public Transform redParent;
    public Transform greenParent;
    public Transform blueParent;
    public Transform sortedParent;
    public int size = 64;

    public List<GameObject> sortedList;
    public List<GameObject> unsortedList;

    // Start is called before the first frame update
    void Start()
    {
        unsortedList = new List<GameObject>();
        sortedList = new List<GameObject>();
        GenerateCubes();
    }


    void GenerateCubes()
    {
        float sqr = Mathf.Sqrt(size);

        //How should i split it? How does it look good. I really don't like the whole 
        for (int i = 0; i < sqr; i++)
            for (int j = 0; j < sqr; j++)
            {
                int rnd = Random.Range(0, 3);

                GameObject o = Instantiate(
                    cubePrefab,
                    this.transform.position,
                    Quaternion.identity,
                    this.transform
                );
                var im = o.GetComponent<Image>();
                //var src = o.GetComponent<SquareManager>();

                Color tempColor = Color.white;
                switch (rnd)
                {
                    case 0:
                        tempColor = Color.red;
                        break;
                    case 1:
                        tempColor = Color.green;
                        break;
                    case 2:
                        tempColor = Color.blue;
                        break;
                }
                im.color = tempColor;
                //src.Color = tempColor;

                unsortedList.Add(o);
            }

        Debug.Log(unsortedList.Count);
    }

    bool clicked = false;
    public void Sort()
    {
        if (!clicked)
        {
            clicked = true;
            StartCoroutine(Sorting());
        }

    }

    IEnumerator Sorting()
    {
        while (unsortedList.Count > 0)
        {
            GameObject o = unsortedList[0];
            MoveCubeSortedList(o);
            MoveCube(o);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    public void MoveCube(GameObject o)
    {
        //Move it to the sortedList
        Image im = o.GetComponent<Image>();
        Color c = im.color;
        unsortedList.Remove(o);
        sortedList.Add(o);
        //Get old world position
        Vector3 dummyPosition = o.transform.position;
        //reparent
        Transform newParent = transform;

        if (c == Color.red)
            newParent = redParent;
        else if (c == Color.blue)
            newParent = blueParent;
        else if (c == Color.green)
            newParent = greenParent;

        o.transform.SetParent(newParent, false);
        //deactivate original
        im.enabled = false;
        //Setup Dummy
        dummmy.transform.position = dummyPosition;
        dummmy.GetComponent<Image>().color = c;
        dummmy.SetActive(true);
        var dummySrc = dummmy.GetComponent<SquareManager>();
        dummySrc.Original = o;
    }

    public void MoveCubeSortedList(GameObject o)
    {
        GameObject clone = Instantiate(o, sortedParent);
        Image im = clone.GetComponent<Image>();
        Color c = im.color;
        //Get old world position
        Vector3 dummyPosition = o.transform.position;
        //deactivate original
        im.enabled = false;
        //Setup Dummy
        dummmySorted.transform.position = dummyPosition;
        dummmySorted.GetComponent<Image>().color = c;
        dummmySorted.SetActive(true);
        var dummySrc = dummmySorted.GetComponent<SquareManager>();
        dummySrc.Original = clone;
    }

    // Update is called once per frame
    void Update()
    {

    }
}