using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{


    public Transform startPosition;
    public Transform position1, position2;
    Vector3 nextPosition;
    public float speed;

    private void Start()
    {
        nextPosition = startPosition.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position == position1.position)
        {
            nextPosition = position2.position;
            Flip();
        }
        if (transform.position == position2.position)
        {
            nextPosition = position1.position;
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }

    private void Flip()
    {

        transform.Rotate(0f, 180f, 0f);
    }
}