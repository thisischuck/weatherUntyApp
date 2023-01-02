using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class SortManager : MonoBehaviour
{
    public GameObject cubePrefab;

    public int size = 64;
    public int distance = 1;

    List<GameObject> cubeList;

    // Start is called before the first frame update
    void Start()
    {
        cubeList = new List<GameObject>();
        GenerateCubes();

    }


    void GenerateCubes()
    {
        float sqr = Mathf.Sqrt(size);

        //How should i split it? How does it look good. I really don't like the whole 
        for (int i = 0; i < sqr; i++)
            for (int j = 0; j < sqr; j++)
            {
                Vector3 pos = new Vector3(
                    this.transform.position.x + distance * i - sqr / 2,
                    this.transform.position.z + distance * j,
                    0
                );

                GameObject o = Instantiate(
                    cubePrefab,
                    pos,
                    Quaternion.identity,
                    this.transform
                );

                cubeList.Add(o);
            }

        Debug.Log(cubeList.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
}