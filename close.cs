using UnityEngine;
using System.Collections;

public class close : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void closemyParent(){

		this.gameObject.transform.parent.gameObject.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
