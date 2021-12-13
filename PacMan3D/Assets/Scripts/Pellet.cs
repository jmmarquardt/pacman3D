using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") 
        {
            ScoreManager.instance.PelletEat();
            Destroy(gameObject);
        }
	}
}
