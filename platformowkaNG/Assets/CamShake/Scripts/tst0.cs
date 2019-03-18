using UnityEngine;
using System.Collections;

public class tst0 : MonoBehaviour {
	public WHCameraRandomShaker		randomShaker;
	// Use this for initialization
	void Start () {
		if( randomShaker==null )
		{
			randomShaker	= GetComponent<WHCameraRandomShaker>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			randomShaker.doRandomShake();
		}
	}
}
