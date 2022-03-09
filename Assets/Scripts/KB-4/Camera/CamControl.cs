using UnityEngine;
using System.Collections.Generic;

public class CamControl : MonoBehaviour
{
  private Vector2 _startPos;

  private Camera cam;

  [SerializeField] private float SpeedOfZoom;

  [SerializeField] private float _stepsOfDoubleTapsZoom;

  [HideInInspector] public float targetPosx;
  [HideInInspector] public float targetPosy;
  [SerializeField] private float speed;

  [SerializeField] private float ZoomMin = 5.5f;
  [SerializeField] private float ZoomMax = 17;

  [SerializeField] private float XMin = -30;
  [SerializeField] private float XMax = 30;
  [SerializeField] private float YMin = -30;
  [SerializeField] private float YMax = 30;

  [SerializeField] private float _minTrailWight = 0.15f;
  [SerializeField] private float _maxTrailWight = 0.3f;
  [SerializeField] float speedOfTrail;

  [SerializeField] private float _rotationSpeed;

  [SerializeField] private GameObject _list;
  [SerializeField] private List<GameObject> _textList;

  [SerializeField] private GameObject _marker;

  private float _lastClickTime;

  private const float TIME_BETWEEN_CLICKS = 0.2f;

  private float _rotationAngle;
  private void Start()
  {
    cam = GetComponent<Camera>();
    targetPosx = transform.position.x;
    targetPosy = transform.position.y;

    Application.targetFrameRate = 60;

    _textList = _list.GetComponent<MapColorChanging>()._textList;
  }
  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _startPos = cam.ScreenToWorldPoint(Input.mousePosition);

      float _timeSinceFirstClick = Time.time - _lastClickTime;

      if(_timeSinceFirstClick <= TIME_BETWEEN_CLICKS) 
      {
        if(cam.orthographicSize <= ZoomMin + _stepsOfDoubleTapsZoom)
        {
          float _maxZoom = cam.orthographicSize - ZoomMin;

          cam.orthographicSize = cam.orthographicSize - _maxZoom;
        }
        else if(cam.orthographicSize != ZoomMin)
        {
          cam.orthographicSize = cam.orthographicSize - _stepsOfDoubleTapsZoom;
        }
      }
      _lastClickTime = Time.time;
    }
    else if (Input.GetMouseButton(0))
    {
      float posx = cam.ScreenToWorldPoint(Input.mousePosition).x - _startPos.x;
      float posy = cam.ScreenToWorldPoint(Input.mousePosition).y - _startPos.y;

      targetPosx = Mathf.Clamp(transform.position.x - posx, XMin, XMax);
      targetPosy = Mathf.Clamp(transform.position.y - posy, YMin, YMax);
    }
    transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosx, speed * Time.deltaTime), transform.position.y, transform.position.z);
    transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPosy, speed * Time.deltaTime), transform.position.z);

    if (Input.touchCount == 2)
    {
      Touch touchFirst = Input.GetTouch(0);
      Touch touchSecond = Input.GetTouch(1);

      Vector2 touchFirstLastPos = touchFirst.position - touchFirst.deltaPosition;
      Vector2 touchSecondLastPos = touchSecond.position - touchSecond.deltaPosition;

      float distanceTouch = (touchFirstLastPos - touchSecondLastPos).magnitude;
      float currentDistance = (touchFirst.position - touchSecond.position).magnitude;

      float difference = distanceTouch - currentDistance;

      Zoom(difference * SpeedOfZoom, difference * speedOfTrail);

      if(touchSecondLastPos != touchSecond.position)
      {
        var _angle = Vector3.SignedAngle(touchSecond.position - touchFirst.position, touchSecondLastPos - touchFirstLastPos, -cam.transform.forward);
        cam.transform.RotateAround(cam.transform.position, -cam.transform.forward, _angle);
      }
      foreach(var child in _textList)
      {
        child.transform.rotation = new Quaternion(0, 0, cam.transform.rotation.z, cam.transform.rotation.w);
      }
      _marker.transform.rotation = new Quaternion(0, 0, cam.transform.rotation.z, cam.transform.rotation.w);
    }
    if (Input.touchCount == 0)
    {
      _rotationAngle = cam.transform.localRotation.eulerAngles.z;

      _rotationAngle = (_rotationAngle < 180f) ? _rotationAngle : _rotationAngle - 360;

      if (_rotationAngle >= -30 && _rotationAngle <= 30)
      {
        OnHorizontalRotation();
        cam.transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(_rotationAngle, 0, _rotationSpeed));
      }
      else if (_rotationAngle >= 60 && _rotationAngle <= 120)
      {
        OnVerticanRotation();
        cam.transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(_rotationAngle, 90, _rotationSpeed));
      }
      else if ((_rotationAngle >= 150 && _rotationAngle >= -150) || (_rotationAngle <= 150 && _rotationAngle <= -150))
      {
        OnHorizontalRotation();
        cam.transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(_rotationAngle, 180, _rotationSpeed));
      }
      else if (_rotationAngle >= -120 && _rotationAngle <= -60)
      {
        OnVerticanRotation();
        cam.transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(_rotationAngle, 270, _rotationSpeed));
      }
      foreach (var child in _textList)
      {
        child.transform.rotation = new Quaternion(0, 0, cam.transform.rotation.z, cam.transform.rotation.w);
      }
     _marker.transform.rotation = new Quaternion(0, 0, cam.transform.rotation.z, cam.transform.rotation.w);
    }
  }
  private void Zoom(float increment, float trailIncrement)
  {
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + increment, ZoomMin, ZoomMax);
    if (GameObject.FindWithTag("Trail").TryGetComponent(out TrailRenderer renderer))
    {
      renderer.startWidth = Mathf.Clamp(renderer.startWidth + (trailIncrement / 15000), _minTrailWight, _maxTrailWight);
      renderer.endWidth = Mathf.Clamp(renderer.endWidth + (trailIncrement / 15000), _minTrailWight, _maxTrailWight);
    }
  }

  private void OnVerticanRotation()
  {
    XMin = -11.5f;
    XMax = -1.5f;
    YMin = -4;
    YMax = 5;
  }
  private void OnHorizontalRotation()
  {
    XMin = -13.25f;
    XMax = 0;
    YMin = -1f;
    YMax = 0.7f;
  }
}
