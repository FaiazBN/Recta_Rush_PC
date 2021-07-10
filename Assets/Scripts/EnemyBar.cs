using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image image;


    public void SetMaxScoreToPassLevel(float maxScore)
    {
        slider.maxValue = maxScore;
        //slider.value = maxScore;

       // image.color = gradient.Evaluate(1f);

    }
    public void SetScore(float currentScore)
    {
        slider.value = currentScore;
        image.color = gradient.Evaluate(slider.normalizedValue);
    }
}
