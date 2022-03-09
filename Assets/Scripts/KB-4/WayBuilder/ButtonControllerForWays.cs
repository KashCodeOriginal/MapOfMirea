using UnityEngine;
using TMPro;

public class ButtonControllerForWays : MonoBehaviour
{
  //Resourses
  public string[] AllRoom = new string[] {"Вход", "7", "8", "8А", "8Б", "8В", "9", "10", "10А", "10Б", "11", "12", "12А", "12Б", "13", "14", "14А", "15", "16", "18", "20", "20В", "22", "23", "24", "24А", "28", "32", "34", "38", "Туалет" };
  
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
