using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioclips;
    [SerializeField] private SoAudioClips dieAudioclips;
    [SerializeField] private SoAudioClips respawnAudioclips;
    [SerializeField] private SoAudioClips jumpPadAudioclips;
    [SerializeField] private SoAudioClips respawnCollectAudioclips;
    [SerializeField] private SoAudioClips winAudioclips;
    [SerializeField] private SoAudioClips fallAudioclips;

    public void PlayJumpSound() 
    { //Lab5
        audioSource.PlayOneShot(jumpAudioclips.GetAudioClip(), 0.5f);    
    }
    //พี่ไม่ได้ให้เสียงตกมาเลยใช้เสียงคล้ายตอนของรีใหม่นะคับ
    public void PlayFallSound() 
    {
        audioSource.PlayOneShot(fallAudioclips.GetAudioClip(), 0.2f);    
    }
    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);    
    }

    public void PlayDieSound()
    {
        audioSource.PlayOneShot(dieAudioclips.GetAudioClip());
    }
    public void PlayRespawn()
    {
        audioSource.PlayOneShot(respawnAudioclips.GetAudioClip());
    }
    public void PlayRespawnCollect()
    {
        audioSource.PlayOneShot(respawnCollectAudioclips.GetAudioClip());
    }
    public void PlayJumpPad()
    {
        audioSource.PlayOneShot(jumpPadAudioclips.GetAudioClip());
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winAudioclips.GetAudioClip());
    }
}
