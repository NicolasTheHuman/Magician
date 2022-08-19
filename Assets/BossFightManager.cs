using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour
{
	EdgeCollider2D edgeCol;
	public GameObject bossMage;
	public PlayerBrain PB;

    // Start is called before the first frame update
    void Start()
    {
		edgeCol = GetComponent<EdgeCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.layer == 10)
		{
			bossMage.SetActive(true);
			edgeCol.enabled = false;
			PB.skipTimes = 0;
		}
	}
}
