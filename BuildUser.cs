using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuildUser : MonoBehaviour {
	public InputField username;
	public InputField password;
	public Dropdown role;
	public GameObject makeUserPanel;

	// Use this for initialization
	void Start () {
	
	}
	public void ShowMakeUserPanel(){
	
		makeUserPanel.SetActive (true);
	
	}
	public void makeUser(){

		WWWForm form = new WWWForm();
		form.AddField ("username",username.text);
		form.AddField ("password",password.text);
		form.AddField ("role", role.value+1);
		WWW www = new WWW ("http://localhost:8088/Anbar/insertdata.php", form);
		makeUserPanel.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
