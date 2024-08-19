using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float geebo_force = 1600;
    public float geebo_gravity = 15;
    private float moveInput;
    private float speed = 10;
    public GameObject windowPrefab;
    private GameObject windowPane;
    public GameObject planePrefab;
    private GameObject plane;
    public GameObject smokePrefab;
    private GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() //physics go in FixedUpdate
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput*speed, rb2d.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        BoxCollider2D my_collider;
        if (collision.gameObject.tag == "Window"){

            my_collider = collision.gameObject.GetComponent<BoxCollider2D>();
            my_collider.enabled = false;

            //Debug.Log(collision.gameObject.tag + " with x " + collision.transform.position.x + " and y " + collision.transform.position.y);
            windowPane = GameObject.Instantiate(windowPrefab, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            int score = ScoreManager.instance.AddPoint();
            if (score % 15 == 0){
                geebo_force = Math.Min(geebo_force*1.1f, 1600f);
                geebo_gravity = Math.Min(geebo_gravity*1.2f, 15f);
                speed = Math.Min(speed*1.1f, 20f);
            }
            if (score % 10 == 0) {
                plane = GameObject.Instantiate(planePrefab, new Vector2(35f, collision.transform.position.y + 35f), Quaternion.identity);
                smoke = GameObject.Instantiate(smokePrefab, new Vector2(55f, collision.transform.position.y + 70f), Quaternion.identity);
            }
            
        }
    }
}
