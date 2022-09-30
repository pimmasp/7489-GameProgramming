using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // [SerializeField] private Collider2D _playerCollider;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private GameManager _gameManager;
    private void Awake() 
    {
        currentHealth = startingHealth;
        Debug.Log(startingHealth);
        Debug.Log(currentHealth);
    }
    public void TakeDamage2(float damge)
    {
        currentHealth -= damge;

        if (currentHealth > 0)
        {
            Debug.Log(startingHealth);
            Debug.Log(currentHealth);
            // _gameManager.ProcessPlayerDeath();
        }
        else
        {
            // Debug.Log(startingHealth);
            // Debug.Log(currentHealth);
            SceneManager.LoadScene(0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage2(1);
    }
}
