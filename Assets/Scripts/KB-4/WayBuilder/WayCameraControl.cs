using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Pathfinding;

public class WayCameraControl : MonoBehaviour
{
  [SerializeField] private GameObject _camera;
  [SerializeField] private GameObject AI;
  [SerializeField] private GameObject Start;
  [SerializeField] private GameObject End;
  [SerializeField] private GameObject _wayManager;
  [SerializeField] private Button _drawWay;

  public void CameraContoroller()
  {
    if (Start.transform.position.x == End.transform.position.x && Start.transform.position.y == End.transform.position.y)
    {
      return;
    }
    else
    {
      if (_wayManager.GetComponent<WayManager>()._isFromInPlace == true && _wayManager.GetComponent<WayManager>()._isToInPlace == true)
      {
        _camera.GetComponent<Animation>().Play("WayBuilderCameraUp");

        StartCoroutine(WaiterTimer());

        StartCoroutine(ObjectPossitionCheck());
      }
    }
  }
  IEnumerator ObjectPossitionCheck()
  {
    while (true)
    {
      yield return new WaitForSeconds(1f);
      if (System.Math.Round(AI.transform.position.x, 1) == System.Math.Round(End.transform.position.x, 1) && System.Math.Round(AI.transform.position.y, 1) == System.Math.Round(End.transform.position.y, 1))
      {
        _camera.GetComponent<CamControl>().targetPosx = Start.transform.position.x;
        _camera.GetComponent<Animation>().Play("WayBuilderCameraDown");
        _drawWay.enabled = true;

        AI.GetComponent<AILerp>().enabled = false;
        yield break;
      }
    }
  }
  IEnumerator WaiterTimer()
  {
    yield return new WaitForSeconds(1.5f);
    _camera.GetComponent<CamControl>().targetPosx = -6.5f;
    _camera.GetComponent<CamControl>().targetPosy = -0.4f;
  }

  public void AnimationCanceller()
  {
    _camera.GetComponent<Animation>().Stop("WayBuilderCameraUp");
    if(_camera.GetComponent<Camera>().orthographicSize == 20)
    {
      _camera.GetComponent<Animation>().Play("WayBuilderCameraDown");
    }
  }
}
