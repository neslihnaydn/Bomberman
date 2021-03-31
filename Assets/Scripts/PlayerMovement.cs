using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    static String VERTICAL = "Vertical";
    static String HORIZONTAL = "Horizontal";
    public float moveSpeed = 5f;
    public Animator animator;
    
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw(HORIZONTAL);
        movement.y = Input.GetAxisRaw(VERTICAL);
        animator.SetFloat(HORIZONTAL, movement.x);
        animator.SetFloat(VERTICAL, movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
