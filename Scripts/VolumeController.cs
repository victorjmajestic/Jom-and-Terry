using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void Start()
    {
        volumeSlider.value = Data.universalVolume;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Data.universalVolume = AudioListener.volume;
    }
}
