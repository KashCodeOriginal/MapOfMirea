using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using Pathfinding;
using UnityEngine.UI;


public class FromToButtonControll : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI _numberOClassroom;
  [SerializeField] private GameObject _startPoint;
  [SerializeField] private GameObject _ai;
  [SerializeField] private GameObject _endPoint;
  [SerializeField] private GameObject _wayManager;
  [SerializeField] private GameObject _drawWay;
  [SerializeField] private GameObject _drawWayButton;
  [SerializeField] private GameObject _whereToPanelCancel;

  [SerializeField] private Animation _cancelWayButtonAnim;

  [SerializeField] private TMP_InputField _textFrom;
  [SerializeField] private TMP_InputField _textTo;

  [SerializeField] private GameObject _whereToPanel;

  public void OnFromButtonClick()
  {
    _startPoint.transform.position = new Vector3(CheckCollection(_numberOClassroom.text).Item1, CheckCollection(_numberOClassroom.text).Item2, -0.1f);

    _startPoint.GetComponent<Animation>().Play("StartPutting");

    _textFrom.text = _numberOClassroom.text.Replace("Кабинет №","");

    _ai.GetComponent<AILerp>().enabled = false;
    _ai.transform.position = _startPoint.transform.position;

    if (_ai.GetComponentInChildren<TrailRenderer>() != null)
    {
      Destroy(_ai.GetComponentInChildren<TrailRenderer>());
      _cancelWayButtonAnim.Play("CancelWayButtonDown");
      if(_wayManager.GetComponent<WayManager>()._isFromInPlace == true)
      {
        _endPoint.transform.position = new Vector3(-9.5f, -40, 0);
      }
    }
    _wayManager.GetComponent<WayManager>()._isFromInPlace = true;
    _wayManager.GetComponent<WayManager>()._isFromButtonActivated = true;

    if (CanDrawWay(_wayManager.GetComponent<WayManager>()._isFromButtonActivated, _wayManager.GetComponent<WayManager>()._isToButtonActivated) == true)
    {
      StartCoroutine(Timer());
    }

    if(_endPoint.transform.position.x == -9.5f && _endPoint.transform.position.y == -40)
    {
      _whereToPanel.GetComponent<Animation>().Play("WhereToDown");
    }
    
  }
  public void OnToButtonClick()
  {
    _endPoint.transform.position = new Vector3(CheckCollection(_numberOClassroom.text).Item1, CheckCollection(_numberOClassroom.text).Item2, 0);

    _endPoint.GetComponent<Animation>().Play("EndPutting");

    _textTo.text = _numberOClassroom.text.Replace("Кабинет №", "");

    if (_ai.GetComponentInChildren<TrailRenderer>() != null)
    {
      _cancelWayButtonAnim.Play("CancelWayButtonDown");
      Destroy(_ai.GetComponentInChildren<TrailRenderer>());
      if(_wayManager.GetComponent<WayManager>()._isToInPlace == true)
      {
        _startPoint.transform.position = new Vector3(-9, -40, -0.1f);
      }
    }

    _wayManager.GetComponent<WayManager>()._isToInPlace = true;

    _wayManager.GetComponent<WayManager>()._isToButtonActivated = true;

    if (CanDrawWay(_wayManager.GetComponent<WayManager>()._isFromButtonActivated, _wayManager.GetComponent<WayManager>()._isToButtonActivated) == true)
    {
      StartCoroutine(Timer());
    }

    if (_startPoint.transform.position.x == -9 && _startPoint.transform.position.y == -40)
    {
      _whereToPanel.GetComponent<Animation>().Play("WhereToDown");
    }
  }

  public (float, float) CheckCollection(string _text)
  {
    var Rooms = new Dictionary<string, (float, float)>
    {
      {"Кабинет №7",(-4.48f, -0.834f)},
      {"Кабинет №8",(-3.596f, -2.874f)},
      {"Кабинет №8А",(-2.372f, -3.263f)},
      {"Кабинет №8Б",(-3.013f, -4.073f)},
      {"Кабинет №8В",(-4.488f, -4)},
      {"Кабинет №9",(-5.387f, -0.834f)},
      {"Кабинет №10",(-6.189f, -3.358f)},
      {"Кабинет №10А",(-6.189f, -4.319f)},
      {"Кабинет №10Б",(-5.18f, -2.67f)},
      {"Кабинет №11",(-6.291f, -0.834f)},
      {"Кабинет №12",(-7.5f, -2.671f)},
      {"Кабинет №12А",(-7.493f, -3.761f)},
      {"Кабинет №12Б",(-8.39f, -3.761f)},
      {"Кабинет №13",(-7.381f, -0.834f)},
      {"Кабинет №14",(-9.603f, -2.673f)},
      {"Кабинет №14А",(-9.583f, -3.761f)},
      {"Кабинет №15",(-8.686f, -0.834f)},
      {"Кабинет №16",(-10.584f, -3.761f)},
      {"Кабинет №18",(-11.883f, -3.761f)},
      {"Кабинет №20",(-13.487f, -4.114f)},
      {"Кабинет №20В",(-15.378f, -4.274f)},
      {"Кабинет №22",(-14.804f, -3.372f)},
      {"Кабинет №23",(-11.688f, 2.287f)},
      {"Кабинет №24",(-15.121f, -2.467f)},
      {"Кабинет №24А",(-14.286f, -1.333f)},
      {"Кабинет №28",(-14.044f, -0.273f)},
      {"Кабинет №32",(-15.212f, 0.829f)},
      {"Кабинет №34",(-15.212f, 2.229f)},
      {"Кабинет №38",(-11.383f, 4.555f)},
      {"Вход/Выход",(0.114f, -4.027f)},
      {"Туалет",(-10.65f, -1.47f)},
    };
    foreach (var rooms in Rooms)
    {
      if (rooms.Key == _text)
      {
        return (rooms.Value.Item1, rooms.Value.Item2);
      }
    }
    return (0, 0);
  }
  public bool CanDrawWay(bool first, bool second)
  {
    if (first && second)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  IEnumerator Timer()
  {
    _drawWay.SetActive(true);
    yield return new WaitForSeconds(0.1f);
    _drawWayButton.GetComponent<Button>().onClick.Invoke();
    yield return new WaitForSeconds(0.1f);
    _whereToPanelCancel.GetComponent<Button>().onClick.Invoke();
    yield return new WaitForSeconds(0.1f);
    _drawWay.SetActive(false);
  }
}
