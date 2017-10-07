using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputScript : MonoBehaviour {

	public Button btOk;
	public Button btCancel;
	public InputField inField;
	private string _name;

	void Start () {
		Debug.Log ("Name input is created");
		Button _btok = btOk.GetComponent<Button> ();
		Button _btcancel = btCancel.GetComponent<Button> ();
		_btok.onClick.AddListener (btOkOnClick);
	}

	void btOkOnClick()
	{
		_name = inField.text;
		GameObject obj = MediateFactory.getInstance ();
		Debug.Log (obj.name);
		TextMesh TextM = obj.GetComponentInChildren<TextMesh> ();
		TextM.text = _name;

		MediateFactory.setNull ();
		GameObject.Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
