using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    public void ChangeVolume()
    {
        audioSource.volume = slider.value;
    }
}