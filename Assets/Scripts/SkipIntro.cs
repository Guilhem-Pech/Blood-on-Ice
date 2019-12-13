using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipIntro : MonoBehaviour
{
    public GameObject Intro;

    void Update()
    {
        if (Intro.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("l"))
            {
                Intro.SetActive(false);
            }
        }
    }
}
