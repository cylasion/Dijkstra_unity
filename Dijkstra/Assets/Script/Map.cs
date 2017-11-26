using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapLocation{
	
	public string name_A { get; set; }
	public string name_B { get; set; }
	public int id_A{ get; set;}
	public int id_B{ get; set; }
	public int d { get; set; }
	public LineRenderer line { get; set;}


}

public class NameAndId
{
	public string name { get; set; }
	public int id{ get; set; }

	public NameAndId (){ }
	public NameAndId(int id,string name){
		this.id = id;
		this.name = name;
	}

}

 
public static class Map {


	public static void addRootObj(GameObject obj)
	{
		// add object tu holdtoch ( 1 dong lon xon )
		// ham dc goi tu Ditance Input
		LineRenderer lineRe = obj.GetComponent<LineRenderer>();	
		Vector3 Apos = lineRe.GetPosition (0);
		Vector3 Bpos = lineRe.GetPosition (1);

		MapLocation locate = new MapLocation ();

		NameAndId a = getPointNameNId (Apos);
		NameAndId b = getPointNameNId (Bpos);

		locate.id_A = a.id;
		locate.id_B = b.id;
		locate.name_A = a.name;
		locate.name_B = b.name;

		TextMesh tm = obj.GetComponentInChildren<TextMesh> ();
		locate.d = int.Parse (tm.text);
		locate.line = lineRe;
		 
		/*
		if (locate.d % 2==0)
		{
			lineRe.SetColors (Color.cyan,Color.cyan);
		}
*/
		GameObject hoder = GameObject.FindGameObjectWithTag ("Holder");
		NodeHolder mholder = hoder.GetComponent<NodeHolder> ();
		mholder.add (locate);
	}



	static NameAndId getPointNameNId(Vector3 position)
	{
		//copy tu HoldTouch.cs
		string name = null;
		int id = 0;
		Ray ray = new Ray (position, Vector3.forward);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin,ray.direction);
		if(hit.collider!=null)
		{	

			if(hit.collider.gameObject.tag=="Point")
			{
				GameObject hit_obj = hit.collider.gameObject;
				TextMesh TextM = hit_obj.GetComponentInChildren<TextMesh> ();
				PointScript ps = hit_obj.GetComponentInChildren<PointScript> ();
				id = ps.Nodeid;
				name = TextM.text;
			}
			Debug.Log (name);
		}
		NameAndId n = new NameAndId ();
		n.id = id;
		n.name = name;
		return n;
	}
}
