using UnityEngine;
using UnityEngine.UI;

public class ButtunColorer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _swichOnColor;
    [SerializeField] private Color _swichOffColor;

    private bool _isSelected = true;

    public void ChangeColor()
    {
        if (_isSelected)
        {
            SetTypeColorOn();
        }
        else
        {
            SetTypeColorOff();
        }
    }

    public void SetTypeColorOff() 
    {
        _isSelected = true;
        _image.color = _swichOffColor;
    }

    private void SetTypeColorOn()
    {
        _isSelected = false;
        _image.color = _swichOnColor;
    }
}