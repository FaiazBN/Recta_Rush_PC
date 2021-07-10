using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField] [Range(0,1)]float timeSlow = 0.1f;
    [SerializeField] float remainingTime = 10f;
    [SerializeField] float maxTimeControl = 1f;
    TimeBar timeBar;
    bool isSlowed = false;
    bool shouldRefill = false;
    bool forEffect = false;
    void Start()
    {
        timeBar = FindObjectOfType<TimeBar>();
        timeBar.SetTime(remainingTime);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSlow();
        TimeBarMethod();
        print(remainingTime);
        if(remainingTime <= 0.03)
        {
            Time.timeScale = 1f;
        }

    }
    public bool GetForEffect()
    {
        return forEffect;
    }
    public float GetRemainingTime()
    {
        return remainingTime;
    }


    private void TimeBarMethod()
    {
        if (isSlowed)
        {
            remainingTime -= 1 * Time.deltaTime;           
            timeBar.StartTimer(remainingTime);
            if (remainingTime <= 0)
            {
                remainingTime = 0f;
                shouldRefill = true;
            }
        }
        if (shouldRefill)
        {
            remainingTime += 0.02f * Time.deltaTime;
            timeBar.StartTimer(remainingTime);
            if (remainingTime >= maxTimeControl)
            {
                remainingTime = maxTimeControl;
            }
        }
    }
    private void TimeSlow()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           Time.timeScale = timeSlow;
           isSlowed = true;
           shouldRefill = false;
           forEffect = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Time.timeScale = 1f;
            isSlowed = false;
            forEffect = false;
        }
    }

}
