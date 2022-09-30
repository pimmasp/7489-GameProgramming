using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerBar : MonoBehaviour
{
    private float timer = 30f;
    [SerializeField] private Image timerFill;

    public void ProcessTimer(float currentTimer, float maxTime)
    {
        timer -= Time.deltaTime;

        var percentage = currentTimer / maxTime;
        timerFill.fillAmount = percentage;

        if (timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
}
