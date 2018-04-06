using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnityAndroidBridge : MonoBehaviour {

	public static UnityAndroidBridge instance;
	private AndroidJavaObject javaObj = null;
	private AndroidJavaObject activityContext = null;
	string[] mylist;
	int count ;
	AndroidJavaClass pluginClass;

	public Text text;

//	List<CalEvents> birthdays = new List<CalEvents>();

	void Start(){
		instance = this;
		ShowToast ();
		ReadData ();
		WriteData ();
		//GetData ();
	}

	public void ShowToast () {
		text.text = text.text + "\nCalling ShowToast()";
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.bugdev.asus.app_2.AndroidUnity")) {
			if(pluginClass != null) {
				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
				javaObj.Call("setContext", activityContext);
				activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
					javaObj.Call("showMessage", "Yeah its working");
				}));
			}
		}
	}

	public void ReadData () {
		text.text = text.text + "\nCalling ReadData()";
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.bugdev.asus.app_2.AndroidUnity")) {
			if(pluginClass != null) {
				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
				javaObj.Call("setContext", activityContext);
				activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
					string data = javaObj.Call<string>("ReadData","com.bugdev.androidplugin");
					text.text = text.text + "\nData : " + data;
				}));
			}
		}
	}

	public void WriteData () {
		text.text = text.text + "\nCalling WriteData()";
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.bugdev.asus.app_2.AndroidUnity")) {
			if(pluginClass != null) {
				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
				javaObj.Call("setContext", activityContext);
				activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
					string data = javaObj.Call<string>("WriteData", "Unity App - 1");
					text.text = text.text + "\nData : " + data;
				}));
			}
		}
	}

	public void GetData(){

		GUIDisplayer.ShowDebug ("Calling GetData()");
		Debug.Log ("Calling GetData()");
		text.text = text.text + "\nCalling GetData()";
		#if UNITY_ANDROID

		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(pluginClass = new AndroidJavaClass("com.bugdev.asus.app_2.MainActivity")) {
			if(pluginClass != null) {
				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
				javaObj.Call("setContext", activityContext);

				string data = javaObj.Call<string>("GetData");
				Debug.Log("Data : " + data);
				GUIDisplayer.ShowDebug("Data : " + data);
				text.text = text.text + "\nData : " + data;
			}
		}
		#endif
	}

//	public List<CalEvents> GetBirthdays () {
//
//		#if UNITY_ANDROID
//
//		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
//			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
//		}
//
//		using(pluginClass = new AndroidJavaClass("unityplugin.bugdev.com.unityplugin3.CalendarContentResolver")) {
//			if(pluginClass != null) {
//				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
//				javaObj.Call("setContext", activityContext);
//
//				mylist = javaObj.Call<string[]>("ListEvents");
//
////				activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
////					mylist = javaObj.Call<string[]>("ListEvents");
////				}));
//			}
////			Debug.Log ("List Count is here : " + mylist.Length);
//			foreach(string e in mylist){
//				string lowerCase = e.ToLower();
//				if (lowerCase.Contains ("birthday")) {
//
//					string[] splitString = e.Split ('*');
////					Debug.Log (e);
//
//					string[] date = splitString [2].Split ('-');
//					DateTime newDate = new DateTime (int.Parse (date [2]), int.Parse (date [1]), int.Parse (date [0]));
//
////					Debug.Log ("DAte is : " + newDate.Date);
//
//					CalEvents ev = new CalEvents (int.Parse (splitString [0]), splitString [1], newDate.Date, splitString [3]);
//					birthdays.Add (ev);
//
////					Debug.Log (ev.id + " | " + ev.name + " | " + ev.date);
//				}
//			}
////			Debug.Log ("List Count : + " + birthdays.Count);
//		}
//		return birthdays;
//
//		#endif
//	}

	public void ShowToast1(){

		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(AndroidJavaClass pluginClass = new AndroidJavaClass("unityplugin.bugdev.com.unityplugin3.CalendarContentResolver")) {
			if(pluginClass != null) {
				javaObj = pluginClass.CallStatic<AndroidJavaObject>("instance");
				javaObj.Call("setContext", activityContext);
				activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
					javaObj.Call("ShowToast", activityContext);
				}));
			}
		}

	}
}