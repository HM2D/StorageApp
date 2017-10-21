using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PersianSupportForSilverlight;
public class Dbconnection : MonoBehaviour {
	private static Dbconnection instance = null;
	public static Dbconnection Instance {
		get { return instance; }
	}

	void Awake(){
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	public string[] users = new string[20];
	public InputField username;
	public InputField password;
	public string[] LoggedUser = new string[3];
	public Text logginStatus;
	PersianMaker pm = new PersianMaker();
	// Use this for initialization
	IEnumerator Start () {
		//DontDestroyOnLoad (this.gameObject);
		WWW logInInfo = new WWW ("http://localhost:8088/Anbar/anbar.php");
		yield return logInInfo;
		string logInData = logInInfo.text;


		users = logInData.Split (';');
		print (users [1].Split ('|') [2]);
		//checkUsers ();

	}
	public void logOut(){


		LoggedUser [0] = "";
		LoggedUser [1] = "";
		LoggedUser [2] = "";
		Application.LoadLevel ("LogIn");




	}
	public void checkUsers(){


		bool found = false;
		for(int i =0;i <users.Length-1;i++){
			//print (i);
			if(users[i]!=null)
			if(users[i].Split('|')[1] == username.text && users[i].Split('|')[2] == password.text){

				found = true;
			//	print("success");
				LoggedUser[0] = users[i].Split('|')[1];
				LoggedUser[1] = users[i].Split('|')[2];
				LoggedUser[2] = users[i].Split('|')[3];
				//print(users[i].Split('|')[3]);
				Application.LoadLevel("MainMenu");

			}



		}
		if (found == false) {
		
			logginStatus.gameObject.SetActive(true);
		 logginStatus.text = pm.ToPersian("گذرواژه یا پاسورد اشتباه است");
		}




	}

	
	// Update is called once per frame

}
