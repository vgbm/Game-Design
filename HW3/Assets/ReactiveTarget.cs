using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	[SerializeField] private GameObject tombstonePrefab;
	[SerializeField] private GameObject particlePrefab;
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
			this.transform.Rotate (90 * Time.deltaTime, 0, 0);

			if (this.transform.eulerAngles.x > 89) {
				//Kill the target and spawn a tombstone
				createDeathParticles();
				createTombstone();
				Destroy(this.gameObject);
			}
		}
	}
		
	private void createDeathParticles() {
		var particles = Instantiate (particlePrefab) as GameObject;
		particles.transform.position = transform.position;
	}

	private void createTombstone() {
		var tombstone = Instantiate (tombstonePrefab) as GameObject;
		tombstone.transform.position = transform.position;
	}
}
