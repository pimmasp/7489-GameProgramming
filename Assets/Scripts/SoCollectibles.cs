using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles")]

public class SoCollectibles : ScriptableObject
{
    private string collectibleName;
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite OutlineSprite;
    [SerializeField] private bool Respawnable;
    public string GetCollectible()
    {
        return collectibleName;
    }
}