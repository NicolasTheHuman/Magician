using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
	public GameObject hazardToSpawn;
	public float spawnTime;
	float currentTime;
	SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
		spawnTime = Random.Range(1f, 3.5f);
		sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;

		if(currentTime >= spawnTime)
		{
			GameObject tempHazard = Instantiate(hazardToSpawn, transform.position, transform.rotation);
			Destroy(tempHazard, 1.5f);
			currentTime = 0f;
		}

		if(currentTime >= 1f)
			sr.color = Color.white;
		else if (currentTime < 1f)
		    sr.color = Color.black;
		
    }
}
