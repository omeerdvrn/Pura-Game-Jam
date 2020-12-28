using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStarControl : MonoBehaviour
{
    public Text score;
	public int scoreAmount = 0;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag =="Star")
		{
				scoreAmount++;
				score.text = scoreAmount.ToString();
			

		}
	}
}
