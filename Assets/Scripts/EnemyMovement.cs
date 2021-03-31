using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    private Vector2 positionOrigin;
    private Vector2 positionDisplacement;

    private float _timePassed;

    void Start()
    {
        positionOrigin = enemy.transform.position;
        float randomDistance = Random.Range(-50f, 50f);
        positionDisplacement = new Vector2(randomDistance, randomDistance);
    }

    public void Update()
    {
        float x = positionOrigin.x + Mathf.PingPong(Time.time * speed, 6);
        enemy.GetComponent<Rigidbody2D>().MovePosition(new Vector2(x, enemy.transform.position.y));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collision detacted");
    }
}
