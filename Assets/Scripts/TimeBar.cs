using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image image;
    private void Start()
    {
        image.color = gradient.Evaluate(1f);
    }

    public void SetTime(float remaingTime)
    {
        slider.maxValue = remaingTime;
        slider.value = remaingTime;

        image.color = gradient.Evaluate(1f);
    }
    private void Update()
    {
    }
    public void StartTimer(float remainingTime)
    {
        slider.value = remainingTime;
        image.color = gradient.Evaluate(slider.normalizedValue);
    }
}
