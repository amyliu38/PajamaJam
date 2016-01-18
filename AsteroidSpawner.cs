using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {
	GameObject[] Asteroids;
	const int size = 100;
	// Use this for initialization
	void Start () {
		Asteroids = GetComponentsInChildren<GameObject> ();
		Spawner ();
	}

	void Spawner(){
		for (int i = 0; i < 50; i++) {
			Instantiate(Asteroids[i%4], new Vector3 (Random.Range(-size, size), Random.Range(-size, size), Random.Range(-size, size)), Quaternion.identity);
		}
	}
}
