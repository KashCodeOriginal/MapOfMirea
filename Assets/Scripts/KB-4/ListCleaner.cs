using UnityEngine;
using TMPro;

public class ListCleaner : MonoBehaviour
{
  [SerializeField] Transform _findList;
  [SerializeField] Transform _drawWayList;
  [SerializeField] GameObject _textInput;
  [SerializeField] GameObject _findSomething;
  public void OnClick()
  {
    if(_findSomething.activeSelf == true)
    {
      _textInput.GetComponent<TMP_InputField>().text = "";
      _textInput.GetComponent<CustomInputField>().UpdateState();
    }
    foreach (Transform findchild in _findList)
    {
      GameObject.Destroy(findchild.gameObject);
    }
    foreach (Transform drawwaychild in _drawWayList)
    {
      GameObject.Destroy(drawwaychild.gameObject);
    }
  }
}
