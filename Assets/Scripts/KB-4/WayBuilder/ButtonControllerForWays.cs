using UnityEngine;
using TMPro;

public class ButtonControllerForWays : MonoBehaviour
{
  //Resourses
  public string[] AllRoom = new string[] {"����", "7", "8", "8�", "8�", "8�", "9", "10", "10�", "10�", "11", "12", "12�", "12�", "13", "14", "14�", "15", "16", "18", "20", "20�", "22", "23", "24", "24�", "28", "32", "34", "38", "������" };
  
  public TMP_InputField inputFieldFrom;
  public TMP_InputField inputFieldTo;

  [SerializeField] private GameObject buttonPrefabs;
  public Transform List;

  private string inputFieldFromText;
  private string inputFieldToText;

  private string tempText;
  private TextMeshProUGUI setItemText;

  public void OnValueChangedFrom()
  {
    foreach (Transform child in List)
    {
      GameObject.Destroy(child.gameObject);
    }

    inputFieldFromText = inputFieldFrom.text;

    for (int i = 0; i < AllRoom.Length; i++)
    {
      if (AllRoom[i].ToLower().Contains(inputFieldFromText.ToLower()))
      {
        GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        button.tag = "WayButtonsFrom";
        button.transform.SetParent(List, false);
        button.GetComponent<CameraMover>().enabled = false;
        button.GetComponent<WayBuilder>().enabled = true;
        setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
        tempText = AllRoom[i];
        setItemText.text = tempText;
      }
    }
    List.GetComponent<RectTransform>().offsetMin += new Vector2(0, -1110);
  }
  public void OnValueChangedTo()
  {
    foreach (Transform child in List)
      GameObject.Destroy(child.gameObject);

    inputFieldToText = inputFieldTo.text;

    for (int i = 0; i < AllRoom.Length; i++)
    {
      if (AllRoom[i].ToLower().Contains(inputFieldToText))
      {
        GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        button.tag = "WayButtonsTo";
        button.transform.SetParent(List, false);
        button.GetComponent<CameraMover>().enabled = false;
        button.GetComponent<WayBuilder>().enabled = true;
        setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
        tempText = AllRoom[i];
        setItemText.text = tempText;
      }
    }
    List.GetComponent<RectTransform>().offsetMin += new Vector2(0, -1100);
  }
}
