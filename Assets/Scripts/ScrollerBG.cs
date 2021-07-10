using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerBG : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    //update is called once per frame

    void Update()
    {
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -19.97)
        {
            transform.position = StartPosition;
        }
    }
}
