using UnityEngine;
using System.Collections;
using PersianSupportForSilverlight;
using UnityEngine.UI;
public class perisanMakerForInput : MonoBehaviour {
	PersianMaker pm = new PersianMaker();
	InputField myText;
	// Use this for initialization
	void Start () {
		myText = this.GetComponent<InputField> ();

	}
	public void makePersian(){
		print ("happenin");
		myText.text = pm.ToPersian (myText.text).Split ('\n') [1];


	}

	// Update is called once per frame
	void Update () {
	

		//print (myText.text);

	}
}
