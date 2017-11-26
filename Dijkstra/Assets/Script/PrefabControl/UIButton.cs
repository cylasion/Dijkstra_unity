using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	private Button btDodijkstra; 
	private NodeHolder hoder;
	public GameObject input_Prefab;
	void Start () {
		
		btDodijkstra = gameObject.GetComponentInChildren<Button> ();
		btDodijkstra.onClick.AddListener (DoDij);

		GameObject obj =  GameObject.FindGameObjectWithTag ("Holder");
		hoder = obj.GetComponent<NodeHolder> ();
	}

	private void DoDij(){
		Debug.Log ("Do dijkstra on click listener "+input_Prefab.ToString());
	/*	Dijkstra dij = new Dijkstra ();
		dij.Prepair (hoder.NumberofNode, hoder.NumberofLine, 1, hoder.NumberofNode);
		List<MapLocation> list = hoder.GetListLine ();
		for(int i=0;i<hoder.NumberofLine;i++){
			dij.addLine (list [i].id_A, list [i].id_B, list [i].d);
			Debug.Log (" list i ="+i+" value "+list [i].id_A+" "+list [i].id_B+" "+list [i].d);
		}
		dij.DoDijkstra ();
		dij.UpdateResult (list, 0, hoder.NumberofNode );*/
		Instantiate (input_Prefab);
	}
	
	void Update () {
		
	}
}
