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
				StartCoroutine (createDeathParticles());
				createTombstone ();
				Destroy(this.gameObject);
			}
		}
	}
		
	private IEnumerator createDeathParticles() {
		var particles = Instantiate (particlePrefab) as GameObject;
		particles.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);

		yield return new WaitForSeconds (0.5f);

		Destroy (particles);
	}

	private void createTombstone() {
		var tombstone = Instantiate (tombstonePrefab) as GameObject;
		tombstone.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
	}
}
