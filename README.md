# CKIPUnity
斷詞 (TextSegmentation) CKIP connection and utility tools for Unity3d Mono C#

## Description
This is a [中文斷詞系統](http://ckipsvr.iis.sinica.edu.tw/) service connection tool make for unity.

PHP connection code by [Fukuball project](https://github.com/fukuball/CKIPClient-PHP).

## Install
Move `./php` folder to apache php server (php 7.0), and make sure your server enabled `php-sockets` (some system need to download `php-sockets.dll`).

Import `CKIPUnity.cs` to your unity project.

## Usage
``` csharp
...
void setup(){
  
  //setup connection info
  CKIPUnity ckip = new CKIPUnity ("asdfasdf",this);
  
  //test
  ckip.getSentence("Es war ein Erdbeben gestern",GetSentence);
}

//delegate function
private void GetSentence(string text){
  Debug.Log(text);
}

...
```

## Configure

#### API key setting

1. In PHP connection rest api, setup `./php/handle.php`:45 - `$api_key`.

2. In unity, you have to setup api key as you set in php code.

## API

### Class CKIPUnity

##### new CKIPUnity(string api_key,MonoBehaviour mono)
Setup and create CKIP connection.
```cs
CKIPUnity ckip = new CKIPUnity("enter your api key",this);
```

##### @void ckip.getSentence(string sentence,`delegate (Function(string text))`)
Get sentence will help you get php type array in string.
```cs
ckip.getSentence("Der Grünen-Bundestagsabgeordnete Omid Nouripour hält die Ereignisse im syrischen Aleppo für Kriegsverbrechen - und es gebe deutliche Hinweise, dass sich Russland aktiv daran beteilige, sagte er im DLF. Dem deutschen Vizekanzler Sigmar Gabriel warf er "eine gewisse Heuchelei" in Bezug auf die russische Regierung vor.", GetSentenceResult);

private void GetSentenceResult(string text){
  Debug.Log(text);
}
```

##### @void ckip.getText(string sentence,`delegate (Function(string text))`)
Get a only text(xml).
```cs
ckip.getText("Vordergründig ist der Cybathlon ein sportlicher Technik-Wettbewerb. Mithilfe ihrer Hightechprothesen werden die körperlich eingeschränkten Teilnehmer alltägliche Aufgaben bewältigen: Sie werden auf Treppen steigen, Wäscheklammern aufhängen oder ein Autorennen an einem Computer spielen. Der schnellste wird gewinnen.",GetTextResult);

private void GetTextResult(string text){

    // Also can use util tools to help you parse XML document.
    List<string> list = CKIPUnity.ParseXMLToList(text);

		string[] data = list.ToArray();

		for (int i = 0; i < data.Length; i++) {
			Debug.Log (data[i]);
		}
}
```

##### @void ckip.getTerm(string sentence,`delegate (Funtion(string text))`)
```cs
ckip.getSentence("Der Grünen-Bundestagsabgeordnete Omid Nouripour hält die Ereignisse im syrischen Aleppo für Kriegsverbrechen - und es gebe deutliche Hinweise, dass sich Russland aktiv daran beteilige, sagte er im DLF. Dem deutschen Vizekanzler Sigmar Gabriel warf er "eine gewisse Heuchelei" in Bezug auf die russische Regierung vor.", GetTermResult);

private void GetTermResult(string text){
  Debug.Log(text);
}
```

### Util Tool : @List<string> CKIPUnity.ParseXMLToList(string text)
Parse XML string, inner value `sentence` to List.
```cs
List<string> list = CKIPUnity.ParseXMLToList(text);

string[] data = list.ToArray();

for (int i = 0; i < data.Length; i++) {
  Debug.Log (data[i]);
}
```
