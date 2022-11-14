using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManaBar : MonoBehaviour
{
    public weapon weaponRef;
    public Image fillImage;
    private Slider slider;
    private float fullbar;

    Color healthy = new Color(0,255,143,1);
    Color good = new Color(118,234,0,1);

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        fullbar = weaponRef.BulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = weaponRef.BulletCount / fullbar;
        if((fillvalue <= slider.maxValue) && (fillvalue > slider.maxValue/2))
        {
            fillImage.color = healthy;
        }
        else if((fillvalue <= slider.maxValue/2) && (fillvalue > slider.maxValue/4))
        {
            fillImage.color = good;
        }
        else if(fillvalue <= slider.maxValue/4)
        {
            fillImage.color = Color.red;
        }
        
        slider.value = fillvalue;
    }
}
