using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
	public Hero wizard;
	public Transform firstLevel, secondLevel, thirdLevel;
	public int skipTimes = 3;

	// Start is called before the first frame update
	void Start()
    {
		wizard = GetComponent<Hero>();
	}

    // Update is called once per frame
    void Update()
    {
		float horizontal = Input.GetAxis("Horizontal");
		wizard.Move(horizontal);

		if (Input.GetButtonDown("Jump") && wizard.jumpAmount > 0)
		{
			wizard.Jump();
			wizard.jumpAmount--;
		}
				
		if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(wizard.shootingFire && wizard.currentTime >= wizard.activeCooldown)
			{
				wizard.Fire();
			}
			else if(wizard.shootingFire == false && wizard.currentTime >= wizard.iceCooldown)
			{
				wizard.Fire();
			}
		}

		if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse1) && wizard.upgrade == true)
		{
			wizard.SwitchSpell();
		}

		if(skipTimes > 0)
		{
			FastTravel();
		}
				
	}

	void FastTravel()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			wizard.transform.position = firstLevel.position;
			skipTimes--;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			wizard.transform.position = secondLevel.position;
			skipTimes = skipTimes - 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			wizard.transform.position = thirdLevel.position;
			skipTimes = skipTimes - 3;
		}
	}
}
