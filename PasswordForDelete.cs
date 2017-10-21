using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PasswordForDelete : MonoBehaviour {



	public InputField pass;
	Dbconnection controller;

	// Use this for initialization
	void Start () {

		controller = FindObjectOfType<Dbconnection> ();
	}


	public void startCheckPass(){


		StartCoroutine (checkPassword ());


	}

	IEnumerator checkPassword(){

		WWW w = new WWW ("http://localhost:8088/Anbar/Anbar.php");
		yield return w;


		string logInData = w.text;
		string[] users = new string[1000];
		
		users = logInData.Split (';');
		print (controller.LoggedUser [1]);
		print (pass.text);
		for(int i = 0;i<users.Length-1;i++){
			print(users[i]);


			if(controller.LoggedUser[1] == users[i].Split('|')[1]){
			if(users [i].Split ('|') [2] == pass.text){

					print("found");
					this.gameObject.transform.parent.transform.parent.GetComponent<DeleteRecord>().startCouroutDelete();
				this.transform.parent.gameObject.SetActive(false);
				break;
			}

			}
		}





	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
