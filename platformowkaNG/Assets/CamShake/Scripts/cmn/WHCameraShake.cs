//#define	VERBOSE		// define this when you want to see more runtime params in editor
#define	DEMO		// define this in our demo project

using UnityEngine;
using System.Collections;

/// <summary>
/// Name: WHCameraShake
/// Function: Shake camera (or any GameObject) using Hooke's theorem
/// Author: Wei Hua
/// Last Modification: 2014-01-17
/// Log:
/// </summary>
public class WHCameraShake : MonoBehaviour {
#if !DEMO
	[HideInInspector]
#endif
	/// <summary>
	/// if set, copy shake factors from the other. This is used for demonstration.
	/// </summary>
	public WHCameraShake	copyFromOther;
	/// <summary>
	/// The position speed.
	/// Shake in this initial velocity
	/// </summary>
	public Vector3	posSpeed	= new Vector3(0,100f,0);
	/// <summary>
	/// The rotition speed.
	/// Shake in this initial angular velocity
	/// </summary>
	public Vector3	rotSpeed	= Vector3.zero;
	/// <summary>
	/// The hooke factor. If set 0, in Awake it will be calculated from posSpeed
	/// </summary>
	public float	Hooke		= 0;
	/// <summary>
	/// The hooke factor for rotition. If set 0, in Awake it will be calculated from rotSpeed
	/// </summary>
	public float	HookeRot	= 0;
	/// <summary>
	/// The position damping factor.
	/// </summary>
	public float	posDamping	= 0.9f;
	/// <summary>
	/// The rotition damping factor.
	/// </summary>
	public float	rotDamping	= 0.9f;
	/// <summary>
	/// posSpeed0 and posSpeed0 are just public for editor display
	/// </summary>
#if VERBOSE && UNITY_EDITOR
	public Vector3	posSpeed0;
	public Vector3	rotSpeed0;
	public	float	delay0;
#else
	private Vector3	posSpeed0;
	private Vector3	rotSpeed0;
	private	float	delay0;
#endif
	private	bool	posover = true;
	private	bool	rotover = true;
	private Vector3	axis;
	private Vector3	axisRot;
	private float	curPos;
	private float	curRot;
	private float	curPosSpeed;
	private float	curRotSpeed;
	//
	const float		cminPos	= 0.001f;
	const float		cminRot	= 0.001f;
	public	bool	shakeOnStart	= false;
	public float		delay		= 0;
	private float	curDelay	= 0;
	void Awake () {
		if(Hooke<0.001f)
		{
			Hooke		= 10f*posSpeed.magnitude;
		}
		if(HookeRot<0.001f)
		{
			HookeRot	= 0.5f*rotSpeed.magnitude;
		}
	}
	void CopyFrom(WHCameraShake other)
	{
		posSpeed	= other.posSpeed;
		rotSpeed	= other.rotSpeed;
		Hooke		= other.Hooke;
		HookeRot	= other.HookeRot;
		posDamping	= other.posDamping;
		rotDamping	= other.rotDamping;
	}
	void Start () {
		if( copyFromOther!=null )
		{
			CopyFrom(copyFromOther);
		}
		posSpeed0		= posSpeed;
		rotSpeed0		= rotSpeed;
		delay0			= delay;
		#if UNITY_EDITOR
		if( Application.isEditor )		// to test shaker instanctly in editor by enable/disable
		{
			shakeOnStart	= true;
		}
#endif
	}
	// using FixedUpdate is for accurate shake effects
	void FixedUpdate () {
		float	dt	= Time.fixedDeltaTime;
		if( curDelay>0 )
		{
			curDelay	-= dt;
			if( curDelay>0 )
			{
				// still need delay
				return;
			}
		}
		if(!posover)
		{
			if( Mathf.Abs(curPos)<cminPos && Mathf.Abs(curPosSpeed)<cminPos )
			{
				transform.localPosition	= Vector3.zero;
				curPos					= 0;
				curPosSpeed				= 0;
				posover					= true;
			}
			else
			{
				transform.localPosition	= curPos * axis;
				curPosSpeed				+= -curPos*Hooke*dt;
				curPosSpeed				*= posDamping;
				curPos					+= curPosSpeed*dt;
//Debug.Log(">>>>:"+Time.frameCount+"curPosSpeed:"+curPosSpeed);
			}
		}
		if(!rotover)
		{
			if( Mathf.Abs(curRot)<cminRot && Mathf.Abs(curRotSpeed)<cminRot )
			{
				transform.localRotation	= Quaternion.identity;
				curRot					= 0;
				curRotSpeed				= 0;
				rotover					= true;
			}
			else
			{
				transform.localRotation	= Quaternion.Euler(curRot * axisRot);
				curRotSpeed				+= -curRot*HookeRot*dt;
				curRotSpeed				*= rotDamping;
				curRot					+= curRotSpeed*dt;
			}
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
		curDelay	= delay;
		axis		= posSpeed.normalized;
		axisRot		= rotSpeed.normalized;
		curPosSpeed	= posSpeed.magnitude;
		curRotSpeed	= rotSpeed.magnitude;
		curPos		= 0;
		curRot		= 0;
		posover		= false;
		rotover		= false;
	}
	public	void doShake (Vector3 _speed, float _hooke, Vector3 _rotspeed, float _hookerot) {
		posSpeed	= _speed;
		Hooke		= _hooke;
		rotSpeed	= _rotspeed;
		HookeRot	= _hookerot;
		doShake();
	}
	public  void doRandomShake (float _speed, float _hooke, float _rotspeed, float _hookerot) {
		doShake(new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized * _speed
			, _hooke
			, new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized * _rotspeed
			, _hookerot
			);
	}
	public static int  randSign()
	{
		int	s	= Random.Range(0,1+1);
		return	s==0 ? -1 : 1;
	}
	public	void doRandomShake (float minScale, float maxScale)
	{
		posSpeed	= randSign()*posSpeed0*Random.Range(minScale,maxScale);
		rotSpeed	= randSign()*rotSpeed0*Random.Range(minScale,maxScale);
		if( delay0>0 )
		{
			delay	= delay0 * Random.Range(minScale,maxScale);
		}
		doShake();
	}
}
