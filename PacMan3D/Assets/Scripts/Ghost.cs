using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
public class Pellet : MonoBehaviour
{
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") 
        {
            ScoreManager.instance.PlayerDie();
            // Destroy(gameObject);
        }
	}
}
}
