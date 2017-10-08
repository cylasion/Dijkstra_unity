using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour {

	public Object input;
	private string _name;
	// Use this for initialization
	void Start () {
		MediateFactory.setInstance (gameObject);
		//Object input = Resources.Load ("Prefabs/NameInput");
		Instantiate (input);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
