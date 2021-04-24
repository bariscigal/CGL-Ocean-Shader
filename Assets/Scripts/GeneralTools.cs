using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

//using OnePF;

public static class GeneralTools {

	public static float Remap (this float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public static int Remap (this int value, int from1, int to1, int from2, int to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public static bool sendBroadcastAll(string message){
		GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
		foreach (GameObject go in gos) {
			if (go && go.transform.parent == null) {
				go.gameObject.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
			}
		}
		return true;
	}

	public static bool sendBroadcastAll(string message,object parameter){
		GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
		foreach (GameObject go in gos) {
			if (go && go.transform.parent == null) {
				go.gameObject.BroadcastMessage(message, parameter, SendMessageOptions.DontRequireReceiver);
			}
		}
		return true;
	}
	public static string FormatTime (float time)
	{
		//int intTime = Mathf.RoundToInt(time);
		float minutes  = time / 60f;
		float seconds = time % 60f;
		float fraction = time * 1000f;
		fraction = fraction % 1000f;
		string timeText = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds,fraction);
		return timeText;
	}




}

