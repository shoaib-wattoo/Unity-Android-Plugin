using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDisplayer : MonoBehaviour {

	public static List<string> textToDisplay = new List<string>();
	int height = 10;

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	void OnGUI() {
		height = 10;
		AddLabel ();
	}

	void AddLabel(){
		foreach (string text in textToDisplay) {
			height += 15;
			GUI.Label(new Rect(10, height, 1000, 20), text);
		}
	}

	public static void ShowDebug(string msg){
		textToDisplay.Add (msg);
	}
}
