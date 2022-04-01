using UnityEngine;
using UnityEngine.UI;

public class ZoomButtons : MonoBehaviour
{
    private bool _isPlusDown = false;
    private bool _isMinusDown = false;

    [SerializeField] private Button _plusButton;
    [SerializeField] private Button _minusButton;

    [SerializeField] private Camera _cam;
    [SerializeField] private float _zoomStep;

    [SerializeField] private Image _referenceForButtons;
    
    private float ZoomMin = 5.5f;
    private float ZoomMax = 65f;
    
    public void OnZoomButtonPlusDown()
    {
        _isPlusDown = true;
    }

    public void OnZoomButtonMinusDown()
    {
        _isMinusDown = true;
    }
    private void FixedUpdate()
    {
        if (_isPlusDown)
        {
            if (_cam.orthographicSize <= ZoomMin + _zoomStep)
            {
                float _maxZoom = _cam.orthographicSize - ZoomMin;

                _cam.orthographicSize -= _maxZoom;

                _plusButton.GetComponent<Image>().color = new Color(_referenceForButtons.color.r - 0.15f, _referenceForButtons.color.g - 0.15f, _referenceForButtons.color.b - 0.15f);
                _plusButton.enabled = false;
            }
            else if (_cam.orthographicSize != ZoomMin)
            {
                _cam.orthographicSize -= _zoomStep;
                if (_minusButton.enabled == false)
                {
                    _minusButton.GetComponent<Image>().color = new Color(_referenceForButtons.color.r, _referenceForButtons.color.g, _referenceForButtons.color.b);
                    _minusButton.enabled = true;
                }
            }
            _isPlusDown = false;
        }
        if (_isMinusDown)
        {
            if (_cam.orthographicSize >= ZoomMax - _zoomStep)
            {
                float _maxZoom = ZoomMax - _cam.orthographicSize;

                _cam.orthographicSize += _maxZoom;
                
                _minusButton.GetComponent<Image>().color = new Color(_referenceForButtons.color.r - 0.15f, _referenceForButtons.color.g - 0.15f, _referenceForButtons.color.b - 0.15f);
                _minusButton.enabled = false;
            }
            else if (_cam.orthographicSize != ZoomMax)
            {
                _cam.orthographicSize += _zoomStep;

                if (_plusButton.enabled == false)
                {
                    _plusButton.GetComponent<Image>().color = new Color(_referenceForButtons.color.r, _referenceForButtons.color.g, _referenceForButtons.color.b);
                    _plusButton.enabled = true;
                }
            }
            _isMinusDown = false;
        }
    }
}
