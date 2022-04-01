using UnityEngine;
using UnityEngine.UI;

public class MenuColorChanging : MonoBehaviour
{

  [SerializeField] private Image[] _images;

  [SerializeField] private GameObject _buttonPrefab;
  [SerializeField] private GameObject _detailsButtonPrefab;
  public void OnMenuClick()
  {
    _buttonPrefab.GetComponent<Image>().color = gameObject.GetComponent<Image>().color;
    _detailsButtonPrefab.GetComponent<Image>().color = gameObject.GetComponent<Image>().color;

    for (int i = 0; i < _images.Length; i++)
    {
      _images[i].color = gameObject.GetComponent<Image>().color;
    }
  }
  public void OnMenuLoad(float r, float g, float b)
  {
    _buttonPrefab.GetComponent<Image>().color = new Color(r, g, b);
    _detailsButtonPrefab.GetComponent<Image>().color = new Color(r, g, b);  
    
    for (int i = 0; i < _images.Length; i++)
    {
      _images[i].color = new Color(r, g, b);
    }
  }
}
