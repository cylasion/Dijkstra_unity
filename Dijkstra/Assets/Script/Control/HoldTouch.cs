using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class HoldTouch : MonoBehaviour {
	public GameObject DistanceInput;
	public Text mLog; 
	public Material line_material;
	private bool FirstClick = true;
	private Vector3 line_Start_position;
	private Vector3 line_Stop_position;
	private LineRenderer LineRendere_temp;
	private GameObject line;
	private string Nstart,Nstop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (FirstClick) {
				line_Start_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Nstart = getPointName (line_Start_position);
				FirstClick = false;
				mLog.text = "Name start click :" + Nstart+"/";
			//	Debug.Log ("start click "+line_Start_position);
			} else {
				line_Stop_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//	Debug.Log ("stop click "+line_Stop_position);
				Nstop = getPointName (line_Stop_position);
			
				mLog.text += " Name end click :" + Nstop+"/";

				if(Nstart.Equals("")==false && Nstop.Equals("")==false && Nstart.Equals(Nstop)==false)
				{
					
					Debug.Log ("Name click "+ Nstart+" "+Nstop);
					DrawLine (line_Start_position, line_Stop_position, Color.black);
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
		mLog.text = "Draw Line " + start.ToString () + " " + end.ToString ();



		//lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.material= line_material;
		lr.SetColors(color, color);
		lr.SetWidth(0.25f, 0.25f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);


		GameObject Distance = new GameObject ();
		Distance.name="Distance"; 
		Distance.transform.position = (start + end) / 2;
		Distance.AddComponent<TextMesh> ();
		TextMesh tm = Distance.GetComponent<TextMesh> ();
		tm.text = "";
		tm.color = Color.red;
		tm.fontSize = 20;
		Distance.transform.parent = myLine.transform;
		//mLog.text = " DRAWLINE " + start.ToString () + " " + end.ToString ();
		Instantiate (DistanceInput,myLine.transform.position, Quaternion.identity);
		MediateFactory.setInstance (myLine);

	}


		
	string getPointName(Vector3 position)
	{
		string name = "";

		Ray ray = new Ray (position, Vector3.forward*10000);
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
		//mLog.text = " Ray position: " + position+ " "+name;
		return name;
	}
}
