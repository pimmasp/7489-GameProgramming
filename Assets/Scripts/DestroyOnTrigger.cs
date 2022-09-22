using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 7f;
    [SerializeField] private GameObject OnEnableItem;
    public bool ActivateOnStart = true;
    public float ActivationDelay = 4f; 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
            // spriteRenderer.enabled = false;
        gameObject.SetActive(false);
        Debug.Log("Pick Me DDDD");

        if (ActivateOnStart) ActivateDelayed();
        

    }
    private void AfterDelay()
    {
        gameObject.SetActive(true);
    }

    /*
     * Activates the object after the configured delay
     */
    public void ActivateDelayed()
    {
        Invoke(nameof(AfterDelay), ActivationDelay);
    } 
}
