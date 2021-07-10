using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyonLoad : MonoBehaviour
{
    private void Awake()
    {
        if(FindObjectsOfType<DontDestroyonLoad>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


}
