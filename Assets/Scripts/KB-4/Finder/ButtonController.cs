using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
  //Resourses
  public string[] AllRoomsWayBuildings = new string[] { "Вход", "7", "8", "8А", "8Б", "8В", "9", "10", "10А", "10Б", "11", "12", "12А", "12Б", "13", "14", "14А", "15", "16", "18", "20", "20В", "22", "23", "24", "24А", "28", "32", "34", "38", "Туалет"};

  public TMP_InputField inputField;
  public GameObject buttonPrefabs;
  public Transform List;

  string inputFieldText;
  string tempText;
  TextMeshProUGUI setItemText;

  public void OnValueChanged()
  {
    foreach (Transform child in List)
      GameObject.Destroy(child.gameObject);

    inputFieldText = inputField.text;

    for (int i = 0; i < AllRoomsWayBuildings.Length; i++)
    {
      if (AllRoomsWayBuildings[i].ToLower().Contains(inputFieldText.ToLower()))
      {
        GameObject button = Instantiate(buttonPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        button.tag = "Buttons";
        button.transform.SetParent(List, false);
        button.GetComponent<CameraMover>().enabled = true;
        button.GetComponent<WayBuilder>().enabled = false;
        setItemText = button.GetComponentInChildren<TextMeshProUGUI>();
        tempText = AllRoomsWayBuildings[i];
        setItemText.text = tempText;
      }
    }
    List.GetComponent<RectTransform>().offsetMin += new Vector2(0, -1070);
  }
}
