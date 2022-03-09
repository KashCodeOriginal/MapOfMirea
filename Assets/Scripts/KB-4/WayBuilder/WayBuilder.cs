using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;
using UnityEngine.Animations;

public class WayBuilder : MonoBehaviour
{
  private TextMeshProUGUI getItemText;

  private GameObject AI;
  private GameObject _start;
  private GameObject _end;
  private GameObject _textFrom;
  private GameObject _textTo;
  private GameObject _cancel;
  private GameObject _wayManager;
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

  }
  public void WayDrawing()
  {
    Button button = gameObject.GetComponent<Button>();
    getItemText = button.GetComponentInChildren<TextMeshProUGUI>();
      switch (getItemText.text.ToLower())
      {
        case "вход":
        ButtonCheck(button, 0.114f, -4.027f);
          break;
        case "7":
          ButtonCheck(button, -4.48f, -0.834f);
          break;
        case "8":
          ButtonCheck(button, -3.596f, -2.874f);
          break;
        case "8а":
          ButtonCheck(button, -2.372f, -3.263f);
          break;
        case "8б":
          ButtonCheck(button, -3.013f, -4.073f);
          break;
        case "8в":
          ButtonCheck(button, -4.488f, -4);
          break;
        case "9":
          ButtonCheck(button, -5.387f, -0.834f);
          break;
        case "10":
          ButtonCheck(button, -6.189f, -3.358f);
          break;
        case "10а":
          ButtonCheck(button, -6.224f, -4.167f);
          break;
        case "10б":
          ButtonCheck(button, -6.47f, -4.303f);
          break;
        case "11":
          ButtonCheck(button, -6.291f, -0.834f);
          break;
        case "12":
          ButtonCheck(button, -7.5f, -2.671f);
          break;
        case "12а":
          ButtonCheck(button, -7.493f, -3.761f);
          break;
        case "12б":
          ButtonCheck(button, -8.39f, -3.761f);
          break;
        case "13":
          ButtonCheck(button, -7.381f, -0.834f);
          break;
        case "14":
          ButtonCheck(button, -9.603f, -2.673f);
          break;
        case "14а":
          ButtonCheck(button, -9.583f, -3.761f);
          break;
        case "15":
          ButtonCheck(button, -8.686f, -0.834f);
          break;
        case "16":
          ButtonCheck(button, -10.584f, -3.761f);
          break;
        case "18":
          ButtonCheck(button, -11.883f, -3.761f);
          break;
        case "20":
          ButtonCheck(button, -13.487f, -4.114f);
          break;
        case "20в":
          ButtonCheck(button, -15.378f, -4.274f);
          break;
        case "22":
          ButtonCheck(button, -14.804f, -3.372f);
          break;
        case "23":
          ButtonCheck(button, -11.688f, 2.287f);
          break;
        case "24":
          ButtonCheck(button, -15.121f, -2.467f);
          break;
        case "24а":
          ButtonCheck(button, -14.286f, -1.333f);
          break;
        case "28":
          ButtonCheck(button, -14.044f, -0.273f);
          break;
        case "32":
          ButtonCheck(button, -15.212f, 0.829f);
          break;
        case "34":
          ButtonCheck(button, -15.212f, 2.229f);
          break;
        case "38":
          ButtonCheck(button, -11.383f, 4.555f);
          break;
        case "туалет":
          ButtonCheck(button, -10.65f, -1.47f);
          break;
      }
  }
  public void ButtonCheck(Button button, float posx, float posy)
  {
    if (button.tag == "WayButtonsFrom")
    {
      _start.transform.position = new Vector3(posx, posy, -0.1f);
      _start.GetComponent<Animation>().Play("StartPutting");

      _textFrom.GetComponent<TMP_InputField>().text = getItemText.text;
      _textFrom.GetComponent<CustomInputField>().UpdateState();

      AI.GetComponent<AILerp>().enabled = false;

      AI.transform.position = new Vector3(posx, posy, -0.1f);

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
      _end.transform.position = new Vector3(posx, posy, 0);
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
