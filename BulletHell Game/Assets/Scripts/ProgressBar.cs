using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider slider;

    public void SetGravAmount(float gravAmount)
    {
        slider.value = gravAmount;
    }
    public void setMaxGravAmount(float maxGravAmount)
    {
        slider.maxValue = maxGravAmount;
        slider.value = maxGravAmount;
    }
}
