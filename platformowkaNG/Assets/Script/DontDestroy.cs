using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField]
    private string targetTag;

    void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag(targetTag);
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}

