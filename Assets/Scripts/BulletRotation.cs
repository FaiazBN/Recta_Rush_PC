using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "Bullet Rotate")
        {
            Rotation();
        }
    }

    public void Rotation()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
