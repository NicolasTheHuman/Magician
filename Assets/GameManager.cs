using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Hero wizard;
	public Boss battleMage;
	public GameObject easyLvl, normalLvl, hardLvl;
	
    // Start is called before the first frame update
    void Start()
    {
		easyLvl.SetActive(false);
		normalLvl.SetActive(false);
		hardLvl.SetActive(false);

		Difficulty();
	}

    // Update is called once per frame
    void Update()
    {
		ChangeScene();
    }

	void ChangeScene()
	{
		if (wizard.health <= 0)
			SceneManager.LoadScene("GameOver");
		else if (battleMage.life <= 0)
			SceneManager.LoadScene("Victory");
	}

	void Difficulty()
	{
		switch (PlayerPrefs.GetInt("Difficulty"))
		{
			case 1:
				easyLvl.SetActive(true);
				break;
			case 2:
				normalLvl.SetActive(true);
				break;
			case 3:
				hardLvl.SetActive(true);
				break;
		}
	}

}
