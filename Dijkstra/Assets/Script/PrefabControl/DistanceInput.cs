using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceInput : MonoBehaviour {

	public Button btOk;
	public Button btCancel; 
	public InputField inField;
	private string _distance;

	void Start () {
		Debug.Log ("Name input is created");
		Button _btok = btOk.GetComponent<Button> ();
		Button _btcancel = btCancel.GetComponent<Button> ();
		_btok.onClick.AddListener (btOkOnClick);
		_btcancel.onClick.AddListener (btCancelOnCick);
	}
	void btOkOnClick()
	{
		_distance = inField.text;
		GameObject obj = MediateFactory.getInstance ();
		TextMesh TextM = obj.GetComponentInChildren<TextMesh> ();
		TextM.text = _distance;
		Map.addRootObj (obj);
		MediateFactory.setNull ();
		GameObject.Destroy (gameObject);
	}
	void btCancelOnCick()
	{
		GameObject obj = MediateFactory.getInstance ();
		GameObject.Destroy (gameObject);
		GameObject.Destroy (obj);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
