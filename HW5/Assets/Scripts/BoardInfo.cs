using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInfo : MonoBehaviour {
	public static int numRows = 2;
	public static int numCols = 3;

	public static float offsetX = 2f;
	public static float offsetY = 2.5f;

	//card size scaling factor
	public static float scaleFactor = 1f;

	void Awake () {
		//persist this object across scenes to transmit info on the board layoutr
		DontDestroyOnLoad (this);
	}

	public void SetRows(int rows) {
		numRows = rows;
		scaleFactor = 2.0f / Mathf.Max (numCols, numRows);;
		offsetY = 5f / (float)rows;
	}

	public void SetCols(int cols) {
		numCols = cols;
		scaleFactor = 2.0f / Mathf.Max (numCols, numRows);;
		offsetX = 8f / (float)cols;
	}
}
