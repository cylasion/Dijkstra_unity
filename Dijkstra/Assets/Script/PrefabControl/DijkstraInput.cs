using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DijkstraInput : MonoBehaviour {
	

	public Button btOk;
	public Button btCancel;
	public InputField inStart;
	public InputField inStop;
	private NodeHolder hoder;
	 
	// Use this for initialization
	void Start () {
		GameObject obj =  GameObject.FindGameObjectWithTag ("Holder");
		hoder = obj.GetComponent<NodeHolder> ();
		btOk.onClick.AddListener (StartClick);
	}

	public void StartClick(){
		Debug.Log ("Do dijkstra");
		int s = getIdfromName(inStart.text);
		int t = getIdfromName (inStop.text);
		Dijkstra dij = new Dijkstra ();
		dij.Prepair (hoder.NumberofNode, hoder.NumberofLine, s, t);
		List<MapLocation> list = hoder.GetListLine ();
		for(int i=0;i<hoder.NumberofLine;i++){
			dij.addLine (list [i].id_A, list [i].id_B, list [i].d);
			Debug.Log (" list i ="+i+" value "+list [i].id_A+" "+list [i].id_B+" "+list [i].d);
		}
		dij.DoDijkstra ();
		dij.UpdateResult (list, s, t );
		Destroy (gameObject);
	}

	private int getIdfromName(string name){
		List<MapLocation> list = hoder.GetListLine ();
		for(int i = 0 ; i< hoder.NumberofLine;i++)
		{
			if (list [i].name_A.Equals (name))
				return list [i].id_A;
			if (list [i].name_B.Equals (name))
				return list [i].id_B;
		}
		return 0;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
