using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SortManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform floatingParent;
    public int size = 64;

    public List<GameObject> sortedList;
    List<GameObject> unsortedList;

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

                switch (rnd)
                {
                    case 0:
                        im.color = Color.red;
                        break;
                    case 1:
                        im.color = Color.green;
                        break;
                    case 2:
                        im.color = Color.blue;
                        break;
                }

                unsortedList.Add(o);
                o.GetComponentInChildren<TextMeshProUGUI>().text = unsortedList.Count.ToString();
            }

        Debug.Log(unsortedList.Count);
    }

    public void MoveCube()
    {
        //Move it to the sortedList
        GameObject o = unsortedList[0];
        GameObject clone = Instantiate(o, o.transform.position, o.transform.rotation, floatingParent);
        o.transform.parent = floatingParent;
        sortedList.Add(o);
        unsortedList.Remove(o);

        //Give it it's new position
        //On Arrival set the new parents
    }

    // Update is called once per frame
    void Update()
    {

    }
}