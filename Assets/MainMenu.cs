using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;		

public class MainMenu : MonoBehaviour
{
	Scene currentScene;
	static bool tutorialCheck;
	private void Start()
	{
		currentScene = SceneManager.GetActiveScene();
		tutorialCheck = PortalDoor.isCompleted;
	}

	public void PlayGame()
	{
		
		if (currentScene.name == "Menu" && tutorialCheck == false)
			SceneManager.LoadScene("Tutorial");
		else if (currentScene.name == "GameOver" || currentScene.name == "Victory" || currentScene.name == "Menu" && tutorialCheck == true)
			SceneManager.LoadScene("LVL");
	}

	public void Quit()
	{
		Debug.Log("Quitting...");
		Application.Quit();
	}

	public void Easy()
	{
		PlayerPrefs.SetInt("Difficulty", 1);
	}

	public void Normal()
	{
		PlayerPrefs.SetInt("Difficulty", 2);
	}

	public void Hard()
	{
		PlayerPrefs.SetInt("Difficulty", 3);
	}

}
