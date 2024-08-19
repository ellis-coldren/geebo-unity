using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFly : MonoBehaviour
{
    
    void FixedUpdate() {
        float new_x = this.transform.position.x - 0.5f;
        this.transform.position = new Vector3(new_x, this.transform.position.y, this.transform.position.z);
    }
}
