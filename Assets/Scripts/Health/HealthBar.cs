using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    [SerializeField] private TextMeshProUGUI lifeText;
    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;   
        lifeText.text = "" + (int)playerHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;   
        lifeText.text =  "Lives " + (int)playerHealth.currentHealth;

    }
}
