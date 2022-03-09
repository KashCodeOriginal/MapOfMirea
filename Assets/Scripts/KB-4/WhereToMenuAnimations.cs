using UnityEngine;

public class WhereToMenuAnimations : MonoBehaviour
{
  public void WhereToUp()
  {
    GetComponent<Animation>().Play("WhereToUp");
  }
  public void WhereToDown()
  {
    GetComponent<Animation>().Play("WhereToDown");
  }

}
