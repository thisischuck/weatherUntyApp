using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonCallback(int button)
    {
        switch (button)
        {
            case 1:
                SceneManager.LoadScene(button);
                break;

            case 2:
                SceneManager.LoadScene(button);
                break;

            case 3:
                SceneManager.LoadScene(button);
                break;
        }
    }
}
