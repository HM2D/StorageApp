using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DeleteRecord : MonoBehaviour {
	//public GameObject myID;
	// Use this for initialization
	public string ID;
	public addItem additem;
	public GameObject passwordForDelete;
	void Start () {
	
		additem = FindObjectOfType<addItem> ();
		ID = this.transform.parent.transform.parent.transform.GetChild (9).transform.GetChild (0).GetComponent<Text> ().text;
		Debug.Log (ID);
	
	}


	public void showInputPassword(){
	
		passwordForDelete.SetActive (true);
	
	
	}

	public void startCouroutDelete(){
	
		StartCoroutine (deleteRecord ());
	
	}
	public IEnumerator deleteRecord(){
		WWWForm form = new WWWForm ();

		form.AddField ("ID", ID);



		WWW www = new WWW ("http://localhost:8088/Anbar/deleteitem.php",form);
		yield return www;

		additem.startCouroutAddItemsToPanel ();





	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
