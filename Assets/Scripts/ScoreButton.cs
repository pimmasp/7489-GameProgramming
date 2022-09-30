using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScoreButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform tweenEndPoint;
    
    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        transform.DOMove(tweenEndPoint.position, 3f).SetEase(Ease.InOutQuint).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        _gameManager.AddScore();
    }

    private void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(2);
        DOTween.KillAll();
    }
}
