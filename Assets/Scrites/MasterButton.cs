using TMPro;
using UnityEngine;

public class MasterButton : MonoBehaviour
{
    [SerializeField] private GameObject _audioTracksSet;
    [SerializeField] private GameObject _text;
    [SerializeField] private AudioSource _backGroundSource;
    [SerializeField] private ButtunColorer _buttunColorer;

    private const string TurnOnMessage = "Звук Включен";
    private const string TurnOffMessage = "Звук Выключен";
  
    private TrackButton[] _trackButtons;
    private TextMeshProUGUI _buttonText;
    
    public bool IsAllowed {  get; private set; }

    private void Awake()
    {
        IsAllowed = true;

        _trackButtons = _audioTracksSet.GetComponentsInChildren<TrackButton>();

        _buttonText = _text.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SwichOffSound();       
    }

    public void ToggleSound()
    {
        if (IsAllowed)
        {
            TurnOnBackMusic();

            _buttonText.text = TurnOnMessage;

            _buttunColorer.ChangeColor();

            IsAllowed = false;
        }
        else if (!IsAllowed)
        {
            SwichOffSound();

            _buttunColorer.ChangeColor();

            _buttonText.text = TurnOffMessage;

            IsAllowed = true;
        }
    }

    private void SwichOffSound()
    {
        foreach (var track in _trackButtons)
        {
            AudioSource audioSource = track.GetComponent<AudioSource>();

            audioSource.enabled = false;

            track.GetComponent<ButtunColorer>().SetTypeColorOff();

            track.SetBunToPlaying();
        }

        TurnOffBackMusic();
    }

    private void TurnOnBackMusic()
    {
        _backGroundSource.enabled = true;
    }

    private void TurnOffBackMusic()
    {
        _backGroundSource.enabled = false;
    }
}