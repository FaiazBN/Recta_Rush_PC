using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoEffect : MonoBehaviour
{
    TimeControl timeControl;

    [SerializeField] GameObject slowMoUI;

    private void Start()
    {
        timeControl = FindObjectOfType<TimeControl>();
    }


    // Update is called once per frame
    void Update()
    {
        UIControl();
    }

    private void UIControl()
    {
        if (timeControl.GetForEffect())
        {
            slowMoUI.SetActive(true);
        }
        else if (!timeControl.GetForEffect())
        {
            slowMoUI.SetActive(false);
        }
        if (timeControl.GetRemainingTime() <= 0.03f)
        {
            slowMoUI.SetActive(false);
        }
    }
}
