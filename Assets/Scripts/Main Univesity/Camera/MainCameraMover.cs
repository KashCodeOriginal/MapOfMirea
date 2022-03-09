using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MainCameraMover : MonoBehaviour
{

  TextMeshProUGUI getItemText;

  GameObject _canvas;

  GameObject _firstFloor;
  GameObject _secondFloor;
  GameObject _thirdFloor;
  GameObject _fourthFloor;

  private string _tempRoomName;

  private string _tempRoomName2;

  private string _tempRoomName3;

  private float _posx;
  private float _posy;
  private float _posz;

  private Button _firstFloorButton;
  private Button _secondFloorButton;
  private Button _thirdFloorButton;
  private Button _fourthFloorButton;

  private SpriteRenderer _marker;

  private string[] _firstFloorObjects = new string[]{"Кабинет №Гардероб Библиотека", "Кабинет №Мед.Пункт А107", "Кабинет №", "Кабинет №СпортКомплекс", "Кабинет №Столовая 1 Этаж", "Кабинет №Туалет Ж Библиотека", "Кабинет №Туалет М Библиотека", "Кабинет №Туалет М Г207", "Кабинет №Туалет М/Ж А107.1", "Кабинет №Туалет А137", "Кабинет №М/Ж А178", "Кабинет №Туалет Б205", "Кабинет №Туалет В216", "Кабинет №Туалет Д206"};
  private string[] _secondFloorObjects = new string[] {"Кабинет №А8", "Кабинет №А7", "Кабинет №А6", "Кабинет №А5","Кабинет №А4", "Кабинет №А3", "Кабинет №А2", "Кабинет №А1", "Кабинет №Буфет А213", "Кабинет №Буфет А214", "Кабинет №Буфет Б313", "Кабинет №Буфет В306", "Кабинет №Буфет Вход", "Кабинет №Буфет Г309" ,"Кабинет №Бюро Пропусков", "Кабинет №Вход/Выход", "Кабинет №Гардероб Главный", "Кабинет №Охрана", "Кабинет №Туалет Ж А208", "Кабинет №Туалет Ж А213", "Кабинет №Туалет М А1", "Кабинет №Туалет М А214", "№Туалет М/Ж А218", "Кабинет №Туалет М/Ж Б327", "Кабинет №Туалет М/Ж В301", "Кабинет №Туалет М/Ж Г327", "Кабинет №Туалет М/Ж Д315"};
  private string[] _thirdFloorObjects = new string[] { "Кабинет №А18", "Кабинет №А17", "Кабинет №А16", "Кабинет №А15", "Кабинет №А14", "Кабинет №А13", "Кабинет №А12", "Кабинет №А11", "Кабинет №А10", "Кабинет №А9", "Кабинет №Приемная Д401(б)", "Кабинет №Приемная Д403(б)", "Кабинет №Приемная Д404(Б)", "Кабинет №Приемная Д408", "Кабинет №Приемная Д415", "Кабинет №Приемная Д417", "Кабинет №Туалет Ж А311", "Кабинет №Туалет Ж А325", "Кабинет №Туалет М Г427", "Кабинет №Туалет М/Ж Б408", "Кабинет №Туалет М/Ж Д403(Б)", "Кабинет №Туалет М/Ж И216", "Кабинет №Учительская"};
  private string[] _fourthFloorObjects = new string[] { "Кабинет №Туалет Ж А412", "Кабинет №Туалет М А412", "Кабинет №Туалет М А425" };

  private bool _isObjectOnFirstFloor = false;
  private bool _isObjectOnSecondFloor = false;
  private bool _isObjectOnThirdFloor = false;
  private bool _isObjectOnFourthFloor = false;

  public void Start()
  {
    Button button = gameObject.GetComponent<Button>();

    button.onClick.AddListener(MenuDown);
    button.onClick.AddListener(CamMover);

    _firstFloor = GameObject.FindWithTag("FirstFloor");
    _secondFloor = GameObject.FindWithTag("SecondFloor");
    _thirdFloor = GameObject.FindWithTag("ThirdFloor");
    _fourthFloor = GameObject.FindWithTag("FourthFloor");

    _firstFloorButton = GameObject.FindWithTag("FirstFloorButton").GetComponent<Button>();
    _secondFloorButton = GameObject.FindWithTag("SecondFloorButton").GetComponent<Button>();
    _thirdFloorButton = GameObject.FindWithTag("ThirdFloorButton").GetComponent<Button>();
    _fourthFloorButton = GameObject.FindWithTag("FourthFloorButton").GetComponent<Button>();

    _marker = GameObject.FindWithTag("Marker").GetComponent<SpriteRenderer>();
  }
  public void MenuDown()
  {
    GameObject.Find("UniversalMenu").GetComponent<Animation>().Play("MenuDown");
    GameObject.FindWithTag("MainCamera").GetComponent<Animation>().Play("MenuDownForSearch");

    GameObject.FindWithTag("MainCamera").GetComponent<MainCamControll>().enabled = true;
  }
  public void CamMover()
  {
    Button button = gameObject.GetComponent<Button>();
    getItemText = button.GetComponentInChildren<TextMeshProUGUI>();

    _tempRoomName2 = $"Кабинет №{getItemText.text}";

    GameObject.Find(_tempRoomName2);

    Debug.Log(GameObject.Find(_tempRoomName2));

    foreach(var objects in _firstFloorObjects)
    {
      if (objects == _tempRoomName2)
      {
        _isObjectOnFirstFloor = true;
      }
    }
    foreach (var objects in _secondFloorObjects)
    {
      if (objects == _tempRoomName2)
      {
        _isObjectOnSecondFloor = true;
      }
    }
    foreach (var objects in _thirdFloorObjects)
    {
      if (objects == _tempRoomName2)
      {
        _isObjectOnThirdFloor = true;
      }
    }
    foreach (var objects in _fourthFloorObjects)
    {
      if (objects == _tempRoomName2)
      {
        _isObjectOnFourthFloor = true;
      }
    }

    if ((_tempRoomName2.StartsWith("Кабинет №А1") && _tempRoomName2 != "Кабинет №А1" && _tempRoomName2 != "Кабинет №А10" && _tempRoomName2 != "Кабинет №А11" && _tempRoomName2 != "Кабинет №А12" && _tempRoomName2 != "Кабинет №А13" && _tempRoomName2 != "Кабинет №А14" && _tempRoomName2 != "Кабинет №А15" && _tempRoomName2 != "Кабинет №А16" && _tempRoomName2 != "Кабинет №А17" && _tempRoomName2 != "Кабинет №А18") || _isObjectOnFirstFloor == true || _tempRoomName2.StartsWith("Кабинет №Г2") || _tempRoomName2.StartsWith("Кабинет №В2") || _tempRoomName2.StartsWith("Кабинет №Б2") || _tempRoomName2.StartsWith("Кабинет №Д2"))
    {
      _firstFloorButton.onClick.Invoke();
      for (int i = 0; i < _firstFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_firstFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
        {
          _posx = _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _firstFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
        }
      }
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А2") && _tempRoomName2 != "Кабинет №А2") || _isObjectOnSecondFloor == true || _tempRoomName2.StartsWith("Кабинет №Г3") || _tempRoomName2.StartsWith("Кабинет №В3") || _tempRoomName2.StartsWith("Кабинет №Б3") || _tempRoomName2.StartsWith("Кабинет №Д3") || _tempRoomName2.StartsWith("Кабинет №И2"))
    {
      _secondFloorButton.onClick.Invoke();
      for (int i = 0; i < _secondFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_secondFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
        {
          _posx = _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _secondFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
        }
      }
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А3") && _tempRoomName2 != "Кабинет №А3") || _isObjectOnThirdFloor == true || _tempRoomName2.StartsWith("Кабинет №Г4") || _tempRoomName2.StartsWith("Кабинет №В4") || _tempRoomName2.StartsWith("Кабинет №Б4") || _tempRoomName2.StartsWith("Кабинет №Д4") || _tempRoomName2.StartsWith("Кабинет №И3"))
    {
      _thirdFloorButton.onClick.Invoke();
      for (int i = 0; i < _thirdFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_thirdFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
        {
          _posx = _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _thirdFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
        }
      }
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А4") && _tempRoomName2 != "Кабинет №А4") || _isObjectOnFourthFloor == true)
    {
      _fourthFloorButton.onClick.Invoke();
      for (int i = 0; i < _fourthFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_fourthFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
        {
          _posx = _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _fourthFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
        }
      }
    }

    GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Stop("MarkerUpDown");
    MarkerToPosMover(_posx, _posy, _posz);
    GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Play("MarkerUpDown");
    CamToPosMover(_posx, _posy, getItemText.text);
    var obj = GameObject.FindWithTag("FindSomething");
    obj.SetActive(false);

    _isObjectOnFirstFloor = false;
    _isObjectOnSecondFloor = false;
    _isObjectOnThirdFloor = false;
    _isObjectOnFourthFloor = false;
  }
  public void CamToPosMover(float posx, float posy, string _getItemText)
  {
    GameObject.Find("Main Camera").GetComponent<MainCamControll>().targetPosx = posx;
    GameObject.Find("Main Camera").GetComponent<MainCamControll>().targetPosy = posy;
  }
  public void MarkerToPosMover(float x, float y, float z)
  {
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(x, y + 0.3f, z);
  }
  public void MarkerStartPosMover()
  {
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(-10, -40, 0);
    GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Stop();
  }
}