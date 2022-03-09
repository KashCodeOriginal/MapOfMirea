using UnityEngine;
using TMPro;


public enum _typesOfRooms
{
  FirstFloor,
  SecondFloor,
  ThirdFloor,
  FourthFloor,
}
public class MainButtonControllerForWays : MonoBehaviour
{

  [SerializeField] private MainButtonController _buttonController;

  private _typesOfRooms _rooms;

  private string[] _allRooms;

  public TMP_InputField inputFieldFrom;
  public TMP_InputField inputFieldTo;

  [SerializeField] private GameObject buttonPrefabs;
  public Transform List;

  private string inputFieldFromText;
  private string inputFieldToText;

  private string tempText;
  private TextMeshProUGUI setItemText;

  private int _buttonsAmmount = 0;

  private void Start()
  {
    _allRooms = _buttonController.AllRoomsWayBuilding;
  }
  
  public void OnValueChangedFrom()
  {
    foreach (Transform child in List)
    {
      GameObject.Destroy(child.gameObject);
    }

    inputFieldFromText = inputFieldFrom.text;

    for (int i = 0; i < _allRooms.Length; i++)
    {
      if (_buttonsAmmount <= 25)
      {
        if (_allRooms[i].ToLower().Contains(inputFieldFromText.ToLower()))
        {
          GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
          button.tag = "WayButtonsFrom";
          button.transform.SetParent(List, false);
          button.GetComponent<MainCameraMover>().enabled = false;
          button.GetComponent<MainWayBuilder>().enabled = true;
          setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
          tempText = _allRooms[i];
          setItemText.text = tempText;
          _buttonsAmmount++;
        }
      }
    }
    _buttonsAmmount = 0;
  }
  public void OnValueChangedTo()
  {
    foreach (Transform child in List)
      GameObject.Destroy(child.gameObject);

    inputFieldToText = inputFieldTo.text;


    for (int i = 0; i < _allRooms.Length; i++)
    {
      if (_buttonsAmmount <= 25)
      {
        if (_allRooms[i].ToLower().Contains(inputFieldToText.ToLower()))
        {
          GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
          button.tag = "WayButtonsTo";
          button.transform.SetParent(List, false);
          button.GetComponent<MainCameraMover>().enabled = false;
          button.GetComponent<MainWayBuilder>().enabled = true;
          setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
          tempText = _allRooms[i];
          setItemText.text = tempText;
          _buttonsAmmount++;
        }
      }
    }
    _buttonsAmmount = 0;
  }
}
