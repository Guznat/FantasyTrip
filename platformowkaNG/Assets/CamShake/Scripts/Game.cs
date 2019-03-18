using UnityEngine;
using System.Collections;

[System.Serializable]
public class ObjShake {
	public WHCameraShake	shakeYellow;
	public WHCameraShake	shakeGreen;
	public WHCameraShake	shakeRed;
	public WHCameraRandomShaker	shakeRand;
}
public class Game : MonoBehaviour {
	public	ObjShake	ojbShake;
	public	ObjShake	camShake;
	private	ObjShake	curOS;
	// Use this for initialization
	private	bool	chkShakeCam	= false;
	void Start () {
		SetShake();
	}
	void SetShake () {
		if( chkShakeCam )
		{
			curOS	= camShake;
		}
		else
		{
			curOS	= ojbShake;
		}
	}
	delegate float GET_VALUE();
	delegate void SET_VALUE(float val);
	void showValueStepper(string label, float min, float max, float step, GET_VALUE getValFunc, SET_VALUE setValFunc)
	{
		float	curVal	= getValFunc();
		GUI.color	= Color.black;
		GUILayout.Space(30f);
		GUILayout.BeginHorizontal( GUILayout.Width(240f) );
		GUILayout.Label(label, GUILayout.Width(80f));
		if( GUILayout.Button("<<", GUILayout.Width(30f)) )
		{
			curVal	-= step;
			if( curVal<min )
			{
				curVal	= min;
			}
			else
			{
				curVal	= Mathf.Round(curVal/step)*step;
			}
			setValFunc(curVal);
		}
		GUILayout.Space(10f);
		GUILayout.Label(curVal.ToString(), GUILayout.Width(60));
		if( GUILayout.Button(">>", GUILayout.Width(30f)) )
		{
			curVal	+= step;
			if( curVal>max )
			{
				curVal	= max;
			}
			else
			{
				curVal	= Mathf.Round(curVal/step)*step;
			}
			setValFunc(curVal);
		}
		GUILayout.EndHorizontal();
	}
	float	MyRoundFloat(float val)
	{
		return	Mathf.Round(val/0.1f)*0.1f;
	}
	//
	float getValueYellow()
	{
		return	MyRoundFloat(ojbShake.shakeYellow.posSpeed.y);
	}
	void setValueYellow(float val)
	{
		ojbShake.shakeYellow.posSpeed.y	= val;
		camShake.shakeYellow.posSpeed.y	= val;
	}
	float getValueYellowDamp()
	{
		return	ojbShake.shakeYellow.posDamping;
	}
	void setValueYellowDamp(float val)
	{
		ojbShake.shakeYellow.posDamping	= val;
		camShake.shakeYellow.posDamping	= val;
	}
	//
	float getValueGreen()
	{
		return	MyRoundFloat(ojbShake.shakeGreen.rotSpeed.y);
	}
	void setValueGreen(float val)
	{
		ojbShake.shakeGreen.rotSpeed.y	= val;
		camShake.shakeGreen.rotSpeed.y	= val;
	}
	float getValueGreenDamp()
	{
		return	ojbShake.shakeGreen.rotDamping;
	}
	void setValueGreenDamp(float val)
	{
		ojbShake.shakeGreen.rotDamping	= val;
		camShake.shakeGreen.rotDamping	= val;
	}
	//
	float getValueRed()
	{
		return	MyRoundFloat(ojbShake.shakeRed.posSpeed.x);
	}
	void setValueRed(float val)
	{
		ojbShake.shakeRed.posSpeed.x	= val;
		camShake.shakeRed.posSpeed.x	= val;
	}
	float getValueRedDamp()
	{
		return	ojbShake.shakeRed.posDamping;
	}
	void setValueRedDamp(float val)
	{
		ojbShake.shakeRed.posDamping	= val;
		camShake.shakeRed.posDamping	= val;
	}

	void OnGUI () {
		string	ext	= chkShakeCam?"Cam":"";
		GUILayout.BeginHorizontal(GUILayout.Width (400f));
		GUI.color	= Color.yellow;
		if( GUILayout.Button("shakeYellow"+ext, GUILayout.Width(120f)) )
		{
			curOS.shakeYellow.doShake();
		}
		showValueStepper("YSpeed:", -200f, 200f, 10f, getValueYellow, setValueYellow);
		showValueStepper("Damping:", 0.6f, 0.99f, 0.02f, getValueYellowDamp, setValueYellowDamp);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal(GUILayout.Width (400f));
		GUI.color	= Color.green;
		if( GUILayout.Button("shakeGreen"+ext, GUILayout.Width(120f)) )
		{
			curOS.shakeGreen.doShake();
		}
		showValueStepper("RSpeed:", 600f, 3600f, 100f, getValueGreen, setValueGreen);
		showValueStepper("Damping:", 0.6f, 0.99f, 0.02f, getValueGreenDamp, setValueGreenDamp);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal(GUILayout.Width (400f));
		GUI.color	= Color.red;
		if( GUILayout.Button("shakeRed"+ext, GUILayout.Width(120f)) )
		{
			curOS.shakeRed.doShake();
		}
		showValueStepper("XSpeed:", -400f, 400f, 10f, getValueRed, setValueRed);
		showValueStepper("Damping:", 0.6f, 0.99f, 0.02f, getValueRedDamp, setValueRedDamp);
		GUILayout.EndHorizontal();

		GUI.color	= Color.white;
		if( GUILayout.Button("shakeAll"+ext, GUILayout.Width(120f)) )
		{
			curOS.shakeRand.doShake();
		}
		if( GUILayout.Button("shakeAllRandom"+ext, GUILayout.Width(120f)) )
		{
			curOS.shakeRand.doRandomShake();
		}
		GUILayout.BeginHorizontal(GUILayout.Width(120f));
		if( GUILayout.Button(chkShakeCam?"X":" ") || GUILayout.Button("ShakeCam") )
		{
			chkShakeCam	= !chkShakeCam;
			SetShake();
		}
		GUILayout.EndHorizontal();
	}
}
