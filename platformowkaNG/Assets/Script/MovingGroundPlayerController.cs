using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroundPlayerController : MonoBehaviour
{
    public GameObject Player;
    
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I HYC O PODŁOGE I DZIECKO KURWA JEST");
            Player.transform.parent = gameObject.transform.parent;
        }
   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I NIE MA DZIECKA");
        Player.transform.parent = null;
    }

  
}
