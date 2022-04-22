using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCameraMover : MonoBehaviour
{

  private TextMeshProUGUI getItemText;

  private GameObject _canvas;

  private GameObject _zeroFloor;
  private GameObject _firstFloor;
  private GameObject _secondFloor;
  private GameObject _thirdFloor;
  private GameObject _fourthFloor;
  
  private string _tempRoomName;
  private string _tempRoomNameSecond;
  
  private float _posx;
  private float _posy;
  private float _posz;

  private Button _zeroFloorButton;
  private Button _firstFloorButton;
  private Button _secondFloorButton;
  private Button _thirdFloorButton;
  private Button _fourthFloorButton;

  private SpriteRenderer _marker;

  private string[] _firstFloorObjects = new string[]{"Гардероб Библиотека", "Мед.Пункт А107", "СпортКомплекс", "Столовая 1 Этаж", "Туалет Ж Библиотека", "Туалет М Библиотека", "Туалет М Г207", "Туалет М/Ж А107.1", "Туалет М/Ж А137", "Туалет М/Ж А178", "Туалет Б205", "Туалет В216", "Туалет Д206"};
  private string[] _secondFloorObjects = new string[] {"Кабинет №А8", "Кабинет №А7", "Кабинет №А6", "Кабинет №А5","Кабинет №А4", "Кабинет №А3", "Кабинет №А2", "Кабинет №А1", "Буфет А213", "Буфет А214", "Буфет Б313", "Буфет В306", "Буфет Вход", "Буфет Г309" ,"Бюро Пропусков", "Вход/Выход", "Гардероб Главный", "Охрана", "Туалет Ж А208", "Туалет Ж А213", "Туалет М А1", "Туалет М А214", "№Туалет М/Ж А218", "Туалет М/Ж Б327", "Туалет М/Ж В301", "Туалет М/Ж Г327", "Туалет М/Ж Д315"};
  private string[] _thirdFloorObjects = new string[] { "Кабинет №А18", "Кабинет №А17", "Кабинет №А16", "Кабинет №А15", "Кабинет №А14", "Кабинет №А13", "Кабинет №А12", "Кабинет №А11", "Кабинет №А10", "Кабинет №А9", "Приемная Д401(б)", "Приемная Д403(б)", "Приемная Д404(Б)", "Приемная Д408", "Приемная Д415", "Приемная Д417", "Туалет Ж А311", "Туалет Ж А325", "Туалет М Г427", "Туалет М/Ж Б408", "Туалет М/Ж Д403(Б)", "Туалет М/Ж И216", "Учительская"};
  private string[] _fourthFloorObjects = new string[] { "Туалет Ж А412", "№Туалет М А412", "Туалет М А425" };

  private bool _isObjectOnFirstFloor = false;
  private bool _isObjectOnSecondFloor = false;
  private bool _isObjectOnThirdFloor = false;
  private bool _isObjectOnFourthFloor = false;

  public void Start()
  {
    Button button = gameObject.GetComponent<Button>();

    button.onClick.AddListener(MenuDown);
    button.onClick.AddListener(CamMover);

    _zeroFloor = GameObject.FindWithTag("ZeroFloor");
    _firstFloor = GameObject.FindWithTag("FirstFloor");
    _secondFloor = GameObject.FindWithTag("SecondFloor");
    _thirdFloor = GameObject.FindWithTag("ThirdFloor");
    _fourthFloor = GameObject.FindWithTag("FourthFloor");

    _zeroFloorButton = GameObject.FindWithTag("ZeroFloorButton").GetComponent<Button>();
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

    _tempRoomName = $"Кабинет №{getItemText.text}";
    _tempRoomNameSecond = getItemText.text;
    
    foreach(var objects in _firstFloorObjects)
    {
      if (objects == _tempRoomName || objects == _tempRoomNameSecond)
      {
        _isObjectOnFirstFloor = true;
      }
    }
    foreach (var objects in _secondFloorObjects)
    {
      if (objects == _tempRoomName || objects == _tempRoomNameSecond)
      {
        _isObjectOnSecondFloor = true;
      }
    }
    foreach (var objects in _thirdFloorObjects)
    {
      if (objects == _tempRoomName || objects == _tempRoomNameSecond)
      {
        _isObjectOnThirdFloor = true;
      }
    }
    foreach (var objects in _fourthFloorObjects)
    {
      if (objects == _tempRoomName || objects == _tempRoomNameSecond)
      {
        _isObjectOnFourthFloor = true;
      }
    }

    if (_tempRoomName.StartsWith("Кабинет №Г1"))
    {
      _zeroFloorButton.onClick.Invoke();
      for (int i = 0; i < _zeroFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_zeroFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _zeroFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomNameSecond)
        {
          _posx = _zeroFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _zeroFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _zeroFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;

          _zeroFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
      }
    }
    if ((_tempRoomName.StartsWith("Кабинет №А1") && _tempRoomName != "Кабинет №А1" && _tempRoomName != "Кабинет №А10" && _tempRoomName != "Кабинет №А11" && _tempRoomName != "Кабинет №А12" && _tempRoomName != "Кабинет №А13" && _tempRoomName != "Кабинет №А14" && _tempRoomName != "Кабинет №А15" && _tempRoomName != "Кабинет №А16" && _tempRoomName != "Кабинет №А17" && _tempRoomName != "Кабинет №А18") || _isObjectOnFirstFloor == true || _tempRoomName.StartsWith("Кабинет №Г2") || _tempRoomName.StartsWith("Кабинет №В2") || _tempRoomName.StartsWith("Кабинет №Б2") || _tempRoomName.StartsWith("Кабинет №Д2"))
    {
      _firstFloorButton.onClick.Invoke();
      for (int i = 0; i < _firstFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_firstFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _firstFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomNameSecond)
        {
          _posx = _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _firstFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;

          _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
      }
    }
    else if ((_tempRoomName.StartsWith("Кабинет №А2") && _tempRoomName != "Кабинет №А2") || _isObjectOnSecondFloor == true || _tempRoomName.StartsWith("Кабинет №Г3") || _tempRoomName.StartsWith("Кабинет №В3") || _tempRoomName.StartsWith("Кабинет №Б3") || _tempRoomName.StartsWith("Кабинет №Д3") || _tempRoomName.StartsWith("Кабинет №И2"))
    {
      _secondFloorButton.onClick.Invoke();
      for (int i = 0; i < _secondFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_secondFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _secondFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomNameSecond)
        {
          _posx = _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _secondFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
          
          _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
      }
    }
    else if ((_tempRoomName.StartsWith("Кабинет №А3") && _tempRoomName != "Кабинет №А3") || _isObjectOnThirdFloor == true || _tempRoomName.StartsWith("Кабинет №Г4") || _tempRoomName.StartsWith("Кабинет №В4") || _tempRoomName.StartsWith("Кабинет №Б4") || _tempRoomName.StartsWith("Кабинет №Д4") || _tempRoomName.StartsWith("Кабинет №И3"))
    {
      _thirdFloorButton.onClick.Invoke();
      for (int i = 0; i < _thirdFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_thirdFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _thirdFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomNameSecond)
        {
          _posx = _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _thirdFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
          
          _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
        }
      }
    }
    else if ((_tempRoomName.StartsWith("Кабинет №А4") && _tempRoomName != "Кабинет №А4") || _isObjectOnFourthFloor == true)
    {
      _fourthFloorButton.onClick.Invoke();
      for (int i = 0; i < _fourthFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_fourthFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _fourthFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomNameSecond)
        {
          _posx = _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x;
          _posy = _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y;
          _posz = _fourthFloor.transform.GetChild(0).transform.GetChild(i).transform.position.z;
          
          _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
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
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(x, y + 0.3f, z - 0.1f);
  }
  public void MarkerStartPosMover()
  {
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(-10, -40, 0);
    GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Stop();
  }
}