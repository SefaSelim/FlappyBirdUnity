using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValues : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;


    private void Start()
    {
        soundSlider.value = StaticSettings.SoundValue;
        musicSlider.value = StaticSettings.MusicSound;
    }





    public void OnMusicValueChanged()
    {
        StaticSettings.MusicSound = musicSlider.value;
    }

    public void OnSoundValueChanged()
    {
        StaticSettings.SoundValue = soundSlider.value;
    }
}
