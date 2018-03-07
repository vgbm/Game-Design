using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGamePopup : MonoBehaviour {

	public void Open() {
		gameObject.SetActive(true);
	}

	public void Close() {
		gameObject.SetActive(false);
	}

	public void Play() {
		var controller = GameObject.Find ("Controller");
		controller.SendMessage ("SpawnAllEnemies");
		Close ();
	}

	public void Quit() {
		Close ();
		Application.Quit ();
	}
}