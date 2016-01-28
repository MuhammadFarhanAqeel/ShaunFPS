using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;
    public GameObject responseExplosion;

    public void ReceiveDamage(float hit) 
    {
        health -= hit;
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

}
