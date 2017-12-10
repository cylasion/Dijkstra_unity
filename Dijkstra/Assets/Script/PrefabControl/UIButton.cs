using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour {

	public Button btDodijkstra; 
	public Button btRefesh;
	private NodeHolder hoder;
	public GameObject input_Prefab;

	void Start () {
		
		btDodijkstra.onClick.AddListener (DoDij);
		btRefesh.onClick.AddListener (Refesh);

	}

	private void DoDij(){
		Debug.Log ("Do dijkstra on click listener "+input_Prefab.ToString());
		Instantiate (input_Prefab);
	}
	private void Refesh(){
		SceneManager.LoadScene (0);
	}
	
	void Update () {
		
	}
}
