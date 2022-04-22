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

  private string[] _firstFloorObjects = new string[]{"�������� ����������", "���.����� �107", "�������������", "�������� 1 ����", "������ � ����������", "������ � ����������", "������ � �207", "������ �/� �107.1", "������ �/� �137", "������ �/� �178", "������ �205", "������ �216", "������ �206"};
  private string[] _secondFloorObjects = new string[] {"������� ��8", "������� ��7", "������� ��6", "������� ��5","������� ��4", "������� ��3", "������� ��2", "������� ��1", "����� �213", "����� �214", "����� �313", "����� �306", "����� ����", "����� �309" ,"���� ���������", "����/�����", "�������� �������", "������", "������ � �208", "������ � �213", "������ � �1", "������ � �214", "������� �/� �218", "������ �/� �327", "������ �/� �301", "������ �/� �327", "������ �/� �315"};
  private string[] _thirdFloorObjects = new string[] { "������� ��18", "������� ��17", "������� ��16", "������� ��15", "������� ��14", "������� ��13", "������� ��12", "������� ��11", "������� ��10", "������� ��9", "�������� �401(�)", "�������� �403(�)", "�������� �404(�)", "�������� �408", "�������� �415", "�������� �417", "������ � �311", "������ � �325", "������ � �427", "������ �/� �408", "������ �/� �403(�)", "������ �/� �216", "�����������"};
  private string[] _fourthFloorObjects = new string[] { "������ � �412", "������� � �412", "������ � �425" };

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

    _tempRoomName = $"������� �{getItemText.text}";
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

    if (_tempRoomName.StartsWith("������� ��1"))
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
    if ((_tempRoomName.StartsWith("������� ��1") && _tempRoomName != "������� ��1" && _tempRoomName != "������� ��10" && _tempRoomName != "������� ��11" && _tempRoomName != "������� ��12" && _tempRoomName != "������� ��13" && _tempRoomName != "������� ��14" && _tempRoomName != "������� ��15" && _tempRoomName != "������� ��16" && _tempRoomName != "������� ��17" && _tempRoomName != "������� ��18") || _isObjectOnFirstFloor == true || _tempRoomName.StartsWith("������� ��2") || _tempRoomName.StartsWith("������� ��2") || _tempRoomName.StartsWith("������� ��2") || _tempRoomName.StartsWith("������� ��2"))
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
    else if ((_tempRoomName.StartsWith("������� ��2") && _tempRoomName != "������� ��2") || _isObjectOnSecondFloor == true || _tempRoomName.StartsWith("������� ��3") || _tempRoomName.StartsWith("������� ��3") || _tempRoomName.StartsWith("������� ��3") || _tempRoomName.StartsWith("������� ��3") || _tempRoomName.StartsWith("������� ��2"))
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
    else if ((_tempRoomName.StartsWith("������� ��3") && _tempRoomName != "������� ��3") || _isObjectOnThirdFloor == true || _tempRoomName.StartsWith("������� ��4") || _tempRoomName.StartsWith("������� ��4") || _tempRoomName.StartsWith("������� ��4") || _tempRoomName.StartsWith("������� ��4") || _tempRoomName.StartsWith("������� ��3"))
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
    else if ((_tempRoomName.StartsWith("������� ��4") && _tempRoomName != "������� ��4") || _isObjectOnFourthFloor == true)
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