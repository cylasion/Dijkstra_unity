using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour {

	public static int NodeCount = 0;

	public Object input;
	private string _name;
	public int Nodeid{ get; set;}
	void Start () {
		MediateFactory.setInstance (gameObject);
		NodeCount++;
		Nodeid = NodeCount;
		// tai sao minh lai cmt dong duoi nhi ????
		//Object input = Resources.Load ("Prefabs/NameInput");
		Instantiate (input);
		//them node ( NodeCount tring Naminput
	}

	void Update () {
		
	}
}
