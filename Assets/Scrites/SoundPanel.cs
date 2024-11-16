using UnityEngine;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string MainVolume = "Master";
    private const string BackGroundVolume = "BackGround";
    private const string TrackVolume = "Track";

    public void ChangeMasterMusic(float volume)
    {
        ChangeVolume(MainVolume, volume);
    }
    
    public void ChangeBackMusic(float volume)
    {
        ChangeVolume(BackGroundVolume, volume);
    }
    
    public void ChangeTrackSound(float volume)
    {
        ChangeVolume(TrackVolume, volume);
    } 

    private void ChangeVolume(string soundParam,float volume)
    {
        _mixer.audioMixer.SetFloat(soundParam, Mathf.Log(volume) * 20);
    }
}