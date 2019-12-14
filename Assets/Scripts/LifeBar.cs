using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public float lifePercent;
    public int roundCounter;
    private float m_lifePercent;
    private int m_roundCounter;
    private float dmgPercent;
    private float dmgTimer;
    private Image hpBackground;
    private Image dmgImg;
    private Image dmgMask;
    private Image lifeImg;
    private Image lifeMask;
    private Image snow1;
    private Image snow2;

    void Start()
    {
        
        hpBackground = transform.Find("BackCritical").GetComponent<Image>();
        dmgImg = transform.Find("DmgBufferMask").Find("DmgBuffer").GetComponent<Image>();
        dmgMask = transform.Find("DmgBufferMask").GetComponent<Image>();
        lifeImg = transform.Find("LifeBarMask").Find("LifeBarColor").GetComponent<Image>();
        lifeMask = transform.Find("LifeBarMask").GetComponent<Image>();
        snow1 = transform.Find("SnowBack1").Find("SnowFlake1").GetComponent<Image>();
        snow2 = transform.Find("SnowBack2").Find("SnowFlake2").GetComponent<Image>();
        dmgTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePercent != m_lifePercent)//&& OnVariableChange != null)
        {
            dmgPercent = m_lifePercent;
            LifeUpdate();
            dmgTimer = 1;
            m_lifePercent = lifePercent;
            
        }

        if (roundCounter != m_roundCounter)
        {
            RoundUpdate();
            m_roundCounter = roundCounter;
        }

        if (dmgPercent > lifePercent)
        {
            if (dmgTimer <= 0)
            {
                dmgPercent -= Time.deltaTime/2;
                LifeUpdate();
            } else
            {
                dmgTimer -= Time.deltaTime*2;
            }
        }
    }

    void LifeUpdate()
    {
        hpBackground.color = new Color(hpBackground.color.r, hpBackground.color.g, hpBackground.color.b, (1 - lifePercent)/2);
        lifeImg.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - lifePercent) * -1000, -180, 0);
        lifeMask.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - lifePercent) * 1000, -200, 0);
        dmgImg.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - dmgPercent) * -1000, -180, 0);
        dmgMask.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - dmgPercent) * 1000, -200, 0);
    }


    void RoundUpdate()
    {
        if (roundCounter >= 1)
        {
            snow1.color = new Color(lifeImg.color.r, lifeImg.color.g, lifeImg.color.b, 1f);
        }
        if (roundCounter >= 2)
        {
            snow2.color = new Color(lifeImg.color.r, lifeImg.color.g, lifeImg.color.b, 1f);
        }
        if (roundCounter == 0)
        {
            snow1.color = new Color(lifeImg.color.r, lifeImg.color.g, lifeImg.color.b, 0);
            snow2.color = new Color(lifeImg.color.r, lifeImg.color.g, lifeImg.color.b, 0);
        }
    }
}
