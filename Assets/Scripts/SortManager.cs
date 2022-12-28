using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i < size; i++)
        {
            GameObject o = Instantiate(
                cubePrefab,
                new Vector3(this.transform.position.x + distance * i, 0, 0),
                Quaternion.identity
            );

            cubeList.Add(o);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
