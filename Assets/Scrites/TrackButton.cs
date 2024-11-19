using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TrackButton : MonoBehaviour
{
    [SerializeField] private MasterButton _mainButton;
    [SerializeField] private ButtonColorer _buttunColorer;
    [SerializeField] private Button _button;
    [SerializeField] private Toggle _toggle;

    private AudioSource _audioSource;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        SetBunToPlaying();

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToPlay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToPlay);
    }

    public void SetBunToPlaying()
    {
        IsPlaying = false;
    }

    public void TurnOffMusic()
    {
        _audioSource.Stop();
    }

    private void ToPlay()
    {
        if (_toggle.isOn)
        {
            if (!IsPlaying)
            {
                TurnOnMusic();

                _buttunColorer.SetTypeColorOn();
            }
        }
    }

    private void TurnOnMusic()
    {
        _audioSource.Play();
    }
}