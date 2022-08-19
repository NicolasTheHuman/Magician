using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
	public Text myText;
	public Transform secondLevel;
	public Transform thirdLevel;
	public Hero wizard;
	float currentTime;
	float maxTime;
	int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
		myText.enabled = false;
		maxTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
		
		myText.text = "Level " + currentLevel;

		currentTime += Time.deltaTime;

		if (currentTime >= maxTime)
			myText.enabled = false;

		ChangePosition();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		currentTime = 0f;
		if(collision.transform.tag == "Player")
		{
			currentLevel++;
			myText.enabled = true;
		}
	}

	void ChangePosition()
	{
		if (currentLevel == 1)
			transform.position = secondLevel.transform.position;
		else if (currentLevel == 2)
			transform.position = thirdLevel.transform.position;
		else if (currentLevel > 3)
			myText.enabled = false;

		if(wizard.transform.position.x < transform.position.x)
		{
			transform.position = secondLevel.transform.position;
			currentLevel++;
		}
		else if(wizard.transform.position.x < secondLevel.transform.position.x)
			transform.position = thirdLevel.transform.position;
		
		
	}
}
