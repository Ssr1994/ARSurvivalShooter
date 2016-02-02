﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartController : MonoBehaviour {
	public int healthPoints = 20;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Player")) {
			PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
			playerHealth.currentHealth += healthPoints;
			if (playerHealth.currentHealth > 100)
				playerHealth.currentHealth = 100;
			playerHealth.healthSlider.value = playerHealth.currentHealth;
			Destroy(gameObject);
		}
	}
}
