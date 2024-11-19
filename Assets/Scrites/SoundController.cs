using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
  
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);       
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_mixer.name, Mathf.Log(volume) * 20);
    }
}