using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Start() 
    {
        // healthCOmponent = gameObject.GetComponent<Health>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            var healthCOmponent = collision.GetComponent<Health>();
            // collision.GetComponent<Health>().TakeDamage2(damage);
            // Debug.Log("11");

            if (healthCOmponent != null)
            {
                healthCOmponent.TakeDamage2(damage);
                Debug.Log("12");

            }
        }
        
    }
}
