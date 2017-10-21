using UnityEngine;
using System.Collections;
using System.Globalization;

public class MainMenuController : MonoBehaviour {
	public Dbconnection mydbScript;
	public GameObject makeUser;
	// Use this for initialization
	IEnumerator Start () {
//		System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
		
//		print (pc.GetYear (DateTime.Now) + "/" + pc.GetMonth (DateTime.Now) + "/" + pc.GetDayOfMonth (DateTime.Now));


		mydbScript = FindObjectOfType<Dbconnection> ();
		yield return mydbScript;
		if (mydbScript.LoggedUser[2] == "1") {

			makeUser.gameObject.SetActive(true);
		
		}

	
	
	
	}


	public void logOut(){


		mydbScript.LoggedUser [0] = "";
		mydbScript.LoggedUser [1] = "";
		mydbScript.LoggedUser [2] = "";
		Application.LoadLevel ("LogIn");


	}


	// Update is called once per frame
	void Update () {
	
	}
}
