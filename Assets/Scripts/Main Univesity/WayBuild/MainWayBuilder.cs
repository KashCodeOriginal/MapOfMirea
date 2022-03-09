using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;
using UnityEngine.Animations;

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
  private Button _firstFloorButton;
  private GameObject _firstFloor;
  private Button _secondFloorButton;
  private GameObject _secondFloor;
  private Button _thirdFloorButton;
  private GameObject _thirdFloor;
  private Button _fourthFloorButton;
  private GameObject _fourthFloor;

  private string[] _firstFloorObjects = new string[] { "Кабинет №Гардероб Библиотека", "Кабинет №Мед.Пункт А107", "Кабинет №", "Кабинет №СпортКомплекс", "Кабинет №Столовая 1 Этаж", "Кабинет №Туалет Ж Библиотека", "Кабинет №Туалет М Библиотека", "Кабинет №Туалет М Г207", "Кабинет №Туалет М/Ж А107.1", "Кабинет №Туалет А137", "Кабинет №М/Ж А178", "Кабинет №Туалет Б205", "Кабинет №Туалет В216", "Кабинет №Туалет Д206" };
  private string[] _secondFloorObjects = new string[] { "Кабинет №А8", "Кабинет №А7", "Кабинет №А6", "Кабинет №А5", "Кабинет №А4", "Кабинет №А3", "Кабинет №А2", "Кабинет №А1", "Кабинет №Буфет А213", "Кабинет №Буфет А214", "Кабинет №Буфет Б313", "Кабинет №Буфет В306", "Кабинет №Буфет Вход", "Кабинет №Буфет Г309", "Кабинет №Бюро Пропусков", "Кабинет №Вход/Выход", "Кабинет №Гардероб Главный", "Кабинет №Охрана", "Кабинет №Туалет Ж А208", "Кабинет №Туалет Ж А213", "Кабинет №Туалет М А1", "Кабинет №Туалет М А214", "№Туалет М/Ж А218", "Кабинет №Туалет М/Ж Б327", "Кабинет №Туалет М/Ж В301", "Кабинет №Туалет М/Ж Г327", "Кабинет №Туалет М/Ж Д315" };
  private string[] _thirdFloorObjects = new string[] { "Кабинет №А18", "Кабинет №А17", "Кабинет №А16", "Кабинет №А15", "Кабинет №А14", "Кабинет №А13", "Кабинет №А12", "Кабинет №А11", "Кабинет №А10", "Кабинет №А9", "Кабинет №Приемная Д401(б)", "Кабинет №Приемная Д403(б)", "Кабинет №Приемная Д404(Б)", "Кабинет №Приемная Д408", "Кабинет №Приемная Д415", "Кабинет №Приемная Д417", "Кабинет №Туалет Ж А311", "Кабинет №Туалет Ж А325", "Кабинет №Туалет М Г427", "Кабинет №Туалет М/Ж Б408", "Кабинет №Туалет М/Ж Д403(Б)", "Кабинет №Туалет М/Ж И216", "Кабинет №Учительская" };
  private string[] _fourthFloorObjects = new string[] { "Кабинет №Туалет Ж А412", "Кабинет №Туалет М А412", "Кабинет №Туалет М А425" };

  private bool _isObjectOnFirstFloor = false;
  private bool _isObjectOnSecondFloor = false;
  private bool _isObjectOnThirdFloor = false;
  private bool _isObjectOnFourthFloor = false;

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
    _firstFloor = GameObject.FindWithTag("FirstFloor");
    _firstFloorButton = GameObject.FindWithTag("FirstFloorButton").GetComponent<Button>();
    _secondFloor = GameObject.FindWithTag("SecondFloor");
    _secondFloorButton = GameObject.FindWithTag("SecondFloorButton").GetComponent<Button>();
    _thirdFloor = GameObject.FindWithTag("ThirdFloor");
    _thirdFloorButton = GameObject.FindWithTag("ThirdFloorButton").GetComponent<Button>();
    _fourthFloor = GameObject.FindWithTag("FourthFloor");
    _fourthFloorButton = GameObject.FindWithTag("FourthFloorButton").GetComponent<Button>();
  }
  public void WayDrawing()
  {
    Button button = gameObject.GetComponent<Button>();
    getItemText = button.GetComponentInChildren<TextMeshProUGUI>();

    string _tempRoomName2 = $"Кабинет №{getItemText.text}";

    foreach (var objects in _firstFloorObjects)
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
          ButtonCheck(button, _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x, _firstFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y, 14.1f);
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
          ButtonCheck(button, _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x, _secondFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y, 9.1f);
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
          ButtonCheck(button, _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x, _thirdFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y, 4.1f);
        }
      }
    }
    else if ((_tempRoomName2.StartsWith("Кабинет №А4") && _tempRoomName2 != "Кабинет №А4") || _isObjectOnFourthFloor == true)
    {
      _fourthFloorButton.onClick.Invoke();
      for (int i = 0; i < _fourthFloor.transform.GetChild(0).transform.childCount; i++)
      {
        if (_thirdFloor.transform.GetChild(0).transform.GetChild(i).name == _tempRoomName2)
        {
          ButtonCheck(button, _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.x, _fourthFloor.transform.GetChild(0).transform.GetChild(i).GetComponent<MeshRenderer>().bounds.center.y, -0.1f);
        }
      }
    }
  }
  public void ButtonCheck(Button button, float posx, float posy, float posz)
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

      if (AI.GetComponentInChildren<TrailRenderer>() != null)
      {
        Destroy(AI.GetComponentInChildren<TrailRenderer>());
      }
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

      if (AI.GetComponentInChildren<TrailRenderer>() != null)
      {
        Destroy(AI.GetComponentInChildren<TrailRenderer>());
      }
    }
  }
}
