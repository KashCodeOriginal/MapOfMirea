using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ThemesChanger : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _walls;
  [SerializeField] private Camera _cambg;


  private List<GameObject> _textList = new List<GameObject>();

  [SerializeField] private GameObject _text;

  //Models
  [SerializeField] private SpriteRenderer _modelForSettings;
  [SerializeField] private SpriteRenderer _backGround;
  [SerializeField] private GameObject _modelText;

  [SerializeField] private SpriteRenderer _modelWaySettings;
  [SerializeField] private SpriteRenderer _backgroundWaySettings;
  [SerializeField] private GameObject _modelWayText;

  private List<GameObject> _modeltextList = new List<GameObject>();
  private List<GameObject> _modeltextWaytList = new List<GameObject>();


  public void Start()
  {
    for (int i = 0; i < _text.transform.childCount; i++)
    {
      _textList.Add(_text.transform.GetChild(i).gameObject);
    }
    for (int i = 0; i < _modelText.transform.childCount; i++)
    {
      _modeltextList.Add(_modelText.transform.GetChild(i).gameObject);
    }
    for (int i = 0; i < _modelWayText.transform.childCount; i++)
    {
      _modeltextWaytList.Add(_modelWayText.transform.GetChild(i).gameObject);
    }
  }

  public void OnThemeChanger()
  {
    _walls.color = gameObject.GetComponentInChildren<SpriteRenderer>().color;
    _modelForSettings.color = gameObject.GetComponentInChildren<SpriteRenderer>().color;
    _modelWaySettings.color = gameObject.GetComponentInChildren<SpriteRenderer>().color;

    _cambg.backgroundColor = gameObject.GetComponent<Image>().color;
    _backGround.color = gameObject.GetComponent<Image>().color;
    _backgroundWaySettings.color = gameObject.GetComponent<Image>().color;

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
}
