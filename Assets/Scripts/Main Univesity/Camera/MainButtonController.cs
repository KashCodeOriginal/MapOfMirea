using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainButtonController : MonoBehaviour
{
  public List<String> AllRoomsWayBuildings = new List<String>() { "А1", "А2", "А3", "А4", "А5", "А6", "А7", "А8", "А9", "А10", "А11", "А12", "А13", "А14", "А15", "А16", "А17", "А18", "А183", "А184", "А185", "А186", "А187", "А188", "А182", "А181", "А180", "А178", "А189", "А190(б)", "А190", "А191", "А192", "А194", "А195", "А196", "А197", "А198", "А199", "А177.1", "А177", "А175", "А190(а)", "А174(б)", "А174(м)", "А173", "А172", "А171", "А170", "А168", "А166", "А164", "А162", "А160", "А158", "А156", "А137", "А135", "А131", "А129", "А154", "А152", "А150", "А148", "А144", "А142.1", "А142(а)", "А127", "А125", "А123", "А121", "А119", "А117", "А138", "А136", "А134", "А132", "А130", "А128", "А126", "А124", "А115", "А113", "А111", "А107", "А107.1", "А225", "А226", "А227", "А228", "А229", "А230", "А231", "А232", "А235", "А224", "А223", "А222", "А221", "А220", "А219", "А233", "А218", "А217", "А216", "А215", "А214", "А213(б)", "А213(м)", "А212", "А211", "А210", "А209", "А208", "А207", "А206", "А205", "А204", "А203", "А330", "А331", "А332", "А333", "А334", "А335", "А336", "А329", "А328", "А327", "А326", "А325", "А324", "А323", "А322", "А321", "А320", "А318(б)", "А318", "А317", "А316", "А315", "А314", "А313", "А312.1", "А311", "А309", "А307", "А305", "А303", "А301", "А312", "А310", "А308", "А306", "А304", "А302", "А300", "А438", "А436", "А434", "А433", "А430", "А428", "А426", "А429", "А427", "А425", "А409", "А407", "А405", "А403", "А401", "А412", "А410", "А408", "А406", "А404", "А402","Г100","Г101","Г102","Г102.1","Г103","Г104","Г105","Г106","Г106.1","Г106.2","Г107","Г108","Г109.1","Г109.2","Г110.1","Г110.2","Г111.1","Г111.2","Г112.1","Г112.2","В102","В103","В104","В104.1","В104.2","В105","В105.2","В106.1","В106.2","В107","В108","В109","В110","В111","В111.1","В111.2","В112.1","В112.2","В112.3","В112.4","В112.5","В113","Б101","Б102","Б103","Б104","Б105","Б106","Б107","Б108","Б108.1","Б109","Б109.1","Б110","Б111","Б111.1","Б112","Б113","Б114","Б115","Д101","Д102","Д103","Д104","Д105","Д106","Д107","Д108","Д109","Д110","Д114","Д115","Д116","Д117","Д118","Д121","Г201", "Г201.1", "Г201.2", "Г201.3", "Г202", "Г202.1", "Г203", "Г204", "Г205", "Г205.1", "Г206", "Г207", "Г207.1", "Г208", "Г208.1", "Г209", "Г210", "Г210.1", "Г211", "Г211.1", "Г212", "Г213", "Г214", "Г215", "Г216", "Г217", "Г218", "Г219", "Г220", "Г2221", "Г222", "Г223", "Г224", "Г225", "Г226", "Г226.1", "Г226.2", "Г227", "Г227.1", "Г227.2", "Г227.3", "Г228", "Г229", "Г230", "Г231", "Г232", "В201", "В201.1", "В201.2", "В201.3", "В202", "В203", "В204", "В205", "В206", "В207", "В207.1", "В208", "В209", "В210", "В211", "В212", "В213", "В213.1", "В214", "В214.1", "В215", "В216", "В217", "В218", "В218.1", "В219", "В220", "В221", "В222", "В222.1", "В223", "Б201", "Б202", "Б203", "Б204", "Б205", "Б206", "Б207", "Б208", "Б209", "Б210", "Б211", "Б212", "Б213", "Б214", "Б215", "Б216", "Б217", "Б218", "Б219", "Б220", "Б221", "Б222", "Б223", "Б224", "Д201", "Д202", "Д203", "Д204", "Д205", "Д206", "Д207", "Д208", "Д209", "Д210", "Д211", "Д212", "Д213", "Д214", "Д215", "Д216", "Д217", "Д218", "Д219", "Д220", "Д220.1", "Д221", "Д222", "Д223", "Д224", "Д225","Б301", "Б302", "Б303", "Б304", "Б305", "Б306", "Б307", "Б308", "Б309", "Б310", "Б311", "Б312", "Б313", "Б314", "Б315", "Б316", "Б317", "Б318", "Б319", "Б320", "Б321", "Б322", "Б323", "Б324", "Б325", "Б326", "Б327", "В301", "В302", "В302.1", "В303", "В304", "В305", "В306", "В307", "В308", "В309", "В310", "В311", "В312", "В313", "В314", "В315", "В316", "В317", "В318", "В319", "В320", "В321", "В322", "В323", "В324", "В325", "В326", "В327", "В328", "В329", "В330", "В331", "В332", "Г301.1", "Г301.2", "Г301.3", "Г301.4", "Г301.5", "Г301.6", "Г302", "Г302.1", "Г302.2", "Г303", "Г304", "Г305", "Г305.1", "Г305.2", "Г306", "Г307", "Г307.1", "Г308", "Г309", "Г310", "Г311", "Г312", "Г313", "Г314", "Г315", "Г316", "Г317", "Г318", "Г319", "Г320", "Г321.1", "Г322.1", "Г322.2", "Г322.3", "Г322.4", "Г322.5", "Г322.6", "Г322.7", "Г322.8", "Г323", "Г324", "Г325", "Г326", "Г327", "Д301", "Д301.1", "Д301.2", "Д301.3", "Д301.4", "Д301.5", "Д301.6", "Д301.7", "Д301.8", "Д302", "Д303", "Д304", "Д306", "Д307", "Д307.1", "Д308", "Д309", "Д310", "Д311", "Д312", "Д313", "Д314", "Д315", "Д315.1", "Д316", "Д317", "Д318", "Д320", "Д321", "Д322", "Д323", "И200", "И201", "И202", "И204", "И205", "И206", "И215", "Б402", "Б403", "Б404", "Б405", "Б406", "Б407", "Б408", "Б409", "Б410", "Б411", "Б412", "Б413.1", "Б413.2", "Б414", "Б415", "Б416", "Б417", "Б418", "Б419", "Б420", "Б421", "Б422", "Б423", "Б424", "Б425", "Б426", "В401", "В401.1", "В401.2", "В402.1", "В402.2", "В402.3", "В403", "В404.1", "В404.2", "В405.1", "В405.2", "В406", "В407", "В408", "В409", "В410", "В411", "В412", "В413", "В414", "В415", "В416", "В417", "В418", "В419", "В419.1", "В420", "В420.1", "В421", "В422", "В423", "Г401.1", "Г401.2", "Г401.3", "Г402", "Г403", "Г404", "Г405", "Г406", "Г407", "Г407.1", "Г408", "Г409", "Г410", "Г411", "Г412", "Г413", "Г414", "Г415", "Г416", "Г417", "Г418", "Г419", "Г420", "Г420.1", "Г421", "Г422", "Г423", "Г423.1", "Г423.2", "Г424.1", "Г424.2", "Г424.3", "Г424.4", "Г425", "Г426", "Г427", "Г429", "Г430", "Г430.1", "Д401(а)", "Д401(б)", "Д403(а)", "Д403(б)", "Д404(а)", "Д404(б)", "Д407(а,б)", "Д408", "Д409", "Д410", "Д411", "Д412", "Д413", "Д414", "Д415", "Д417", "Д418(а)", "Д418(б)", "Д418(в)", "И300", "И300.1", "И300.2", "И301", "И302", "И303", "И304", "И305", "И307", "И308", "И309", "И310", "И311", "И312", "И313", "И314", "И315", "И316", "И317", "И318", "И319", "И320", "И321", "И322", "И323", "И324", "И325", "И326", "И327", "И328", "И329", "И330","И331","И332","И333","И334", "И338", "И339", "И340", "Гардероб Библиотека", "Мед.Пункт А107","СпортКомплекс", "Столовая 1 Этаж", "Туалет Ж Библиотека", "Туалет М Библиотека", "Туалет М Г207", "Туалет М/Ж А107.1", "Туалет А137", "М/Ж А178", "Туалет Б205", "Туалет В216", "Туалет Д206", "Буфет А213", "Буфет А214", "Буфет Б313", "Буфет В306", "Буфет Вход", "Буфет Г309", "Бюро Пропусков", "Вход/Выход", "Гардероб Главный", "Охрана", "Туалет Ж А208", "Туалет Ж А213", "Туалет М А1", "Туалет М А214", "№Туалет М/Ж А218", "Туалет М/Ж Б327", "Туалет М/Ж В301", "Туалет М/Ж Г327", "Туалет М/Ж Д315", "Приемная Д401(б)", "Приемная Д403(б)", "Приемная Д404(Б)", "Приемная Д408", "Приемная Д415", "Приемная Д417", "Туалет Ж А311", "Туалет Ж А325", "Туалет М Г427", "Туалет М/Ж Б408", "Туалет М/Ж Д403(Б)", "Туалет М/Ж И216", "Учительская" , "Туалет Ж А412", "Туалет М А412", "Туалет М А425", "Офис","Туалет М/Ж В112.5","Туалет М/Ж Д117"};

  public TMP_InputField inputField;
  public GameObject buttonPrefabs;
  public Transform List;

  string _inputFieldText;
  string _tempText;
  TextMeshProUGUI _setItemText;

  private bool _isFirstButtonActivated;
  private bool _isSecondButtonActivated;
  private bool _isThirdButtonActivated;
  private bool _isFourthButtonActivated;
  private bool _isFifthButtonActivated;
  private bool _isSixthButtonActivated;

  private int _buttonsAmmount = 0;

  [SerializeField] private GameObject _firstButton;
  [SerializeField] private GameObject _secondButton;
  [SerializeField] private GameObject _thirdButton;
  [SerializeField] private GameObject _fourthButton;
  [SerializeField] private GameObject _fifthButton;
  [SerializeField] private GameObject _sixthButton;

  [SerializeField] private Image _referenceForButtons;

  public void OnValueChanged()
  {
    foreach (Transform child in List)
      GameObject.Destroy(child.gameObject);

    _inputFieldText = inputField.text;

    for (int i = 0; i < AllRoomsWayBuildings.Count; i++)
    {
      
      if (_isFirstButtonActivated)
      {
        OnLetterSellected("а", i);
      }
      else if (_isSecondButtonActivated)
      {
        OnLetterSellected("б", i);
      }
      else if (_isThirdButtonActivated)
      {
        OnLetterSellected("в", i);
      }
      else if (_isFourthButtonActivated)
      {
        OnLetterSellected("г", i);
      }
      else if (_isFifthButtonActivated)
      {
        OnLetterSellected("д", i);
      }
      else if (_isSixthButtonActivated)
      {
        OnLetterSellected("и", i);
      }
      else
      {
        if (AllRoomsWayBuildings[i].ToLower().Contains(_inputFieldText.ToLower()))
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
    if (AllRoomsWayBuildings[i].ToLower().Contains(_inputFieldText.ToLower()) && AllRoomsWayBuildings[i].ToLower().StartsWith(letter))
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
    _setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
    _tempText = AllRoomsWayBuildings[i];
    _setItemText.text = _tempText;
    _buttonsAmmount++;
  }
  public void OnFirstButtonClick()
  {
    if(_isFirstButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_firstButton);
    }
    else
    {
      OnButtonsClean();
      _isFirstButtonActivated = true;
      OnButtonEnabledColorChanging(_firstButton);
    }
  }
  public void OnSecondButtonClick()
  {
    if (_isSecondButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_secondButton);
    }
    else
    {
      OnButtonsClean();
      _isSecondButtonActivated = true;
      OnButtonEnabledColorChanging(_secondButton);
    }
  }
  public void OnThirdButtonClick()
  {
    if (_isThirdButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_thirdButton);
    }
    else
    {
      OnButtonsClean();
      _isThirdButtonActivated = true;
      OnButtonEnabledColorChanging(_thirdButton);
    }
  }
  public void OnFourthButtonClick()
  {
    if (_isFourthButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_fourthButton);
    }
    else
    {
      OnButtonsClean();
      _isFourthButtonActivated = true;
      OnButtonEnabledColorChanging(_fourthButton);
    }
  }
  public void OnFifthButtonClick()
  {
    if (_isFifthButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_fifthButton);
    }
    else
    {
      OnButtonsClean();
      _isFifthButtonActivated = true;
      OnButtonEnabledColorChanging(_fifthButton);
    }
  }
  public void OnSixthButtonClick()
  {
    if (_isSixthButtonActivated)
    {
      OnButtonsClean();
      OnButtonDisabledColorChanging(_sixthButton);
    }
    else
    {
      OnButtonsClean();
      _isSixthButtonActivated = true;
      OnButtonEnabledColorChanging(_sixthButton);
    }
  }
  public void OnButtonsClean()
  {
    _isFirstButtonActivated = false;
    _isSecondButtonActivated = false;
    _isThirdButtonActivated = false;
    _isFourthButtonActivated = false;
    _isFifthButtonActivated = false;
    _isSixthButtonActivated = false;
    
    OnButtonDisabledColorChanging(_firstButton);
    OnButtonDisabledColorChanging(_secondButton);
    OnButtonDisabledColorChanging(_thirdButton);
    OnButtonDisabledColorChanging(_fourthButton);
    OnButtonDisabledColorChanging(_fifthButton);
    OnButtonDisabledColorChanging(_sixthButton);
  }

  private void OnButtonDisabledColorChanging(GameObject _name)
  {
    _name.GetComponent<Image>().color = _referenceForButtons.color;
  }
  private void OnButtonEnabledColorChanging(GameObject _name)
  {
    _name.GetComponent<Image>().color = new Color(0.654902f, 0.6235294f,1);
  }
}