using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetStarController : MonoBehaviour
{

	public GameObject starexplosionPrefab;
	
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Ball" )
		{
			if (starexplosionPrefab)
			{
				Instantiate(starexplosionPrefab, transform.position, transform.rotation);

			}
			

			// destroy self
			Destroy(gameObject);
		}
	}
    

}
