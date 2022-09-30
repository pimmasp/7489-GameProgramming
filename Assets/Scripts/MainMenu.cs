using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGame2()
    {
        SceneManager.LoadScene(2);
    }
    public void QiutGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    // public void SetVolume() // 1.13 Brackey https://www.youtube.com/watch?v=YOaYQrN1oYQ&list=RDCMUCYbK_tjZ2OrIZFBvU6CCMiA&index=2
    // {
    //     audioMixer.SetFloat("volume", volume);
    // }
}
