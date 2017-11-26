using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHolder : MonoBehaviour {

	public List<MapLocation> locate;
	public int NumberofLine { get; set; }
	public int NumberofNode { get; set; }
	void Start () {
		locate =  new List<MapLocation> ();
		NumberofLine = 0;
	}  

	public void add(MapLocation lo){
		locate.Add (lo);
		NumberofLine++;
		 
		Debug.Log ("Holder list size " + locate.Capacity + " new: " + lo.id_A + " " + lo.id_B + " " + lo.d);
	}

	void Update () {
		//cho dễ quản lí thui
		NumberofNode = PointScript.NodeCount;
	}

	public List<MapLocation> GetListLine(){
		return locate;
	}
}
