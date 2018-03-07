﻿using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	Animator anim;
	GameObject controller;

	void Start(){
		controller = GameObject.Find ("Controller");
		anim = GetComponent<Animator>();
	}


	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		controller.SendMessage ("DecreaseEnemyCount");
		this.transform.Rotate(-75, 0, 0);
		anim.SetInteger("zombieToState", 2);
		
		yield return new WaitForSeconds(1.5f);
		
		Destroy(this.gameObject);
	}
}
