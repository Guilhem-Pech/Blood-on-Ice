using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkipIntro : MonoBehaviour
{
    [FormerlySerializedAs("Intro")] public GameObject intro;

    void Update()
    {
        if (intro.activeInHierarchy == false)
        {
            if (Input.GetKeyDown("k"))
            {
                intro.SetActive(true);
            }
        }

        if (intro.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("l"))
            {
                Destroy(intro);
            }
        }
    }
}
