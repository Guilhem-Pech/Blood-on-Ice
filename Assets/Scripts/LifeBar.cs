using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public float lifePercent;
    public int roundCounter;
    private float _mLifePercent;
    private int _mRoundCounter;
    private float _dmgPercent;
    private float _dmgTimer;
    private Image _hpBackground;
    private Image _dmgImg;
    private Image _dmgMask;
    private Image _lifeImg;
    private Image _lifeMask;
    private Image _snow1;
    private Image _snow2;

    void Start()
    {
        
        _hpBackground = transform.Find("BackCritical").GetComponent<Image>();
        _dmgImg = transform.Find("DmgBufferMask").Find("DmgBuffer").GetComponent<Image>();
        _dmgMask = transform.Find("DmgBufferMask").GetComponent<Image>();
        _lifeImg = transform.Find("LifeBarMask").Find("LifeBarColor").GetComponent<Image>();
        _lifeMask = transform.Find("LifeBarMask").GetComponent<Image>();
        _snow1 = transform.Find("SnowBack1").Find("SnowFlake1").GetComponent<Image>();
        _snow2 = transform.Find("SnowBack2").Find("SnowFlake2").GetComponent<Image>();
        _dmgTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePercent != _mLifePercent)//&& OnVariableChange != null)
        {
            _dmgPercent = _mLifePercent;
            LifeUpdate();
            _dmgTimer = 1;
            _mLifePercent = lifePercent;
            
        }

        if (roundCounter != _mRoundCounter)
        {
            RoundUpdate();
            _mRoundCounter = roundCounter;
        }

        if (_dmgPercent > lifePercent)
        {
            if (_dmgTimer <= 0)
            {
                _dmgPercent -= Time.deltaTime/2;
                LifeUpdate();
            } else
            {
                _dmgTimer -= Time.deltaTime*2;
            }
        }
    }

    void LifeUpdate()
    {
        _hpBackground.color = new Color(_hpBackground.color.r, _hpBackground.color.g, _hpBackground.color.b, (1 - lifePercent)/2);
        _lifeImg.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - lifePercent) * -1000, -180, 0);
        _lifeMask.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - lifePercent) * 1000, -200, 0);
        _dmgImg.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - _dmgPercent) * -1000, -180, 0);
        _dmgMask.GetComponent<RectTransform>().anchoredPosition = new Vector3((1 - _dmgPercent) * 1000, -200, 0);
    }


    void RoundUpdate()
    {
        if (roundCounter >= 1)
        {
            _snow1.color = new Color(_lifeImg.color.r, _lifeImg.color.g, _lifeImg.color.b, 1f);
        }
        if (roundCounter >= 2)
        {
            _snow2.color = new Color(_lifeImg.color.r, _lifeImg.color.g, _lifeImg.color.b, 1f);
        }
        if (roundCounter == 0)
        {
            _snow1.color = new Color(_lifeImg.color.r, _lifeImg.color.g, _lifeImg.color.b, 0);
            _snow2.color = new Color(_lifeImg.color.r, _lifeImg.color.g, _lifeImg.color.b, 0);
        }
    }
}
