using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    [SerializeField] private float roundTime = 30f;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private TimerBar timerBar;
    [SerializeField] [ReadonlyInspector] private float roundTimer = 0;
    [SerializeField] [ReadonlyInspector] private int score = 0;

    public TextMeshProUGUI lifeText;
    private bool _isGameOver;    
    // private Health _health;
    public float playerHP = 3f;
    
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

        // UpdateScore();

    }

    private void Start() 
    {
        lifeText = FindObjectOfType<TextMeshProUGUI>();
    }

    // public void TakeDamage3
    // {

    // }

    public void ProcessPlayerDeath()
    {
        // _health.TakeDamage2(1);
        playerHP -= 1; 
        if (playerHP >= 1)
        {
            SceneManager.LoadScene(GetCurrentBuildIndex());
        }
        else if (playerHP == 0)
        {        
            SceneManager.LoadScene(0);
        }    

        DOTween.KillAll();


    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;

        }
        
        SceneManager.LoadScene(nextSceneIndex);
        DOTween.KillAll();
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
    private void Update()
    {
        lifeText.text = "Lives: " + playerHP;

        if (GetCurrentBuildIndex() == 0)
        {
            playerHP = 3;
            DOTween.KillAll();
            Destroy(gameObject);
        }
        // ProcessRoundTimer();
    }


    // private void ProcessRoundTimer()
    // {
    //     roundTimer = Mathf.Max(0f, roundTimer - Time.deltaTime);
    //     timerBar.ProcessTimer(roundTimer, roundTime);

    //     if (roundTimer > 0) return;

    //     if (_isGameOver) return;
        
    //     RestartGame();
    // }
    
    
    }
