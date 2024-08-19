using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    

    public GameObject geebo_player;
    private Controller controller_script;
    private void Start(){
        controller_script = geebo_player.GetComponent<Controller>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb.velocity.y <= 0)
        {
            Debug.Log("Collision Detected with force: " + controller_script.geebo_force);
            rb.AddForce(Vector3.up * controller_script.geebo_force);
            Debug.Log("Collision Detected");
            rb.gravityScale = controller_script.geebo_gravity;
        }
    }
}
