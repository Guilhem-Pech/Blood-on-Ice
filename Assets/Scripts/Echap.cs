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
                if (Crédits.activeInHierarchy == (false))
                {
                    Crédits.SetActive(true);
                }

                else
                {
                    Crédits.SetActive(false);
                }
            }
        }

        else
        {
            Crédits.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Crédits.activeInHierarchy == (true))
        {
            Application.Quit();
        }
    }
}
