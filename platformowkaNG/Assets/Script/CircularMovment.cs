using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovment : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, Speed = 2f;

    float positionX, positionY, angle = 0f;


    void Update()
    {
        positionX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        positionY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * Speed;

        if(angle >= 360f)
        {
            angle = 0f;
        }
    }
}
