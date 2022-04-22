using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;

public class MainWayBuilder : MonoBehaviour
{
  private TextMeshProUGUI getItemText;

  private GameObject AI;
  private GameObject _start;
  private GameObject _end;
  private GameObject _textFrom;
  private GameObject _textTo;
  private GameObject _cancel;
  private GameObject _wayManager;
  private Button _zeroFloorButton;
  private GameObject _zeroFloor;
  private Button _firstFloorButton;
  private GameObject _firstFloor;
  private Button _secondFloorButton;
  private GameObject _secondFloor;
  private Button _thirdFloorButton;
  private GameObject _thirdFloor;
  private Button _fourthFloorButton;
  private GameObject _fourthFloor;
  private GameObject _wayDetails;
  private Camera _camera;

  public string[] _firstFloorObject =
  {
    "Гардероб Библиотека", "Мед.Пункт А107", "СпортКомплекс",
    "Столовая 1 Этаж", "Туалет Ж Библиотека", "Туалет М Библиотека",
    "Туалет М Г207", "Туалет М/Ж А107.1", "Туалет А137", "М/Ж А178",
    "Туалет Б205", "Туалет В216", "Туалет Д206"
  };

  public string[] _secondFloorObject =
  {
    "Кабинет №А8", "Кабинет №А7", "Кабинет №А6", "Кабинет №А5", "Кабинет №А4", "Кабинет №А3", "Кабинет №А2",
    "Кабинет №А1", "Буфет А213", "Буфет А214", "Буфет Б313", "Буфет В306",
    "Буфет Вход", "Буфет Г309", "Бюро Пропусков", "Вход/Выход",
    "Гардероб Главный", "Охрана", "Туалет Ж А208", "Туалет Ж А213",
    "Туалет М А1", "Туалет М А214", "№Туалет М/Ж А218", "Туалет М/Ж Б327",
    "Туалет М/Ж В301", "Туалет М/Ж Г327", "Туалет М/Ж Д315"
  };

  public string[] _thirdFloorObject =
  {
    "Кабинет №А18", "Кабинет №А17", "Кабинет №А16", "Кабинет №А15", "Кабинет №А14", "Кабинет №А13", "Кабинет №А12",
    "Кабинет №А11", "Кабинет №А10", "Кабинет №А9", "Приемная Д401(б)", "Приемная Д403(б)",
    "Приемная Д404(Б)", "Приемная Д408", "Приемная Д415", "Приемная Д417",
    "Туалет Ж А311", "Туалет Ж А325", "Туалет М Г427", "Туалет М/Ж Б408",
    "Туалет М/Ж Д403(Б)", "Туалет М/Ж И216", "Учительская"
  };

  public string[] _fourthFloorObject = {"Туалет Ж А412", "Туалет М А412", "Туалет М А425"};

  private bool _isObjectOnFirstFloor;
  private bool _isObjectOnSecondFloor;
  private bool _isObjectOnThirdFloor;
  private bool _isObjectOnFourthFloor;

  public void Start()
  {
    Button button = gameObject.GetComponent<Button>();
    button.onClick.AddListener(WayDrawing);

    AI = GameObject.FindWithTag("AI");
    _start = GameObject.FindWithTag("Start");
    _end = GameObject.FindWithTag("End");
    _textFrom = GameObject.FindWithTag("TextFrom");
    _textTo = GameObject.FindWithTag("TextTo");
    _cancel = GameObject.FindWithTag("Cancel");
    _wayManager = GameObject.FindWithTag("WayManager");
    _zeroFloor = GameObject.FindWithTag("ZeroFloor");
    _zeroFloorButton = GameObject.FindWithTag("ZeroFloorButton").GetComponent<Button>();
    _firstFloor = GameObject.FindWithTag("FirstFloor");
    _firstFloorButton = GameObject.FindWithTag("FirstFloorButton").GetComponent<Button>();
    _secondFloor = GameObject.FindWithTag("SecondFloor");
    _secondFloorButton = GameObject.FindWithTag("SecondFloorButton").GetComponent<Button>();
    _thirdFloor = GameObject.FindWithTag("ThirdFloor");
    _thirdFloorButton = GameObject.FindWithTag("ThirdFloorButton").GetComponent<Button>();
    _fourthFloor = GameObject.FindWithTag("FourthFloor");
    _fourthFloorButton = GameObject.FindWithTag("FourthFloorButton").GetComponent<Button>();
    _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    
    _wayDetails = GameObject.FindWithTag("WayDetails");
  }

  public void WayDrawing()
  {
    Button button = gameObject.GetComponent<Button>();
    getItemText = button.GetComponentInChildren<TextMeshProUGUI>();

    string _tempRoomName2 = $"Кабинет №{getItemText.text}";
    string _tempRoomName = getItemText.text;
    
    ButtonFloorCheck(_tempRoomName, _tempRoomName2,_firstFloorObject, ref _isObjectOnFirstFloor);
    ButtonFloorCheck(_tempRoomName, _tempRoomName2,_secondFloorObject,ref _isObjectOnSecondFloor);
    ButtonFloorCheck(_tempRoomName, _tempRoomName2,_thirdFloorObject,ref _isObjectOnThirdFloor);
    ButtonFloorCheck(_tempRoomName, _tempRoomName2,_fourthFloorObject,ref _isObjectOnFourthFloor);

    if (_tempRoomName2.StartsWith("Кабинет №Г1"))
    {
      RoomsButtonFloorCheck(_zeroFloorButton, button, _tempRoomName2,_tempRoomName, _zeroFloor, 19.1f);
    }
    if ((_tempRoomName2.StartsWith("Кабинет №А1") && _tempRoomName2 != "Кабинет №А1" &&
         _tempRoomName2 != "Кабинет №А10" && _tempRoomName2 != "Кабинет №А11" && _tempRoomName2 != "Кабинет №А12" &&
         _tempRoomName2 != "Кабинет №А13" && _tempRoomName2 != "Кабинет №А14" && _tempRoomName2 != "Кабинет №А15" &&
         _tempRoomName2 != "Кабинет №А16" && _tempRoomName2 != "Кабинет №А17" && _tempRoomName2 != "Кабинет №А18") ||
        _isObjectOnFirstFloor || _tempRoomName2.StartsWith("Кабинет №Г2") || _tempRoomName2.StartsWith("Кабинет №В2") ||
        _tempRoomName2.StartsWith("Кабинет №Б2") || _tempRoomName2.StartsWith("Кабинет №Д2"))
    {
      RoomsButtonFloorCheck(_firstFloorButton, button, _tempRoomName2,_tempRoomName, _firstFloor, 14.1f);
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А2") && _tempRoomName2 != "Кабинет №А2") || _isObjectOnSecondFloor ||
             _tempRoomName2.StartsWith("Кабинет №Г3") || _tempRoomName2.StartsWith("Кабинет №В3") ||
             _tempRoomName2.StartsWith("Кабинет №Б3") || _tempRoomName2.StartsWith("Кабинет №Д3") ||
             _tempRoomName2.StartsWith("Кабинет №И2"))
    {
      RoomsButtonFloorCheck(_secondFloorButton, button, _tempRoomName2, _tempRoomName,_secondFloor, 9.1f);
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А3") && _tempRoomName2 != "Кабинет №А3") || _isObjectOnThirdFloor ||
             _tempRoomName2.StartsWith("Кабинет №Г4") || _tempRoomName2.StartsWith("Кабинет №В4") ||
             _tempRoomName2.StartsWith("Кабинет №Б4") || _tempRoomName2.StartsWith("Кабинет №Д4") ||
             _tempRoomName2.StartsWith("Кабинет №И3"))
    {
      RoomsButtonFloorCheck(_thirdFloorButton, button, _tempRoomName2, _tempRoomName,_thirdFloor, 4.1f);
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А4") && _tempRoomName2 != "Кабинет №А4") || _isObjectOnFourthFloor)
    {
      RoomsButtonFloorCheck(_fourthFloorButton, button, _tempRoomName2, _tempRoomName,_fourthFloor, -0.1f);
    }
  }

  public void ButtonCheck(Button button, float posx, float posy, float posz, GameObject _floor)
  {
    if (button.tag == "WayButtonsFrom")
    {
      _start.transform.position = new Vector3(posx, posy, posz);
      _start.GetComponent<Animation>().Play("StartPutting");

      _textFrom.GetComponent<TMP_InputField>().text = getItemText.text;
      _textFrom.GetComponent<CustomInputField>().UpdateState();

      AI.GetComponent<AILerp>().enabled = false;

      AI.transform.position = new Vector3(posx, posy, posz);

      AI.GetComponent<AILerp>().enabled = enabled;

      _cancel.GetComponent<ListCleaner>().OnClick();

      _wayManager.GetComponent<WayManager>()._isFromInPlace = true;

      _wayManager.GetComponent<WayManager>()._isFromButtonActivated = true;

      TrailRendererDestroyer();
      
      _wayDetails.GetComponent<ListOfDetailsCleaner>().CleanAllButtons();
      _wayDetails.GetComponent<WayDetailsController>().AddPointToWayDetails(getItemText.text);
    }

    if (button.tag == "WayButtonsTo")
    {
      _end.transform.position = new Vector3(posx, posy, posz);
      _end.GetComponent<Animation>().Play("EndPutting");

      _textTo.GetComponent<TMP_InputField>().text = getItemText.text;
      _textTo.GetComponent<CustomInputField>().UpdateState();

      _cancel.GetComponent<ListCleaner>().OnClick();

      _wayManager.GetComponent<WayManager>()._isToInPlace = true;

      _wayManager.GetComponent<WayManager>()._isToButtonActivated = true;

      _camera.GetComponent<MainCamControll>()._endPointText = getItemText.text;

      TrailRendererDestroyer();
    }
  }

  public void ButtonFloorCheck(string _tempRoomName,string _tempRoomName2, string[] _floorObjects, ref bool IsObjectOnFloor)
  {
    foreach (var objects in _floorObjects)
    {
      if (objects == _tempRoomName || objects == _tempRoomName2)
      {
        IsObjectOnFloor = true;
      }
    }
  }

  public void RoomsButtonFloorCheck(Button _floorButton, Button _gameobjectButton, string _tempRoomName,string _tempRoomName2, GameObject _floor, float _posz)
  {
    _floorButton.onClick.Invoke();
    for (int i = 0; i < _floor.transform.GetChild(0).transform.childCount; i++)
    {
      if (_floor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName || _floor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
      {
        ButtonCheck(_gameobjectButton,
          _floor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x,
          _floor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y,
          _posz, _floor
          );
      }
    }
  }

  public void TrailRendererDestroyer()
  {
    if (AI.GetComponentInChildren<TrailRenderer>() != null)
    {
      Destroy(AI.GetComponentInChildren<TrailRenderer>());
    }
  }
}
