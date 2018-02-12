using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	[SerializeField] private GameObject tombstonePrefab;
	public bool isDead = false;

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
			isDead = true;
		}
	}

	public void Update() {
		if (isDead) {
			this.transform.Rotate (-1, 0, 0);

			if (this.transform.rotation.eulerAngles.x == 90 || this.transform.rotation.eulerAngles.x == 270) {
				//Kill the target and spawn a tombstone
				createTombstone();
				Destroy(this.gameObject);
			}
		}
	}

	private void createTombstone() {
		var tombstone = Instantiate (tombstonePrefab) as GameObject;
		tombstone.transform.position = transform.position;
	}
}
