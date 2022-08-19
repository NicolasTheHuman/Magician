using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
	public GameObject objectToSpawn;

	public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Destroy(objectToSpawn, 4f);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		offset = transform.position - collision.transform.position;

		if(collision.gameObject.layer == 8)
		{
			Instantiate(objectToSpawn, collision.transform.position + offset, collision.transform.rotation);
		}
	}

}
