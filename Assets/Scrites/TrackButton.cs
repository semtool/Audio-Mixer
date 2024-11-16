using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class TrackButton : MonoBehaviour
{
    [SerializeField] private MasterButton _mainButton;
    [SerializeField] private ButtunColorer _buttunColorer;

    private AudioSource _audioSource;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        SetBunToPlaying();

        _audioSource = GetComponent<AudioSource>();
    }

    public void ToPlay()
    {
        if (!_mainButton.IsAllowed)
        {
            if (!IsPlaying)
            {
                TurnOnMusic();

                _buttunColorer.ChangeColor();

                IsPlaying = true;
            }
            else if (IsPlaying)
            {
                TurnOffMusic();

                _buttunColorer.ChangeColor();

                IsPlaying = false;
            }
        }
    }

    public void SetBunToPlaying()
    {
        IsPlaying = false;
    }

    private void TurnOnMusic()
    {
        _audioSource.enabled = true;
    }

    private void TurnOffMusic()
    {
        _audioSource.enabled = false;
    }
}