using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10;
    public GameObject windowPrefab;
    private GameObject windowPane;
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
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Window"){
            windowPane = GameObject.Instantiate(windowPrefab, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
            //Iterate score!!
        }
    }
}
