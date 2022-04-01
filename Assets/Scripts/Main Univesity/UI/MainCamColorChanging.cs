using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class MainCamColorChanging : MonoBehaviour
{
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
        _modelForSettings.color = gameObject.GetComponent<Image>().color;
        _modelWaySettings.color = gameObject.GetComponent<Image>().color;

        _firstFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _firstFloor.color.a);
        _secondFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _secondFloor.color.a);
        _thirdFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _thirdFloor.color.a);
        _fourthFloor.color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, _fourthFloor.color.a);
    }

    public void OnWallsLoad(float r, float g, float b)
    {
        _modelForSettings.color = new Color(r, g, b);
        _modelWaySettings.color = new Color(r, g, b);
    }

    public void OnFirstFloorLoad(float r, float g, float b, float a)
    {
        _firstFloor.color = new Color(r, g, b, a);
    }
    public void OnSecondFloorLoad(float r, float g, float b, float a)
    {
        _secondFloor.color = new Color(r, g, b, a);
    }
    public void OnThirdFloorLoad(float r, float g, float b, float a)
    {
        _thirdFloor.color = new Color(r, g, b, a);
    }
    public void OnFourthFloorLoad(float r, float g, float b, float a)
    {
        _fourthFloor.color = new Color(r, g, b, a);
    }
    public void OnSecondFloorBGLoad(float r, float g, float b, float a)
    {
        _secondFloorBG.color = new Color(r, g, b, a);
    }
    public void OnThirdFloorBGLoad(float r, float g, float b, float a)
    {
        _thirdFloorBG.color = new Color(r, g, b, a);
    }
    public void OnFourthFloorBGLoad(float r, float g, float b, float a)
    {
        _fourthFloorBG.color = new Color(r, g, b, a);
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
}
