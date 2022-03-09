using UnityEngine;
using UnityEngine.UI;

public class IconsColorChanger : MonoBehaviour
{
  [SerializeField] private Image[] _icons;

  [SerializeField] private SpriteRenderer _marker;
  public void OnIconSettingsClick()
  {
    for(int i = 0; i < _icons.Length; i++)
    {
      _icons[i].color = gameObject.GetComponent<Image>().color;
    }
    _marker.color = gameObject.GetComponent<Image>().color;
  }
  public void OnIconSettingsLoad(float r, float g, float b)
  {
    for (int i = 0; i < _icons.Length; i++)
    {
      _icons[i].color = new Color(r, g, b);
    }
    _marker.color = new Color(r, g, b);
  }
}
