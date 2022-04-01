using System;
using TMPro;
using UnityEngine;

public class ZoomButtons : MonoBehaviour
{
    private bool _isPlusDown = false;
    private bool _isMinusDown = false;

    [SerializeField] private Camera _cam;
    [SerializeField] private float _zoomStep;
    
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
            }
            else if (_cam.orthographicSize != ZoomMin)
            {
                _cam.orthographicSize -= _zoomStep;
            }

            _isPlusDown = false;
        }
        if (_isMinusDown)
        {
            if (_cam.orthographicSize >= ZoomMax - _zoomStep)
            {
                float _maxZoom = ZoomMax - _cam.orthographicSize;

                _cam.orthographicSize += _maxZoom;
            }
            else if (_cam.orthographicSize != ZoomMax)
            {
                _cam.orthographicSize += _zoomStep;
            }
            _isMinusDown = false;
        }
    }
}
