using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class editPanel : MonoBehaviour {
	public string currentID="";
	public InputField itemName;
	public InputField itemBuyPrice;
	public InputField itemSellPrice;
	public InputField itemCount;
	public InputField itemUnit;
	public InputField itemID;
	public Dbconnection db;

	public addItem additemObject;
	// Use this for initialization
	void Start () {
		additemObject = FindObjectOfType<addItem> ();
		db = FindObjectOfType<Dbconnection> ();
	}
	public void setCurrentID(string id){
		this.currentID = id;


	}
	
	
	
	public void edit(){
		
		
		WWWForm form = new WWWForm ();
		form.AddField("ID",currentID);
		form.AddField ("itemCode", itemID.text);
		form.AddField ("itemName", itemName.text);
		form.AddField ("itemBuyPrice", itemBuyPrice.text);
		form.AddField ("itemSellPrice", itemSellPrice.text);
		form.AddField ("itemCount", itemCount.text);
		form.AddField ("itemUnit", itemUnit.text);
		form.AddField ("itemUser", db.LoggedUser [0]);
		//Debug.Log (mainMenu.LoggedUser [0]);
		System.DateTime date = System.DateTime.Now;
		form.AddField ("itemDate", date.Date.ToString("dd/MM/yyyy"));
		print (itemID.text);
		print (itemName.text);
		print (itemBuyPrice.text);
		print (itemSellPrice.text);
		print (itemUnit.text);
		print (db.LoggedUser[0]);
		
		WWW page = new WWW ("http://localhost:8088/Anbar/edititem.php", form);
		//print ("done");
		//yield return page;

		this.gameObject.SetActive (false);
		
		
		additemObject.startCouroutAddItemsToPanel ();
		
		
		
		
		
		
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
