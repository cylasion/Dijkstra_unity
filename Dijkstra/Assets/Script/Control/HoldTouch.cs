﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTouch : MonoBehaviour {
	public Object prefab;
	private bool FirstClick = true;
	private Vector3 line_Start_position;
	private Vector3 line_Stop_position;
	private LineRenderer LineRendere_temp;
	private GameObject line;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (FirstClick) {
				line_Start_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				FirstClick = false;
			//	Debug.Log ("start click "+line_Start_position);
			} else {
				line_Stop_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//	Debug.Log ("stop click "+line_Stop_position);
				string Nstart = getPointName (line_Start_position);
				string Nstop = getPointName (line_Stop_position);
				if(Nstart != null && Nstop != null && Nstart != Nstop)
				{
					Debug.Log ("Name click "+ Nstart+" "+Nstop);
					DrawLine (line_Start_position, line_Stop_position, Color.white);

				}
				FirstClick = true;
			}
		}
	}
	void DrawLine(Vector3 start, Vector3 end, Color color)
	{
		MediateFactory.setNull ();
		GameObject myLine = new GameObject();
		myLine.name="Line";
		start.z = 0;
		end.z = 0;
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.5f, 0.5f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);


		GameObject Distance = new GameObject ();
		Distance.name="Distance";
		Distance.transform.position = (start + end) / 2;
		Distance.AddComponent<TextMesh> ();
		TextMesh tm = Distance.GetComponent<TextMesh> ();
		tm.text = "";
		tm.color = Color.blue;
		tm.fontSize = 50;
		Distance.transform.parent = myLine.transform;

		Instantiate (prefab,myLine.transform.position, Quaternion.identity);
		MediateFactory.setInstance (myLine);
	}
		
	string getPointName(Vector3 position)
	{
		string name = null;

		Ray ray = new Ray (position, Vector3.forward);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin,ray.direction);
		if(hit.collider!=null)
		{	
			
			if(hit.collider.gameObject.tag=="Point")
			{
				GameObject hit_obj = hit.collider.gameObject;
				TextMesh TextM = hit_obj.GetComponentInChildren<TextMesh> ();
				name = TextM.text;
			}
			Debug.Log (name);
		}
		return name;
	}
}
