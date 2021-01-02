using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 200f;
    float playerInitialGravityScale;
    
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0) {
            currentTime = startingTime;
            SceneManager.LoadScene("GameOverScene");
            // FindObjectOfType<GameManager>().EndGame();
        }
        GetComponent<Text>().text = "Timer: " + currentTime.ToString("0");
    }
}