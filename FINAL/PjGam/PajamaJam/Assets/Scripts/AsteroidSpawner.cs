using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {
	public GameObject[] Asteroids;
	const int size = 150;
	// Use this for initialization
	void Start () {

		Spawner ();
	}

	void Spawner(){
		for (int i = 0; i < 100; i++) {
			GameObject inst = (GameObject)Instantiate(Asteroids[i % Asteroids.Length], new Vector3 (Random.Range(-size, size), Random.Range(-size, size), Random.Range(-size, size)), Quaternion.identity);
			inst.transform.Rotate(new Vector3(Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180)));
			inst.tag = "Asteroid";
		}
	}
}
