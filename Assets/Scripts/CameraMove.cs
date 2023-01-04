using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float threshold = 1f;
    public float speed = 10f;
    public GameObject resetButton;

    private Vector3 newPosition;
    private Vector3 originalPosition;

    private bool updated = false;
    private bool arrived = false;


    public Vector3 NewPositon
    {
        set
        {
            newPosition = value;
            updated = true;
            resetButton.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
    }

    public void BackCLicked()
    {
        NewPositon = originalPosition;
        resetButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (updated)
        {
            this.transform.position = Vector3.LerpUnclamped(this.transform.position, newPosition, speed * Time.deltaTime);
            float f = Vector3.Distance(this.transform.position, newPosition);
            updated = f > threshold;
        }
    }
}
