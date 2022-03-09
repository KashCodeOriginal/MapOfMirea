using UnityEngine;
using Pathfinding;

public class WayBuilderSpeed : MonoBehaviour
{
  [SerializeField] GameObject _ai;
  public void OnClick()
  {
    _ai.GetComponent<AILerp>().speed = System.Convert.ToInt32(gameObject.name);
  }
  public void WayBuilderSpeedLoad(int speed)
  {
    _ai.GetComponent<AILerp>().speed = speed;
  }
}
