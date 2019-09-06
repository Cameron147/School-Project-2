using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Ded");
        Destroy(col.collider.gameObject);
        
    }

}
