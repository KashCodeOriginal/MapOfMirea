using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class MapColorChanging : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _map;

  [SerializeField] private SpriteRenderer _firstFloor;
  [SerializeField] private SpriteRenderer _secondFloor;
  [SerializeField] private SpriteRenderer _thirdFloor;
  [SerializeField] private SpriteRenderer _fourthFloor;

  [SerializeField] private SpriteRenderer _secondFloorBG;
  [SerializeField] private SpriteRenderer _thirdFloorBG;
  [SerializeField] private SpriteRenderer _fourthFloorBG;

  [SerializeField] private Camera _cam;

  [SerializeField] private SpriteRenderer _backGround;
  [SerializeField] private SpriteRenderer _modelForSettings;
  [SerializeField] private GameObject _modelText;

  [SerializeField] private SpriteRenderer _backgroundWaySettings;
  [SerializeField] private SpriteRenderer _modelWaySettings;
  [SerializeField] private GameObject _modelWayText;

  public List<GameObject> _textList = new List<GameObject>();
  [SerializeField] private List<GameObject> _modeltextList = new List<GameObject>();
  [SerializeField] private List<GameObject> _modeltextWaytList = new List<GameObject>();

  public void Awake()
  {
    _modelForSettings.color = _secondFloor.GetComponent<SpriteRenderer>().color;
    _backGround.color = _cam.GetComponent<Camera>().backgroundColor;
  }
  public void OnWallsClick()
  {
    _map.color = gameObject.GetComponent<Image>().color;
    _modelForSettings.color = gameObject.GetComponent<Image>().color;
    _modelWaySettings.color = gameObject.GetComponent<Image>().color;

    _firstFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _firstFloor.color.a);
    _secondFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _secondFloor.color.a);
    _thirdFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _thirdFloor.color.a);
    _fourthFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _fourthFloor.color.a);
  }
  public void OnWallsLoad(float r, float g, float b)
  {
    _map.color = new Color(r, g, b);
    _modelForSettings.color = new Color(r, g, b);
    _modelWaySettings.color = new Color(r, g, b);
  }
  public void OnBackGroundClick()
  {
    _cam.backgroundColor = gameObject.GetComponent<Image>().color;
    _backGround.color = gameObject.GetComponent<Image>().color;
    _backgroundWaySettings.color = gameObject.GetComponent<Image>().color;

    _secondFloorBG.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _secondFloor.color.a);
    _thirdFloorBG.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _thirdFloor.color.a);
    _fourthFloorBG.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _fourthFloor.color.a);
  }

  public void OnBackGroundLoad(float r, float g, float b)
  {
    _cam.backgroundColor = new Color(r, g, b);
    _backGround.color = new Color(r, g, b);
    _backgroundWaySettings.color = new Color(r, g, b);
  }

  public void OnTextClick()
  {
    foreach (var text in _textList)
    {
      text.GetComponent<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
    }
    foreach (var modelText in _modeltextList)
    {
      modelText.GetComponent<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
    }
    foreach (var modelWayText in _modeltextWaytList)
    {
      modelWayText.GetComponent<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
    }
  }
  public void OnTextLoad(float r, float g, float b)
  {
    foreach (var text in _textList)
    {
      text.GetComponent<TextMeshProUGUI>().color = new Color(r, g, b);
    }
    foreach (var modelText in _modeltextList)
    {
      modelText.GetComponent<TextMeshProUGUI>().color = new Color(r, g, b);
    }
    foreach (var modelWayText in _modeltextWaytList)
    {
      modelWayText.GetComponent<TextMeshProUGUI>().color = new Color(r, g, b);
    }
  }
}
