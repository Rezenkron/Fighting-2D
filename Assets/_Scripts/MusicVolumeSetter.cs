using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeSetter : MonoBehaviour
{
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = MusicVolumeManager.volumeValue;
        }
    }

    public void ChangeVolume()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = MusicVolumeManager.volumeValue;
        }
    }
}
