using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public GameObject Intro;

    void Update()
    {
        if (Intro.activeInHierarchy == false)
        {
            if (Input.GetKeyDown("k"))
            {
                Intro.SetActive(true);
            }
        }

        if (Intro.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("l"))
            {
                Destroy(Intro);
            }
        }
    }
}
