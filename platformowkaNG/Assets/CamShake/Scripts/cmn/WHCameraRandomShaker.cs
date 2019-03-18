using UnityEngine;
using System.Collections;

/// <summary>
/// Name: WHCameraRandomShaker
/// Function: control multiple shakers
/// Author: Wei Hua
/// Last Modification: 2014-01-17
/// Log:
/// </summary>
public class WHCameraRandomShaker : MonoBehaviour {
	public static WHCameraRandomShaker	instance;
	public float			minScale	= 0.5f;
	public float			maxScale	= 2f;
	public WHCameraShake[]	shakers;

	public bool	shakeOnStart			= false;

	void Start () {
		instance		= this;
#if UNITY_EDITOR
		if( Application.isEditor )		// to test shaker instanctly in editor by enable/disable
		{
			shakeOnStart	= true;
		}
#endif
		if( shakers==null || shakers.Length==0 )
		{
			// auto search shakers
			shakers	= GetComponentsInChildren<WHCameraShake>();
		}
	}
#if UNITY_EDITOR
	void OnEnable()
	{
		if( Application.isPlaying && shakeOnStart )
		{
			doShake();
		}
	}
#endif
	public void doShake () {
		for(int i=0;i<shakers.Length;i++)
		{
			shakers[i].doShake();
		}
	}
	public void doRandomShake () {
		for(int i=0;i<shakers.Length;i++)
		{
			shakers[i].doRandomShake(minScale, maxScale);
		}
	}
}
