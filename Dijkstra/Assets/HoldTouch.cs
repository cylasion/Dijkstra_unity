using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTouch : MonoBehaviour {
	private bool FirstClick = true;
	private Vector3 line_Start_position;
	private Vector3 line_Stop_position;
	private LineRenderer LineRendere_temp;
	private GameObject line;
	// Use this for initialization
	void Start () {
		line = getline (Color.white);
		LineRendere_temp = line.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (FirstClick) {
				line_Start_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				line.transform.position = line_Start_position;
				Debug.Log ("start " +line_Start_position);
				FirstClick = false;
			} else {
				line_Stop_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				LineRendere_temp.SetPosition (0, line_Stop_position);
				FirstClick = true;
				DrawLine (line_Start_position, line_Stop_position, Color.white);
				Debug.Log ("stop " +line_Start_position);
			}
		}
	}
	void DrawLine(Vector3 start, Vector3 end, Color color)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}

	GameObject getline(Color color)
	{
		GameObject myLine = new GameObject();
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		return myLine;
	}
}
