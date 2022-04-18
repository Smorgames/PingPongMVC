using TMPro;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private TextMeshProUGUI _tmp;
    [SerializeField] private int _rainbowPicker;
    [SerializeField] private float _changeTime = 2f;

    private Color _newColor;
    private float _counter;

    private void Start() => 
        _newColor = _colors[_rainbowPicker];

    private void Update()
    {
        _counter += Time.deltaTime;
        var delta = _counter / _changeTime;
        var nextColor = _rainbowPicker == _colors.Length - 1 ? 0 : _rainbowPicker + 1;
        _newColor = Color.Lerp(_colors[_rainbowPicker], _colors[nextColor], delta);
        _tmp.color = _newColor;

        if (_counter >= _changeTime)
        {
            _counter = 0f;
            _rainbowPicker++;
            if (_rainbowPicker == _colors.Length)
                _rainbowPicker = 0;
        }
    }
}