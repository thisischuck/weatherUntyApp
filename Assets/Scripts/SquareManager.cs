using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareManager : MonoBehaviour
{
    [SerializeField]
    bool updated = false;
    public bool Arrived = false;
    public float threshold = 10f;
    public float speed = 10f;
    [SerializeField]
    GameObject original;
    Color c;

    private RectTransform rect;

    public Color Color
    {
        get { return c; }
        set
        {
            c = value;
        }
    }

    public GameObject Original
    {
        get { return original; }
        set
        {
            original = value;
            Arrived = false;
            updated = true;
        }
    }

    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updated)
        {
            this.transform.position = Vector3.LerpUnclamped(this.transform.position, original.transform.position, speed * Time.deltaTime);
            float f = Vector3.Distance(this.transform.position, original.transform.position);
            updated = f > threshold;
            if (!updated)
                Arrived = true;
        }

        if (Arrived)
        {
            this.gameObject.SetActive(false);
            original.GetComponent<Image>().enabled = true;
        }
    }
}
