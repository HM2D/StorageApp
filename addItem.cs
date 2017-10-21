using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;
using PersianSupportForSilverlight;
public class addItem : MonoBehaviour {

	public GameObject addpanel;
	public Dbconnection mainMenu;
	public InputField itemID;
	public InputField itemName;
	public InputField itemBuyPrice;
	public InputField itemSellPrice;
	public InputField itemCount;
	public InputField itemUnit;
	public GameObject itemsPanel;

	public GameObject grid;
	PersianMaker pm = new PersianMaker();
	string[] items = new string[1000];
	void Start(){


		mainMenu = FindObjectOfType<Dbconnection> ();


	}
	public void showAddPanel(){



		addpanel.SetActive (true);
		
		itemID.text = "";
		 itemName.text = "";
		itemBuyPrice.text = "";
		itemSellPrice.text = "";
		itemCount.text = "";
		itemUnit.text = "";

	}

	public void showItemPanel(){

		itemsPanel.SetActive (true);
		StartCoroutine(addItemsToPanel ());




	}
	public void startCouroutAddItemsToPanel(){
	
		StartCoroutine (addItemsToPanel ());
	
	}

	public IEnumerator addItemsToPanel(){

		yield return new WaitForSeconds (0.1f);
		WWW list = new WWW ("http://localhost:8088/Anbar/showitems.php");
		yield return list;
		if (grid.transform.childCount > 1) {
			for (int i=1; i<grid.transform.childCount; i++) {
				Destroy (grid.transform.GetChild (i).gameObject);
		
		
		
			}
		}

		items = list.text.Split (';');
		//print (items [0]);
		for(int i =0;i<items.Length-1;i++){

			GameObject temp = (GameObject)Instantiate(Resources.Load("Record"));
			temp.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[8];
			temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[7];
			temp.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[6];
			temp.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[5];
			temp.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[4];
			temp.transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[3];
			temp.transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[2];
			temp.transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[1];
			temp.transform.GetChild(9).transform.GetChild(0).GetComponent<Text>().text = items[i].Split('|')[0];
			temp.transform.SetParent(grid.transform);
			temp.transform.localScale = new Vector3(1,1,1);

		}


	}
	public void AddItemToDB(){


		WWWForm form = new WWWForm ();
		print (pm.ToPersian (itemName.text).Split('\n')[1]);
		form.AddField ("itemCode", itemID.text);
		form.AddField ("itemName", pm.ToPersian(itemName.text).Split('\n')[1]);
		form.AddField ("itemBuyPrice", itemBuyPrice.text);
		form.AddField ("itemSellPrice", itemSellPrice.text);
		form.AddField ("itemCount", itemCount.text);
		form.AddField ("itemUnit", itemUnit.text);
		form.AddField ("itemUser", mainMenu.LoggedUser [0]);
		//Debug.Log (mainMenu.LoggedUser [0]);
		System.DateTime date = System.DateTime.Now;

		System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

		form.AddField ("itemDate", pc.GetYear (date) + "/" + pc.GetMonth (date) + "/" + pc.GetDayOfMonth (date));


		
		WWWForm meform = new WWWForm();
		meform.AddField("itemCode",itemID.text);
		meform.AddField("newCount","");
		meform.AddField("targetCode","");
		meform.AddField("itemName",pm.ToPersian(itemName.text).Split('\n')[1]);
		meform.AddField ("itemBuyPrice", itemBuyPrice.text);
		meform.AddField ("itemSellPrice", itemSellPrice.text);
		print (itemCount.text);
		meform.AddField("oldCount",itemCount.text);
		meform.AddField("itemUnit",itemUnit.text);
		
		
		
		meform.AddField ("itemDate", pc.GetYear (date) + "/" + pc.GetMonth (date) + "/" + pc.GetDayOfMonth (date));
		meform.AddField("itemUser",mainMenu.LoggedUser[0]);
		




		WWW page = new WWW ("http://localhost:8088/Anbar/additem.php", form);



		WWW newWWW = new WWW("http://localhost:8088/Anbar/report.php",meform);

		//print ("done");

//		print (newWWW.text);
		addpanel.SetActive (false);


		StartCoroutine (addItemsToPanel ());


	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
