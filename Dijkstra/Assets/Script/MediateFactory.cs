using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MediateFactory {
	private static GameObject _obj;

	public static bool  isnotnull()
	{
		if(_obj == null)
		{
			return false;
		}
		return true;
	}

	public static void setInstance(GameObject instance)
	{
		_obj = instance;
		Debug.Log ("object name "+ _obj.name);
	}

	public static GameObject getInstance()
	{
		return _obj;	
	}

	public static void setNull()
	{
		_obj = null;
	}

	public static string getName()
	{
		if(isnotnull())
		{
			return "null obj";
		}
		return _obj.name;
	}
}
