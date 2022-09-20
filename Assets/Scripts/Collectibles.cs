using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private SoCollectibles collectibleObject;

    private void Start() 
    {
        Debug.Log(collectibleObject.GetCollectible());
    }


    
    /*public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        return collectibleType;
    }

    public void SetCollectibleType(CollectibleType value)
    {
        collectibleType = value;
    }*/
}
