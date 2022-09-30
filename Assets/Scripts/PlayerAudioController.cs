using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioclips;

    public void PlayJumpSound() 
    { //Lab5
        audioSource.PlayOneShot(jumpAudioclips.GetAudioClip(), 0.5f);    
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);    
    }
}
