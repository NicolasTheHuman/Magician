using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalDoor : MonoBehaviour
{
	public float maxTime = 17f;
	public static bool isCompleted;

	float currentTime;

	Scene currentScene;

	private void Start()
	{
		currentScene = SceneManager.GetActiveScene();
		isCompleted = false;
	}

	private void Update()
	{
		currentTime += Time.deltaTime;
		ChangeScene();
	}

	//this only works for the first cutscene
	void ChangeScene()
	{
		if (currentScene.name == "Intro")
		{
			if (currentTime >= maxTime)
				SceneManager.LoadScene("Menu");
		}
	}

  	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 10)
		{
			SceneManager.LoadScene("LVL");
			isCompleted = true;
		}
	}
}
