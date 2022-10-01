using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public Image lifeBar;
    public Text lifeText;

    public float myLife;

    private float currentLife;
    private float calculateLife;

    private void Update() {
        calculateLife = currentLife / myLife;
        lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, calculateLife, Time.deltaTime);
        lifeText.text = "" + (int)currentLife;


    }

    public void Damage(float damage)
    {
        currentLife -= damage;
    }
}
