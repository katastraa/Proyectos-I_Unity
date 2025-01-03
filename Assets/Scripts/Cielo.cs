using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Cielo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public void ToggleVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop(); // Detener el video
            videoPlayer.gameObject.SetActive(false); // Desactivar el GameObject
        }
        else
        {
            videoPlayer.gameObject.SetActive(true); // Activar el GameObject
            videoPlayer.Play(); // Reproducir el video
        }
    }
}
