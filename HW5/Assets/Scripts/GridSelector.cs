using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridSelector : MonoBehaviour {
	//https://forum.unity.com/threads/send-message-to-other-scene.41224/

	private int buttonWidth;
	private int buttonHeigth;
	private GameObject table;

	void Start () {
		buttonWidth = 50;
		buttonHeigth = 30;

		table = GameObject.Find ("table_top");
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width/4, Screen.height/3, buttonWidth, buttonHeigth), "2x3")) {
			LoadGame (2, 3);
		}

		if (GUI.Button (new Rect (2*Screen.width/4, Screen.height/3, buttonWidth, buttonHeigth), "2x4")) {
			LoadGame (2, 4);
		}

		if (GUI.Button (new Rect (3*Screen.width/4, Screen.height/3, buttonWidth, buttonHeigth), "2x5")) {
			LoadGame (2, 5);
		}

		if (GUI.Button (new Rect (Screen.width/4, 2*Screen.height/3, buttonWidth, buttonHeigth), "3x4")) {
			LoadGame (3, 4);
		}

		if (GUI.Button (new Rect (2*Screen.width/4, 2*Screen.height/3, buttonWidth, buttonHeigth), "4x4")) {
			LoadGame (4, 4);
		}

		if (GUI.Button (new Rect (3*Screen.width/4, 2*Screen.height/3, buttonWidth, buttonHeigth), "4x5")) {
			LoadGame (4, 5);
		}
	}

	private void LoadGame(int rows, int cols) {
		table.SendMessage ("SetRows", rows);
		table.SendMessage ("SetCols", cols);
		SceneManager.LoadScene("Game");
	}
}
