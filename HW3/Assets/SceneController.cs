using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private List<GameObject> _enemies = new List<GameObject>();
	private int enemyCount = 1;

	void Start() {
		_enemies.Add(createNewEnemy());
	}

	void Update() {
		//remove the dead and gone enemies from the scene's list
		_enemies.RemoveAll (enemy => enemy == null);

		//add any new enemies to the scene
		if (_enemies.Count < enemyCount) {
			_enemies.Add(createNewEnemy());
			_enemies.Add(createNewEnemy());
			enemyCount += 1;

		}
	}

	private GameObject createNewEnemy() {
		var newEnemy = Instantiate (enemyPrefab) as GameObject;
		newEnemy.transform.position = new Vector3(0, 1, 0);
		float angle = Random.Range(0, 360);
		newEnemy.transform.Rotate(0, angle, 0);

		return newEnemy;
	}
}
