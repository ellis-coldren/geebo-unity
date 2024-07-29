using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RemovePlatforms : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private GameObject myPlat;
    private GameObject backupPlat;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        float newPlat_x = player.transform.position.x + Random.Range(-12f, 12f); //needs to be clamped within screen
        float newPlat_y = player.transform.position.y + (29 * Random.Range(0.9f, 1));
        
        if(Random.Range(1, 6) > 1){
            myPlat = GameObject.Instantiate(platformPrefab, new Vector2(Mathf.Clamp(newPlat_x, -10f,20f), newPlat_y), Quaternion.identity);

        } else{
            myPlat = GameObject.Instantiate(springPrefab, new Vector2(Mathf.Clamp(newPlat_x, -10f,20f), newPlat_y), Quaternion.identity);
        }
        
        Destroy(collision.gameObject);
    }
}
