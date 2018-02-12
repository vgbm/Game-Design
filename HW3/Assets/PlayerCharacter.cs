using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	private string _healthStr;
	private bool _isDead;

	private Vector2 guiLabelPos;
	private Vector2 guiLabelVeloc;
	private const int guiLabelWidth = 100;
	private const int guiLabelHeight = 50;

	void Start() {
		_health = 5;
		_healthStr = Repeat("* ", _health);
		_isDead = false;
		guiLabelPos = new Vector2 (6 * Screen.width / 7, 10);
		guiLabelVeloc = new Vector2 (-2, 1);
	}

	public void Hurt(int damage) {
		_health -= damage;
		_healthStr = Repeat("* ", _health);

		if (_health <= 0) {
			playerDie ();
		}
	}

	void OnGUI() {
		if (_isDead) {
			guiLabelPos += guiLabelVeloc;

			if (guiLabelPos.x < 0 || guiLabelPos.x > Screen.width - guiLabelWidth) {
				guiLabelVeloc.x = -guiLabelVeloc.x;
			}

			if (guiLabelPos.y < 0 || guiLabelPos.y > Screen.height - guiLabelHeight) {
				guiLabelVeloc.y = -guiLabelVeloc.y;
			}

			guiLabelPos.x = Mathf.Clamp (guiLabelPos.x, 0, Screen.width - guiLabelWidth); 
			guiLabelPos.y = Mathf.Clamp (guiLabelPos.y, 0, Screen.height - guiLabelHeight);
			GUI.Label (new Rect (guiLabelPos.x, guiLabelPos.y, guiLabelWidth, guiLabelHeight), "You have died!");
		} else {
			GUI.Label (new Rect (6 * Screen.width / 7, 10, guiLabelWidth, guiLabelHeight), "Health: " + _healthStr);
		}
	}

	private void playerDie() {
		//stop player from moving
		var fpsInput = GetComponent<FPSInput> ();
		fpsInput.Lock ();

		//stop the player from moving the camera
		var mouseLook = GetComponent<MouseLook> ();
		mouseLook.Lock ();

		_isDead = true;
	}

	private string Repeat(string str, int times) {
		if (times < 1)
			return "";

		var repStr = "";
		for (int i = 0; i < times; i++) {
			repStr += str;
		}

		return repStr;
	}
}
