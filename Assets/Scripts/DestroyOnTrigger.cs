using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 7f;
    [SerializeField] private GameObject OnEnableItem;


    public void start()
    {
        StartCoroutine(RespawnCollectible());
    }
    private IEnumerator RespawnCollectible()
    {
        yield return new WaitForSeconds(4f);
        spawnItem();
    }

    private void spawnItem()
    {
        Instantiate(OnEnableItem);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
            // spriteRenderer.enabled = false;
;
    }

}
