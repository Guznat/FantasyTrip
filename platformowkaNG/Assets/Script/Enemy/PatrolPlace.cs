using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPlace : MonoBehaviour
{
   public float speed;
    public Transform[] places;
    private int randomPlace;
    private float standTime;
    public float startStandTime;
    public Animator anim;



    private void Start()
    {
        standTime = startStandTime;
        randomPlace = Random.Range(0, places.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, places[randomPlace].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, places[randomPlace].position) < 0.2f)
        {
            if(standTime <= 0)
            {
                anim.SetBool("isRuning", true);
                randomPlace = Random.Range(0, places.Length);
                standTime = startStandTime;
            }
            else
            {
                standTime -= Time.deltaTime;
            }
        }
    }
}
