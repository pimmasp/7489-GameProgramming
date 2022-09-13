using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private enum CollectibleType
    {
        Red,
        Green,
        Blue,
    }

    private Transform player;
    public SpriteRenderer collect;
    public SpriteRenderer playerSprite;

    [SerializeField] CollectibleType collectibleType;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        switch (collectibleType)
            {
                case CollectibleType.Red:
                    playerSprite.color = Color.red;
                    break;
                case CollectibleType.Green:
                    playerSprite.color = Color.green;
                    break;
                case CollectibleType.Blue:
                    playerSprite.color = Color.blue;
                    break;
                // defalt:
                //     break;
            }
            Destroy(gameObject);  
        }
    

    }
