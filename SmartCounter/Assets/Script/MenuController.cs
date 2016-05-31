using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	//private AudioSingleton menuClick; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void clickStart() {
		Application.LoadLevel ("level1");
	}

	public void clickAbout(){
		Application.LoadLevel ("about");
	}

	public void clickHelp(){
		Application.LoadLevel ("help");
	}

}
