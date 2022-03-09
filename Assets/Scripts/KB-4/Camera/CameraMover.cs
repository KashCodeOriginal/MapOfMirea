using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CameraMover : MonoBehaviour
{

  TextMeshProUGUI getItemText;

  GameObject _canvas;

  private string _tempRoomName;

  public void Start()
  {
    Button button = gameObject.GetComponent<Button>();

    button.onClick.AddListener(MenuDown);
    button.onClick.AddListener(CamMover);

    _canvas = GameObject.FindWithTag("Canvas");
  }
  public void MenuDown()
  {
    GameObject.Find("UniversalMenu").GetComponent<Animation>().Play("MenuDown");
    GameObject.FindWithTag("MainCamera").GetComponent<Animation>().Play("MenuDownForSearch");
  }
  public void CamMover()
  {
    var Rooms = new Dictionary<string, (float, float, float, float)>
    {
      {"вход",(-0.18f,-0.42f,0.22f,-4.27f)},
      {"7",(-4f,0f,-4.25f,-0.24f)},
      {"8",(-3.5f,-1,-3.53f,-2.73f)},
      {"8а",(-2.5f,-1,-2.34f,-2.73f)},
      {"8б",(-3,-1, -2.94f, -4)},
      {"8в",(-5,-1,-4.86f, -3.76f)},
      {"9",(-5.3f,0, -5.35f, -0.24f)},
      {"10",(-6.3f,-1, -6.4f, -3.36f)},
      {"10а",(-6.3f,-1, -6.4f, -4.38f)},
      {"10б",(-5,-1, -5.19f, -2.48f)},
      {"11",(-6,0, -6.24f, -0.24f)},
      {"12",(-7.5f,-1, -7.6f, -2.48f)},
      {"12а",(-7,-1, -7.54f, -3.76f)},
      {"12б",(-8.5f,-1, -8.5f, -3.76f)},
      {"13",(-7.5f,0, -7.45f, -0.24f)},
      {"14",(-9.3f,-1, -9.37f, -2.48f)},
      {"14а",(-9.3f,-1, -9.5f, -3.76f)},
      {"15",(-9,0, -8.88f, -0.24f)},
      {"16",(-10,-1,-10.5f, -3.76f)},
      {"18",(-11,-1,-11.65f, -3.76f)},
      {"20",(-13.25f,-1,-13.44f,-4.14f)},
      {"20в",(-13.25f,-1, -15.38f, -4.18f)},
      {"22",(-13.25f,-1,-15.12f,-3.22f)},
      {"23",(-11.5f,0.4f,-11.63f,2.28f)},
      {"24",(-13.25f,-1,-15,-2)},
      {"24а",(-13.25f,-1,-14.27f,-0.74f)},
      {"28",(-13.25f,0.4f,-14.27f,0)},
      {"32",(-13.25f,0.4f,-15.1f,1.32f)},
      {"34",(-13.25f,0.4f,-15.1f,2.36f)},
      {"38",(-11.5f,0.4f,-11.34f,5.1f)},
      {"туалет",(-11,-1,-11.34f,-1.16f)},
    };

    Button button = gameObject.GetComponent<Button>();
    getItemText = button.GetComponentInChildren<TextMeshProUGUI>();

    foreach (var rooms in Rooms)
    {
      if(rooms.Key == getItemText.text.ToLower())
      {
        GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Stop("MarkerUpDown");
        MarkerToPosMover(rooms.Value.Item3, rooms.Value.Item4);
        GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Play("MarkerUpDown");
        CamToPosMover(rooms.Value.Item1, rooms.Value.Item2, getItemText.text);
      }
    }
    var obj = GameObject.FindWithTag("FindSomething");
    obj.SetActive(false);
  }
  public void CamToPosMover(float posx, float posy, string _getItemText)
  {
    GameObject.Find("Main Camera").GetComponent<CamControl>().targetPosx = posx;
    GameObject.Find("Main Camera").GetComponent<CamControl>().targetPosy = posy;

    if(_getItemText == "Туалет")
    {
      _tempRoomName = "Туалет";
    }
    else if (_getItemText == "Вход")
    {
      _tempRoomName = "Вход/Выход";
    }
    else
    {
      _tempRoomName = $"Кабинет №{_getItemText}";
    }
    for(int i = 0; i < _canvas.transform.childCount; i++)
    {
      if (_canvas.transform.GetChild(i).name == _tempRoomName)
      {
        _canvas.transform.GetChild(i).GetComponent<Button>().onClick.Invoke();
      }
    }
  }
  public void MarkerToPosMover(float x, float y)
  {
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(x, y, 0);
  }
  public void MarkerStartPosMover()
  {
    GameObject.FindGameObjectWithTag("MarkerParent").transform.position = new Vector3(-10, -40, 0);
    GameObject.FindGameObjectWithTag("Marker").GetComponent<Animation>().Stop();
  }
} 