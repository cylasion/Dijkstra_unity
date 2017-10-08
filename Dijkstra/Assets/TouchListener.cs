using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : MonoBehaviour {
	 
	public Object prefab;

	private bool onclick = false;
	private float time_runing;
	private float time_for_doubleclick; 
	private float delay = 0.2f;


	void Start () {
			
	}
	
	void Update () {
		DoubleclickListener ();

	}

	public void DoubleclickListener()
	{
		if(MediateFactory.isnotnull()==false)
		if(Input.GetMouseButtonDown(0))
		{
			if (!onclick) {
				onclick = true;
				time_for_doubleclick = Time.time;
			} else {
				onclick = false;
				DoDoubleclick ();
			}
		}
		if(onclick){
			if(Time.time - time_for_doubleclick > delay)
			{
				onclick = false;
			}
		}
	}

	public void DoDoubleclick()
	{


		Debug.Log ("D click "+Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin,ray.direction);

		if(hit.collider!=null)
		{	
			Debug.Log ("Hit ");
			string name = "";
			if(hit.collider.gameObject.tag=="Point")
			{
				GameObject hit_obj = hit.collider.gameObject;
				TextMesh TextM = hit_obj.GetComponentInChildren<TextMesh> ();
				name = TextM.text;
				GameObject.Destroy (hit_obj);
			}
			Debug.Log (name);
		}

		Vector3 taget = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		taget.z = transform.position.z;
		Instantiate (prefab, taget, Quaternion.identity);
	}
}
 