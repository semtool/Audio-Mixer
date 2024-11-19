using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MasterButton : MonoBehaviour
{
    [SerializeField] private GameObject _audioTracksSet;
    [SerializeField] private GameObject _text;
    [SerializeField] private AudioSource _backGroundSource;
    [SerializeField] private ButtonColorer _buttonColorer;

    private Toggle _toggle;
    private Text _toggleText;
    private const string TurnOnMessage = "Звук Включен";
    private const string TurnOffMessage = "Звук Выключен";
    private TrackButton[] _trackButtons;
    
    private void Awake()
    {
        _toggle = GetComponent<Toggle>();

        _trackButtons = _audioTracksSet.GetComponentsInChildren<TrackButton>();

        _toggleText = _text.GetComponent<Text>();
    }

    private void Start()
    {
        SwichOffSound();

        _toggle.isOn = false;
    }

    public void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleSound);
    }

    public void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleSound);
    }

    private void ToggleSound(bool marker)
    {
        if (marker)
        {
            TurnOnBackMusic();

            _buttonColorer.ChangeColor();

            _toggleText.text = TurnOnMessage;
        }
        else 
        {
            SwichOffSound();

            _buttonColorer.ChangeColor();

            _toggleText.text = TurnOffMessage;
        }
    }

    private void SwichOffSound()
    {
        foreach (var track in _trackButtons)
        {
            track.TurnOffMusic();

            track.GetComponent<ButtonColorer>().SetTypeColorOff();

            track.SetBunToPlaying();
        }

        TurnOffBackMusic();       
    }

    private void TurnOnBackMusic()
    {
        _backGroundSource.Play();
    }

    private void TurnOffBackMusic()
    {
        _backGroundSource.Stop();
    }
}