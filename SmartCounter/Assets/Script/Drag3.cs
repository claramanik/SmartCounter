using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Drag3 : MonoBehaviour {
	private Vector3 touchOffset;
	private Vector3 backPos;
	private Vector3 screenPoint;
	public Controller controller;
	public bool finished=false;
	public string angka1; //angka pertama yang dipilih, lalu cast ke int
	public string angka2; //angka kedua yang dipilih, lalu cast ke int
	public string operasi; //cast ke operasi + ,- , *, /
	//public string jawaban; // jawaban yang diharapkan, cast ke int
	public static string hasilInput; // hasil operasi angka1 dan angka2 yang dipilih pemain
	public string hasil;
	private GameObject batas;
	private int cekSalah=0;
	bool benar = false;
	public int jawaban =0;
	public static int temp;
	public Text txt;

	
	void Start() {
		backPos = this.transform.position;
		jawaban = Random.Range (1,17);
		GetComponent<TextMesh> ().text = jawaban.ToString();
		temp = jawaban;
	}
	void Update(){
		txt.text = temp.ToString ();
		
	}
	void OnMouseDown() {
		touchOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseUp()
	{
		//cuma nge-drag tapi ga masuk ke kotak baru kembalikan ke posisi awal
		if ((controller.angka1 == "") && (controller.operasi == "") && (controller.angka2==""))
		{
			this.transform.position = backPos;
		}
		else if((controller.angka1 != "") && (controller.operasi != "") && (controller.angka2!=""))
		{
			Debug.Log(controller.angka1 + " " +controller.operasi+ " " +controller.angka2);
			//UNTUK OPERASI PENJUMLAHAN
			if (controller.operasi == "+")
			{
				hasil = tambah(controller.angka1, controller.angka2); //tambaahhh
				Debug.Log("jumlah input="+hasil);
				//cek jawaban
				if (cekJawaban()){
					Debug.Log("BENAR!!");
					NtahApaScript.counter = NtahApaScript.counter + 1;
					Debug.Log("jumlah benar= "+NtahApaScript.counter);
					if(NtahApaScript.counter==5){
						finished = true;
						Application.LoadLevel("win");
						NtahApaScript.counter=0;
						NtahApaScript.counterSlh=0;
					}else {
						Application.LoadLevel("level3");
					}
				}else {
					Debug.Log("SALAH!!");
					NtahApaScript.counterSlh = NtahApaScript.counterSlh + 1;
					Debug.Log("ini counter salah "+NtahApaScript.counterSlh);
					if(NtahApaScript.counterSlh==3){
						Debug.Log("masuk script pertambahan salah ");
						Application.LoadLevel("gameover");
					}// finished = false;
					else{
						Application.LoadLevel("level3");
					}
				}
			}
			
			//untuk operasi PENGURANGAN
			if (controller.operasi == "-")
			{
				hasil = kurang(controller.angka1, controller.angka2); //tambaahhh
				Debug.Log("jumlah input="+hasil);
				//cek jawaban
				if (cekJawaban()){
					Debug.Log("BENAR!!");
					NtahApaScript.counter = NtahApaScript.counter + 1;
					Debug.Log("jumlah benar= "+NtahApaScript.counter);
					if(NtahApaScript.counter==5){
						finished = true;
						Application.LoadLevel("win");
						NtahApaScript.counter=0;
						NtahApaScript.counterSlh=0;
					}else {
						Application.LoadLevel("level3");
					}
				}else {
					Debug.Log("SALAH!!");
					NtahApaScript.counterSlh = NtahApaScript.counterSlh + 1;
					Debug.Log("ini counter salah "+NtahApaScript.counterSlh);
					if(NtahApaScript.counterSlh==3){
						Debug.Log("masuk script pertambahan salah ");
						Application.LoadLevel("gameover");
					}// finished = false;
					else{
						Application.LoadLevel("level3");
					}
				}
			}
		}
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + touchOffset;
		transform.position = curPosition;
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name.Equals("batas"))
		{
			this.transform.position = backPos;
		}
		hasilInput = collision.gameObject.name;
		if (hasilInput.Equals("angka1") && this.gameObject.name.StartsWith("jawab"))
		{
			//tinggal dibuat jika satu masukkan ke angka 1
			controller.angka1 = this.gameObject.name.Substring(hasilInput.Length - 1);            
			this.transform.position = collision.gameObject.transform.position;
		}
		if(hasilInput.Equals("angka2") && this.gameObject.name.StartsWith("jawab")){
			controller.angka2 = this.gameObject.name.Substring(hasilInput.Length - 1);
			this.transform.position = collision.gameObject.transform.position;
		}
		else if (hasilInput.StartsWith("operasi") && this.gameObject.name.StartsWith("simbol"))
		{
			controller.operasi = this.gameObject.name.Substring(hasilInput.Length - 1);
			this.transform.position = collision.gameObject.transform.position;
		}
	}
	
	void OnCollisionExit(Collision collision) {
		//        hasilInput = "";
	}
	
	//controller
	//nanti butuh fungsi untuk hitung countBenar, kalo countBenar < 3, mati
	//memang harus di cast buk, jadi pakailah string angka1,angka2, hasilInputan ama jawaban
	
	public  string tambah(string x, string y)
	{//fungsi parse masih salah
		int o1 = int.Parse(x);
		int o2 = int.Parse(y);
		int hasil = o1 + o2;
		
		Drag3.hasilInput = hasil.ToString();
		return Drag3.hasilInput;
	}
	
	public  string kurang(string x, string y)
	{
		//string b = "2";
		int o1 = int.Parse(x);
		int o2 = int.Parse(y);
		int hasil = o1-o2;
		Drag3.hasilInput = hasil.ToString();
		return Drag3.hasilInput;
	}
	
	
	public  bool cekJawaban() { 
		Debug.Log ("Ini fungsinya gan");
		Debug.Log ("hasil Input : " + hasilInput);
		Debug.Log ("jawaban Random : " + temp );
		if (hasilInput == temp.ToString()) {
			//NtahApaScript.counter = NtahApaScript.counter +1;
			//Debug.Log("Cek benar disini"+counterBnr);
			return true;
		}
		else{
			Debug.Log("berhasil return false");
			return false;
		}
	}
}
