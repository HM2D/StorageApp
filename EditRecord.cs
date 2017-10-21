using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PersianSupportForSilverlight;
public class EditRecord : MonoBehaviour {
	addItem additemObject = new addItem();
	GameObject myRecord;
	Dbconnection db = new Dbconnection();
	public InputField itemName;
	public InputField itemBuyPrice;
	public InputField itemSellPrice;
	public InputField itemCount;
	public InputField itemUnit;
	public InputField itemID;
	public GameObject editPanel;
	public editPanel editPanelScript;
	public PersianMaker pm = new PersianMaker ();
	string id;
	// Use this for initialization
	void Start () {

		myRecord = this.transform.parent.transform.parent.gameObject;
		id = myRecord.transform.GetChild (9).transform.GetChild(0).GetComponent<Text>().text;
		db = FindObjectOfType<Dbconnection> ();
		editPanel = this.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.GetChild (4).gameObject; 

		additemObject = FindObjectOfType<addItem> ();
	
		itemName = editPanel.transform.GetChild (2).GetComponent<InputField> ();
		itemID = editPanel.transform.GetChild (1).GetComponent<InputField> ();
		itemBuyPrice = editPanel.transform.GetChild (3).GetComponent<InputField> ();
		itemSellPrice = editPanel.transform.GetChild (4).GetComponent<InputField> ();
		itemCount = editPanel.transform.GetChild (5).GetComponent<InputField> ();
		itemUnit = editPanel.transform.GetChild (6).GetComponent<InputField> ();
	
	
	
	}



	public void  editPanelShow(){

		editPanel.gameObject.SetActive (true);
		print (myRecord.transform.GetChild (7).transform.GetChild (0).GetComponent<Text> ().text);
		itemName.text = myRecord.transform.GetChild (7).transform.GetChild (0).GetComponent<Text> ().text;
		itemBuyPrice.text = myRecord.transform.GetChild (6).transform.GetChild (0).GetComponent<Text> ().text;
		itemSellPrice.text = myRecord.transform.GetChild (5).transform.GetChild (0).GetComponent<Text> ().text;
		itemCount.text = myRecord.transform.GetChild (4).transform.GetChild (0).GetComponent<Text> ().text;
		itemUnit.text = myRecord.transform.GetChild (3).transform.GetChild (0).GetComponent<Text> ().text;
		itemID.text = myRecord.transform.GetChild (8).transform.GetChild (0).GetComponent<Text> ().text;
		editPanelScript = editPanel.GetComponent<editPanel> ();
		editPanelScript.currentID = id;

	}



	// Update is called once per frame
	void Update () {
	
	}
}
