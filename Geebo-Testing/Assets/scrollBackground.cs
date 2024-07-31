using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float parallaxEffect; // Factor by which the background moves

    private float length, startPos; // Variables to store the length of the background and its starting position

    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y; // Get the length of the background
    }
    void Update()
    {
        float temp = (player.transform.position.y * (1 - parallaxEffect)); // Calculate temporary position
        float dist = (player.transform.position.y * parallaxEffect); // Calculate the distance for parallax effect

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z); // Move the background

        // If the background is far enough, reset its position
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
