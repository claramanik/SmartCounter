using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timeLeft = 5f;
	public Text text;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "Timer: " + Mathf.Round (timeLeft);
		if (timeLeft < 0) {                  
			if(Time.timeScale == 1){
				Time.timeScale = 0;
				Application.LoadLevel ("gameover");
			}
		}
	}

}
