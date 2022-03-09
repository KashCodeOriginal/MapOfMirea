using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
  public bool _isMenuUpped;
  public void MenuUp()
  {
    GetComponent<Animation>().Play("MenuUp");
    _isMenuUpped = true;
  }
  public void MenuDown()
  {
    GetComponent<Animation>().Play("MenuDown");
    _isMenuUpped = false;
  }
}
