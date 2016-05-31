using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    bool finished = false;
    bool change = false;
    public int nyawa = 3;
	public int counter=0;
    int helper;
    public string angka1="";
    public string angka2="";
    public string operasi="";
    public UnityEngine.UI.Text _Nyawa;
    public GameObject textNyawa;

	// Use this for initialization
	void Start () {
        helper = nyawa;
	}
	
	// Update is called once per frame
	void Update () {
        if (!finished)
        {
//            _Nyawa.text =helper+ "";
            if(nyawa<1){
                textNyawa.SetActive(false);
                finished = true;
            }
            /*
            if (o1.finished && o2.finished && o3.finished) { 
                //line ini isinya code buat destroy gameObject
               // StartCoroutine(nextChange());
                if (change) {
                    o1.gameObject.SetActive(false);
                    o2.gameObject.SetActive(false);
                    o3.gameObject.SetActive(false);
                    change = false;
                    o1.finished = false;
                    o2.finished = false;
                    o3.finished = false; 
                }
            }

            if (o4.finished && o5.finished && o6.finished)
            {
                //line ini isinya code buat destroy gameObject
              //  StartCoroutine(nextChange());
                if (change)
                {
                    o4.gameObject.SetActive(false);
                    o5.gameObject.SetActive(false);
                    o6.gameObject.SetActive(false);
                    change = false;
                    o4.finished = false;
                    o5.finished = false;
                    o6.finished = false;
                }
            }

            if (o7.finished && o8.finished && o9.finished)
            {
                //line ini isinya code buat destroy gameObject
             //   StartCoroutine(nextChange());
                if (change)
                {
                    o7.gameObject.SetActive(false);
                    o8.gameObject.SetActive(false);
                    o9.gameObject.SetActive(false);
                    change = false;
                    o7.finished = false;
                    o8.finished = false;
                    o9.finished = false;
                }
            }

            if (o10.finished && o11.finished && o12.finished)
            {
                //line ini isinya code buat destroy gameObject
               // StartCoroutine(nextChange());
                if (change)
                {
                    o10.gameObject.SetActive(false);
                    o11.gameObject.SetActive(false);
                    o12.gameObject.SetActive(false);
                    change = false;
                    o10.finished = false;
                    o11.finished = false;
                    o12.finished = false;
                }
            }

            if (o13.finished && o14.finished && o15.finished)
            {
                //line ini isinya code buat destroy gameObject
               // StartCoroutine(nextChange());
                if (change)
                {
                    o13.gameObject.SetActive(false);
                    o14.gameObject.SetActive(false);
                    o15.gameObject.SetActive(false);
                    change = false;
                    o13.finished = false;
                    o14.finished = false;
                    o15.finished = false;
                }
            }
            */
        }


	}

    /* IEnumerator nextChange() {
         if (!change) {
             yield return new WaitForSeconds(5f);
             change = true;
         }
     }*/
}
