using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    public static float volumeValue = 0.5f;

    public void ChangeVolumeValue()
    {
        volumeValue = volumeSlider.value;
    }
}
