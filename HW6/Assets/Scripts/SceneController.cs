using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private EndGamePopup endGamePopup;
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private int enemiesToSpawn;
	private int enemiesRemaining;

	void Start() {
		endGamePopup.Close ();
		SpawnAllEnemies ();
	}

	public void DecreaseEnemyCount() {
		enemiesRemaining--;

		if (enemiesRemaining == 0) {
			endGamePopup.Open ();
		}
	}

	private void SpawnAllEnemies() {
		// take care of any rounding errors
		enemiesRemaining = 4 * (enemiesToSpawn / 4);

		// spawn zombies in main arena area
		for (int i = 0; i < enemiesToSpawn / 4; i++) {
			SpawnEnemy (-9, 9, -14, 14);
		}

		// spawn zombies in far end
		for (int i = 0; i < enemiesToSpawn / 4; i++) {
			SpawnEnemy (-18, 18, -19, -23);
		}

		// spawn zombies on left 
		for (int i = 0; i < enemiesToSpawn / 4; i++) {
			SpawnEnemy (14, 22, -12, 12);
		}

		// spawn zombies on right
		for (int i = 0; i < enemiesToSpawn / 4; i++) {
			SpawnEnemy (-14, -22, -12, 12);
		}
	}

	private GameObject SpawnEnemy(int minX, int maxX, int minZ, int maxZ) {
		var enemy = Instantiate (enemyPrefab) as GameObject;
		enemy.transform.position = new Vector3 (Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
		float angle = Random.Range (0, 360);
		enemy.transform.Rotate (0, angle, 0);
		enemy.GetComponent<WanderingAI> ().SetAlive (true);

		return enemy;
	}
}
