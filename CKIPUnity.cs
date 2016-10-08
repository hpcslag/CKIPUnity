using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Collections;

public class CKIPUnity{

	public delegate void GetItemCatelogReceiver(string text);

	private string api_key;
	private MonoBehaviour mono;
	public CKIPUnity(string api_key,MonoBehaviour mono){
		this.api_key = api_key;
		this.mono = mono;
	}

	public void getSentence(string text,GetItemCatelogReceiver _GetItemCatelogReceiver){
		mono.StartCoroutine(sendWWWForm(text,"sentence",_GetItemCatelogReceiver));
	}

	public void getText(string text,GetItemCatelogReceiver _GetItemCatelogReceiver){
		mono.StartCoroutine(sendWWWForm(text,"text",_GetItemCatelogReceiver));
	}

	public void getTerm(string text,GetItemCatelogReceiver _GetItemCatelogReceiver){
		mono.StartCoroutine(sendWWWForm(text,"term",_GetItemCatelogReceiver));
	}

	private IEnumerator sendWWWForm(string text,string type,GetItemCatelogReceiver _GetItemCatelogReceiver){
		WWWForm form = new WWWForm();
		form.AddField("api_key",this.api_key);
		form.AddField("raw_text", text);
		form.AddField("type", type);

		WWW www = new WWW("http://255.255.255.255/CKIP/handle.php", form);
		yield return www;

		_GetItemCatelogReceiver(www.text);
	}

	public static List<string> ParseXMLToList(string text){

		//var str = @"<?xml version=""1.0"" ?><wordsegmentation version=""0.1""><processstatus code=""0"">Success</processstatus><result><sentence>　你(N)　好(Vi)　，(COMMACATEGORY)</sentence><sentence>　這裡(N)　是(Vt)　一(DET)　個(M)　程式碼(N)　的(T)　測試(N)</sentence></result></wordsegmentation>";
		var str = @text;
		var doc = new XmlDocument();
		doc.LoadXml(str);

		var nodes = doc.SelectNodes("/wordsegmentation/result/sentence");


		List<string> list = new List<string>();

		for (int i = 0; i < nodes.Count; i++) {
			list.Add (nodes.Item(i).InnerText);
		}

		return list;
	}

}
