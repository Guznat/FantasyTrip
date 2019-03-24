using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataHolder
{
    public int health;
    public float[] position;

    public DataHolder(PlayerMovment player, Health playerHealth)
    {
        health = playerHealth.health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }


}
