using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AddRemove : MonoBehaviour {
	public GameObject addRemovePanel;
	public Dropdown drop;
	public GameObject myRecord;
	public InputField inputCount;
	private addItem addITEM;
	public InputField targetCode;
	public Dbconnection db;
	// Use this for initialization
	void Start () {
		myRecord = this.transform.parent.transform.parent.gameObject;
		db = FindObjectOfType<Dbconnection> ();
		inputCount = this.transform.GetChild (1).transform.GetChild (2).GetComponent<InputField> ();
		targetCode = this.transform.GetChild (1).transform.GetChild (4).GetComponent<InputField> ();
		addITEM = FindObjectOfType<addItem> ();

	}


	public void showAddRemovePanel(){

		addRemovePanel.SetActive (true);

	} 


	public void startCorAddRemove(){


		StartCoroutine (AddRemoveRecord ());


	}


	public IEnumerator AddRemoveRecord(){

			WWW list = new WWW ("http://localhost:8088/Anbar/showitems.php");
			yield return list;

		string[] items = new string[1000];
		items = list.text.Split (';');

		string ID = myRecord.transform.GetChild (9).transform.GetChild (0).GetComponent<Text> ().text;

		for (int i =0; i< items.Length-1; i++) {
			if(items[i] != null){
				if(items[i].Split('|')[0] == ID){


					int count = int.Parse(items[i].Split('|')[5]);
					int tempCount = count;
					if(drop.value == 0){


						count += int.Parse(inputCount.text);


					}
					if(drop.value == 1){


						count -= int.Parse(inputCount.text);
						if(count < 0){



							print("item can't be removed!");
							break;
						}


					}
					WWWForm form = new WWWForm();
					form.AddField("ID",ID);
					form.AddField("count",count);
					WWW www = new WWW ("http://localhost:8088/Anbar/addremove.php",form);
					yield return www;

					this.transform.GetChild(1).gameObject.SetActive(false);
					addITEM.startCouroutAddItemsToPanel();
					///report


					WWWForm meform = new WWWForm();
					meform.AddField("itemCode",myRecord.transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text);
					meform.AddField("newCount",count);
					meform.AddField("targetCode",targetCode.text);
					meform.AddField("itemName",myRecord.transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text);
					meform.AddField("itemBuyPrice",myRecord.transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text);
					meform.AddField("itemSellPrice",myRecord.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text);
					meform.AddField("oldCount",tempCount);
					meform.AddField("itemUnit",myRecord.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text);


					System.DateTime date = System.DateTime.Now;
					
					System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
					
					meform.AddField ("itemDate", pc.GetYear (date) + "/" + pc.GetMonth (date) + "/" + pc.GetDayOfMonth (date));
					meform.AddField("itemUser",db.LoggedUser[1]);
					print(db.LoggedUser[1]);
					WWW newWWW = new WWW("http://localhost:8088/Anbar/report.php",meform);
					yield return newWWW;
					print(newWWW.text);
					break;


				}







			}
		
		
		
		}









		}
	// Update is called once per frame
	void Update () {
	
	}
}
