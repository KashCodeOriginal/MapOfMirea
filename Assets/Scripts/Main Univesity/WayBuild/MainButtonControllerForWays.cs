using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainButtonControllerForWays : MonoBehaviour
{
  [SerializeField] private MainButtonController _buttonController;
  private List<String> _allRooms;

  public TMP_InputField inputFieldFrom;
  public TMP_InputField inputFieldTo;

  [SerializeField] private GameObject buttonPrefabs;
  public Transform List;

  private string _inputFieldFromText;
  private string _inputFieldToText;

  private string _tempText;
  private TextMeshProUGUI _setItemText;

  private int _buttonsAmmount;

  private void Start()
  {
    _allRooms = _buttonController.AllRoomsWayBuildings;
  }
  
  public void OnValueChangedFrom()
  {
    foreach (Transform child in List)
    {
      GameObject.Destroy(child.gameObject);
    }

    _inputFieldFromText = inputFieldFrom.text;

    for (int i = 0; i < _allRooms.Count; i++)
    {
      if (_buttonsAmmount <= 25)
      {
        if (_allRooms[i].ToLower().Contains(_inputFieldFromText.ToLower()))
        {
          GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
          button.tag = "WayButtonsFrom";
          button.transform.SetParent(List, false);
          button.GetComponent<MainCameraMover>().enabled = false;
          button.GetComponent<MainWayBuilder>().enabled = true;
          _setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
          _tempText = _allRooms[i];
          _setItemText.text = _tempText;
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

    _inputFieldToText = inputFieldTo.text;


    for (int i = 0; i < _allRooms.Count; i++)
    {
      if (_buttonsAmmount <= 25)
      {
        if (_allRooms[i].ToLower().Contains(_inputFieldToText.ToLower()))
        {
          GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
          button.tag = "WayButtonsTo";
          button.transform.SetParent(List, false);
          button.GetComponent<MainCameraMover>().enabled = false;
          button.GetComponent<MainWayBuilder>().enabled = true;
          _setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
          _tempText = _allRooms[i];
          _setItemText.text = _tempText;
          _buttonsAmmount++;
        }
      }
    }
    _buttonsAmmount = 0;
  }
}
