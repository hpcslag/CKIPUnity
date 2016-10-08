using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class Usage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		CKIPUnity ckip = new CKIPUnity ("asdfasdf",this);

		ckip.getText ("你好，這裡是一個程式碼的測試",GetText);
		ckip.getTerm ("你好，這裡是一個程式碼的測試",GetTerm);
    		ckip.getSentence("你好，這裡是一個程式碼的測試",GetSentence);

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void GetSentence(string text){
		Debug.Log (text);
	}
  
  public void GetTerm(string text){
		Debug.Log (text);
	}
  
  public void GetText(string text){
    List<string> list = CKIPUnity.ParseXMLToList(text);

		string[] data = list.ToArray();

		for (int i = 0; i < data.Length; i++) {
			Debug.Log (data[i]);
		}
  }

}
