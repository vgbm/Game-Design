using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private int enemiesToSpawn;
	//private GameObject _enemy;

	void Start() {
		// spawn n zombies
		for (int i = 0; i < enemiesToSpawn; i++) {
			SpawnEnemy ();
		}
	}

	void Update() {
		
	}

	private GameObject SpawnEnemy() {
		var enemy = Instantiate (enemyPrefab) as GameObject;
		enemy.transform.position = new Vector3 (Random.Range(-10, 10), 0, Random.Range(-10, 10));
		float angle = Random.Range (0, 360);
		enemy.transform.Rotate (0, angle, 0);
		enemy.GetComponent<WanderingAI> ().SetAlive (true);

		return enemy;
	}
}
