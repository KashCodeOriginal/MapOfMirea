using UnityEngine;
using Pathfinding;

public class PointsBack : MonoBehaviour
{
  [SerializeField] private GameObject StartPoint;
  [SerializeField] private GameObject EndPoint;

  [SerializeField] private GameObject Trail;
  [SerializeField] private GameObject AI;

  [SerializeField] private GameObject _cancelWayButton;

  [SerializeField] private GameObject _wayManager;
  public void OnClick()
  {
    AI.transform.position = new Vector3(-9,-40,-0.1f);
    AI.GetComponent<AILerp>().canMove = false;
    StartPoint.transform.position = new Vector3(-9, -40, -0.1f);
    _wayManager.GetComponent<WayManager>()._isFromInPlace = false;
    EndPoint.transform.position = new Vector3(-9.5f, -40, 0);
    _wayManager.GetComponent<WayManager>()._isToInPlace = false;
    Destroy(Trail.GetComponent<TrailRenderer>());

    _cancelWayButton.GetComponent<Animation>().Play("CancelWayButtonDown");
  }
}
