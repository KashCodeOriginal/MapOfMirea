using System;
using UnityEngine;

public class ZoomButtons : MonoBehaviour
{
    private bool _isPlusDown = false;
    private bool _isMinusDown = false;

    [SerializeField] private Camera _cam;

    [SerializeField] private float _time;

    [SerializeField] private float _zoomStep;
    
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
        if (_isPlusDown && _cam.orthographicSize >= 10.5f)
        {
            _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _cam.orthographicSize - _zoomStep, _time);
            _isPlusDown = false;
        }
        if (_isMinusDown && _cam.orthographicSize <= 60)
        {
            _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _cam.orthographicSize + _zoomStep, _time);
            _isMinusDown = false;
        }
    }
}
