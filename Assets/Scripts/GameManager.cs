using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    [SerializeField] private float roundTime = 30f;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private TimerBar timerBar;
    [SerializeField] [ReadonlyInspector] private float roundTimer = 0;
    [SerializeField] [ReadonlyInspector] private int score = 0;

    private bool _isGameOver;    
    private Health _health;
    
    
    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        UpdateScore();

    }

    // public void TakeDamage3
    // {

    // }

    public void ProcessPlayerDeath()
    {
        // _health.TakeDamage2(1);

        SceneManager.LoadScene(GetCurrentBuildIndex());
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
    private void Update()
    {
        ProcessRoundTimer();
    }


    private void ProcessRoundTimer()
    {
        roundTimer = Mathf.Max(0f, roundTimer - Time.deltaTime);
        timerBar.ProcessTimer(roundTimer, roundTime);

        if (roundTimer > 0) return;

        if (_isGameOver) return;
        
        RestartGame();
    }
    
    private void RestartGame()
    {
        score = 0;
        UpdateScore();
        roundTimer = roundTime;
        _isGameOver = false;
    }
    
    public void AddScore()
    {
        score += 1;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreDisplay.UpdateScore(score);
    }
    
    }
