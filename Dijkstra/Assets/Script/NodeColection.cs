using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/* claass nay khong dc su dung */






public class NodeColection : MonoBehaviour {

	public  List<NameAndId> colection = new List<NameAndId>();
	public  int NumberofEmplement=0;

	public  void addNode(NameAndId x){
		NumberofEmplement++;
		colection.Add (x);
	}
	public void addNode(string x)
	{
		NumberofEmplement++;
		colection.Add (new NameAndId (NumberofEmplement, x));

	}

	public  int GetIdfromName(string name){
		for(int i=0; i<NumberofEmplement;i++)
		{
			if(colection[i].name.Equals(name)){
				return colection [i].id;
			}
		}
		return 0 ;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
