using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RemovePlatforms : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject windowPrefab;
    public GameObject window_lighton_Prefab;
    private GameObject myPlat;
    private GameObject backupPlat;
    private GameObject windowPane;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        BoxCollider2D my_collider;
        float newPlat_x = collision.transform.position.x;
        float newPlat_y = collision.transform.position.y + 62.5f;
        
        
        if(collision.gameObject.tag == "Platform") {
            if(Random.Range(1, 6) > 1){
                myPlat = GameObject.Instantiate(platformPrefab, new Vector2(newPlat_x, newPlat_y), Quaternion.identity);
                Bounce platformScript = myPlat.GetComponent<Bounce>();
                platformScript.geebo_player = player;
            } else{
                myPlat = GameObject.Instantiate(springPrefab, new Vector2(newPlat_x, newPlat_y), Quaternion.identity);
                BigBounce platformScript = myPlat.GetComponent<BigBounce>();
                platformScript.geebo_player = player;
            }

            
            if(Random.Range(1, 6) > 1) {
                windowPane = GameObject.Instantiate(windowPrefab, new Vector2(newPlat_x, newPlat_y + 5), Quaternion.identity);
            } else {
                windowPane = GameObject.Instantiate(window_lighton_Prefab, new Vector2(newPlat_x, newPlat_y + 5), Quaternion.identity);
            }
        }

        my_collider = collision.gameObject.GetComponent<BoxCollider2D>();
        my_collider.enabled = false;
    }
}
