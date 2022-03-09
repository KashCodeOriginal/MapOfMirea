using UnityEngine;
using TMPro;

public class MainButtonController : MonoBehaviour
{
  public string[] AllRoomsWayBuilding = new string[] { "�1", "�2", "�3", "�4", "�5", "�6", "�7", "�8", "�9", "�10", "�11", "�12", "�13", "�14", "�15", "�16", "�17", "�18", "�183", "�184", "�185", "�186", "�187", "�188", "�182", "�181", "�180", "�178", "�189", "�190(�)", "�190", "�191", "�192", "�194", "�195", "�196", "�197", "�198", "�199", "�177.1", "�177", "�175", "�190(�)", "�174(�)", "�174(�)", "�173", "�172", "�171", "�170", "�168", "�166", "�164", "�162", "�160", "�158", "�156", "�137", "�135", "�131", "�129", "�154", "�152", "�150", "�148", "�144", "�142.1", "�142(�)", "�127", "�125", "�123", "�121", "�119", "�117", "�138", "�136", "�134", "�132", "�130", "�128", "�126", "�124", "�115", "�113", "�111", "�107", "�107.1", "�225", "�226", "�227", "�228", "�229", "�230", "�231", "�232", "�235", "�224", "�223", "�222", "�221", "�220", "�219", "�233", "�218", "�217", "�216", "�215", "�214", "�213(�)", "�213(�)", "�212", "�211", "�210", "�209", "�208", "�207", "�206", "�205", "�204", "�203", "�330", "�331", "�332", "�333", "�334", "�335", "�336", "�329", "�328", "�327", "�326", "�325", "�324", "�323", "�322", "�321", "�320", "�318(�)", "�318", "�317", "�316", "�315", "�314", "�313", "�312.1", "�311", "�309", "�307", "�305", "�303", "�301", "�312", "�310", "�308", "�306", "�304", "�302", "�300", "�438", "�436", "�434", "�433", "�430", "�428", "�426", "�429", "�427", "�425", "�409", "�407", "�405", "�403", "�401", "�412", "�410", "�408", "�406", "�404", "�402", "�201", "�201.1", "�201.2", "�201.3", "�202", "�202.1", "�203", "�204", "�205", "�205.1", "�206", "�207", "�207.1", "�208", "�208.1", "�209", "�210", "�210.1", "�211", "�211.1", "�212", "�213", "�214", "�215", "�216", "�217", "�218", "�219", "�220", "�2221", "�222", "�223", "�224", "�225", "�226", "�226.1", "�226.2", "�227", "�227.1", "�227.2", "�227.3", "�228", "�229", "�230", "�231", "�232", "�201", "�201.1", "�201.2", "�201.3", "�202", "�203", "�204", "�205", "�206", "�207", "�207.1", "�208", "�209", "�210", "�211", "�212", "�213", "�213.1", "�214", "�214.1", "�215", "�216", "�217", "�218", "�218.1", "�219", "�220", "�221", "�222", "�222.1", "�223", "�201", "�202", "�203", "�204", "�205", "�206", "�207", "�208", "�209", "�210", "�211", "�212", "�213", "�214", "�215", "�216", "�217", "�218", "�219", "�220", "�221", "�222", "�223", "�224", "�201", "�202", "�203", "�204", "�205", "�206", "�207", "�208", "�209", "�210", "�211", "�212", "�213", "�214", "�215", "�216", "�217", "�218", "�219", "�220", "�220.1", "�221", "�222", "�223", "�224", "�225","�301", "�302", "�303", "�304", "�305", "�306", "�307", "�308", "�309", "�310", "�311", "�312", "�313", "�314", "�315", "�316", "�317", "�318", "�319", "�320", "�321", "�322", "�323", "�324", "�325", "�326", "�327", "�301", "�302", "�302.1", "�303", "�304", "�305", "�306", "�307", "�308", "�309", "�310", "�311", "�312", "�313", "�314", "�315", "�316", "�317", "�318", "�319", "�320", "�321", "�322", "�323", "�324", "�325", "�326", "�327", "�328", "�329", "�330", "�331", "�332", "�301.1", "�301.2", "�301.3", "�301.4", "�301.5", "�301.6", "�302", "�302.1", "�302.2", "�303", "�304", "�305", "�305.1", "�305.2", "�306", "�307", "�307.1", "�308", "�309", "�310", "�311", "�312", "�313", "�314", "�315", "�316", "�317", "�318", "�319", "�320", "�321.1", "�322.1", "�322.2", "�322.3", "�322.4", "�322.5", "�322.6", "�322.7", "�322.8", "�323", "�324", "�325", "�326", "�327", "�301", "�301.1", "�301.2", "�301.3", "�301.4", "�301.5", "�301.6", "�301.7", "�301.8", "�302", "�303", "�304", "�306", "�307", "�307.1", "�308", "�309", "�310", "�311", "�312", "�313", "�314", "�315", "�315.1", "�316", "�317", "�318", "�320", "�321", "�322", "�323", "�200", "�201", "�202", "�204", "�205", "�206", "�215", "�402", "�403", "�404", "�405", "�406", "�407", "�408", "�409", "�410", "�411", "�412", "�413.1", "�413.2", "�414", "�415", "�416", "�417", "�418", "�419", "�420", "�421", "�422", "�423", "�424", "�425", "�426", "�401", "�401.1", "�401.2", "�402.1", "�402.2", "�402.3", "�403", "�404.1", "�404.2", "�405.1", "�405.2", "�406", "�407", "�408", "�409", "�410", "�411", "�412", "�413", "�414", "�415", "�416", "�417", "�418", "�419", "�419.1", "�420", "�420.1", "�421", "�422", "�423", "�401.1", "�401.2", "�401.3", "�402", "�403", "�404", "�405", "�406", "�407", "�407.1", "�408", "�409", "�410", "�411", "�412", "�413", "�414", "�415", "�416", "�417", "�418", "�419", "�420", "�420.1", "�421", "�422", "�423", "�423.1", "�423.2", "�424.1", "�424.2", "�424.3", "�424.4", "�425", "�426", "�427", "�429", "�430", "�430.1", "�401(�)", "�401(�)", "�403(�)", "�403(�)", "�404(�)", "�404(�)", "�407(�,�)", "�408", "�409", "�410", "�411", "�412", "�413", "�414", "�415", "�417", "�418(�)", "�418(�)", "�418(�)", "�300", "�300.1", "�300.2", "�301", "�302", "�303", "�304", "�305", "�307", "�308", "�309", "�310", "�311", "�312", "�313", "�314", "�315", "�316", "�317", "�318", "�319", "�320", "�321", "�322", "�323", "�324", "�325", "�326", "�327", "�328", "�329", "�330", "�338", "�339", "�340", "�������� ����������", "���.����� �107","�������������", "�������� 1 ����", "������ � ����������", "������ � ����������", "������ � �207", "������ �/� �107.1", "������ �137", "�/� �178", "������ �205", "������ �216", "������ �206", "����� �213", "����� �214", "����� �313", "����� �306", "����� ����", "����� �309", "���� ���������", "����/�����", "�������� �������", "������", "������ � �208", "������ � �213", "������ � �1", "������ � �214", "������� �/� �218", "������ �/� �327", "������ �/� �301", "������ �/� �327", "������ �/� �315", "�������� �401(�)", "�������� �403(�)", "�������� �404(�)", "�������� �408", "�������� �415", "�������� �417", "������ � �311", "������ � �325", "������ � �427", "������ �/� �408", "������ �/� �403(�)", "������ �/� �216", "�����������" , "������ � �412", "������ � �412", "������ � �425"};

  public TMP_InputField inputField;
  public GameObject buttonPrefabs;
  public Transform List;

  string inputFieldText;
  string tempText;
  TextMeshProUGUI setItemText;

  private bool _isFirstButtonActivated = false;
  private bool _isSecondButtonActivated = false;
  private bool _isThirdButtonActivated = false;
  private bool _isFourthButtonActivated = false;
  private bool _isFifthButtonActivated = false;
  private bool _isSixthButtonActivated = false;

  private int _buttonsAmmount = 0;

  public void OnValueChanged()
  {
    foreach (Transform child in List)
      GameObject.Destroy(child.gameObject);

    inputFieldText = inputField.text;

    for (int i = 0; i < AllRoomsWayBuilding.Length; i++)
    {
      
      if (_isFirstButtonActivated == true)
      {
        OnLetterSellected("�", i);
      }
      else if (_isSecondButtonActivated == true)
      {
        OnLetterSellected("�", i);
      }
      else if (_isThirdButtonActivated == true)
      {
        OnLetterSellected("�", i);
      }
      else if (_isFourthButtonActivated == true)
      {
        OnLetterSellected("�", i);
      }
      else if (_isFifthButtonActivated == true)
      {
        OnLetterSellected("�", i);
      }
      else if (_isSixthButtonActivated)
      {
        OnLetterSellected("�", i);
      }
      else
      {
        if (AllRoomsWayBuilding[i].ToLower().Contains(inputFieldText.ToLower()))
        {
          if (_buttonsAmmount <= 25)
          {
            OnButtonsInstantiate(i);
          }
        }
      }

    }
    _buttonsAmmount = 0;
  }
  
  public void OnLetterSellected(string letter, int i)
  {
    if (AllRoomsWayBuilding[i].ToLower().Contains(inputFieldText.ToLower()) && AllRoomsWayBuilding[i].ToLower().StartsWith(letter))
    {
      if (_buttonsAmmount <= 25)
      {
        OnButtonsInstantiate(i);
      }
    }
  }
  public void OnButtonsInstantiate(int i)
  {
    GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    button.tag = "Buttons";
    button.transform.SetParent(List, false);
    button.GetComponent<MainCameraMover>().enabled = true;
    //button.GetComponent<WayBuilder>().enabled = false;
    setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
    tempText = AllRoomsWayBuilding[i];
    setItemText.text = tempText;
    _buttonsAmmount++;
  }
  public void OnFirstButtonClick()
  {
    if(_isFirstButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isFirstButtonActivated = true;
    }
  }
  public void OnSecondButtonClick()
  {
    if (_isSecondButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isSecondButtonActivated = true;
    }
  }
  public void OnThirdButtonClick()
  {
    if (_isThirdButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isThirdButtonActivated = true;
    }
  }
  public void OnFourthButtonClick()
  {
    if (_isFourthButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isFourthButtonActivated = true;
    }
  }
  public void OnFifthButtonClick()
  {
    if (_isFifthButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isFifthButtonActivated = true;
    }
  }
  public void OnSixthButtonClick()
  {
    if (_isSixthButtonActivated == true)
    {
      OnButtonsClean();
    }
    else
    {
      OnButtonsClean();
      _isSixthButtonActivated = true;
    }
  }
  private void OnButtonsClean()
  {
    _isFirstButtonActivated = false;
    _isSecondButtonActivated = false;
    _isThirdButtonActivated = false;
    _isFourthButtonActivated = false;
    _isFifthButtonActivated = false;
    _isSixthButtonActivated = false;
  }
}