using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMob : MonoBehaviour
{
    public Slider slidermob;

    public void SetMaxHealthMob(int healthMob)
    {
        slidermob.maxValue = healthMob;
        slidermob.value = healthMob;
    }

    public void SetHealthMob(int healthMob)
    {
        slidermob.value = healthMob;
    }
}
