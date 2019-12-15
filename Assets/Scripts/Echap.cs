using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echap : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Crédits;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        if (Intro.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Crédits.SetActive(true);
            }
        }

        if (Crédits.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
