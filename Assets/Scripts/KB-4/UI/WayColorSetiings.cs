using UnityEngine;
using UnityEngine.UI;

public class WayColorSetiings : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _backgroundWaySettings;
  [SerializeField] private SpriteRenderer _modelWaySettings;

  [SerializeField] private SpriteRenderer _map;
  [SerializeField] private Camera _cam;

  [SerializeField] private SpriteRenderer _secondFloor;

  [SerializeField] private SpriteRenderer _pathColorSettings;

  [SerializeField] private SpriteRenderer _firstPointColor;
  [SerializeField] private SpriteRenderer _SecondPointColor;

  [SerializeField] private SpriteRenderer _firstWayPointColor;
  [SerializeField] private SpriteRenderer _secondWayPointColor;

  [SerializeField] private Material _wayMaterial;
  public void Start()
  {
    _modelWaySettings.color = _secondFloor.color;
    _backgroundWaySettings.color = _cam.backgroundColor;
    _pathColorSettings.color = _wayMaterial.color;
    _firstPointColor.color = _wayMaterial.color;
    _SecondPointColor.color = _wayMaterial.color;
  }

  public void OnWaySettingsClick()
  {
    _pathColorSettings.color = gameObject.GetComponent<Image>().color;
    _wayMaterial.color = gameObject.GetComponent<Image>().color;

    _firstPointColor.color = gameObject.GetComponent<Image>().color;
    _SecondPointColor.color = gameObject.GetComponent<Image>().color;

    _firstWayPointColor.color = gameObject.GetComponent<Image>().color;
    _secondWayPointColor.color = gameObject.GetComponent<Image>().color;
  }
  public void OnWayLoad(float r, float g, float b)
  {
    _pathColorSettings.color = new Color(r, g, b);
    _wayMaterial.color = new Color(r, g, b);

    _firstPointColor.color = new Color(r, g, b);
    _SecondPointColor.color = new Color(r, g, b);

    _firstWayPointColor.color = new Color(r, g, b);
    _secondWayPointColor.color = new Color(r, g, b);
  }
}