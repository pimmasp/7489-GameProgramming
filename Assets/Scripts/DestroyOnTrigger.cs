using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 7f;
    private GameManager _gameManager;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            Destroy(gameObject);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
        
            StartCoroutine(RespawnCollectible());
    }
    private IEnumerator RespawnCollectible()
    {
        yield return new WaitForSeconds(4f);
    }

}
