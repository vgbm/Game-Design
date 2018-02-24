using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInfo : MonoBehaviour {
	public static int numRows = 2;
	public static int numCols = 3;
	public static float offsetX = 2f;
	public static float offsetY = 2.5f;

	//TODO change card size to make board fit
	public static float scaleX = 1f;
	public static float scaleY = 1f;

	void Awake () {
		//persist this object across scenes to transmit info on the board layoutr
		DontDestroyOnLoad (this);
	}

	public void SetRows(int rows) {
		numRows = rows;
		scaleY = 2.0f / (float) rows;
		offsetY = scaleY + .5f;
	}

	public void SetCols(int cols) {
		numCols = cols;
		scaleX = 2.0f / (float) cols;
		offsetX = scaleX + .5f;
	}
}
