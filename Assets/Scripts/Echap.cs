using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Echap : MonoBehaviour
{
    [FormerlySerializedAs("Intro")] public GameObject intro;
    [FormerlySerializedAs("Crédits")] public GameObject crédits;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        if (intro.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (crédits.activeInHierarchy == (false))
                {
                    crédits.SetActive(true);
                }

                else
                {
                    crédits.SetActive(false);
                }
            }
        }

        else
        {
            crédits.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && crédits.activeInHierarchy == (true))
        {
            Application.Quit();
        }
    }
}
