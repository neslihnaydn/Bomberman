using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player" && GameObject.FindGameObjectWithTag("Player") != null) 
        {
			// collider.gameObject.GetComponent<PlayerLife> ().LoseLife ();
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            // Invoke("LoadScene", 1);
            LoadScene();
		}
	}

    void LoadScene() 
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
