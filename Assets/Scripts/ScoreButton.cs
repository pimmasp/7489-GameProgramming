using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScoreButton : MonoBehaviour
{
    
    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        transform.DOMoveY(1f, 3f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

}
