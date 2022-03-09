using UnityEngine;
using Pathfinding;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Animations;

public class MainDrawWay : MonoBehaviour
{
  [SerializeField] private GameObject AI;

  [SerializeField] private GameObject Start;
  [SerializeField] private GameObject End;

  [SerializeField] Material GreenWay;

  [SerializeField] private GameObject _cancelWayButton;
  [SerializeField] private GameObject Trail;

  [SerializeField] private GameObject _universalMenu;
  [SerializeField] private GameObject _cancel;
  [SerializeField] private GameObject _drawWayButton;

  [SerializeField] private GameObject _camera;

  [SerializeField] private GameObject _wayManager;

  [SerializeField] private GameObject _warningText;

  [SerializeField] private GameObject _mapMarker;

  [SerializeField] private GameObject _drawWay;

  TrailRenderer NewTrails;

  public bool _isWayDrawn = false;

  public void AllowToDrawWay()
  {
    if ((Start.transform.position.x == End.transform.position.x) && (Start.transform.position.y == End.transform.position.y ) && (Start.transform.position.z == End.transform.position.z))
    {
      _warningText.SetActive(true);
      _warningText.GetComponent<Animation>().Play("TextFading");
      StartCoroutine(TextTimer());
    }
    else
    {
      if (_isWayDrawn == false)
      {
        if (_wayManager.GetComponent<WayManager>()._isFromInPlace == true && _wayManager.GetComponent<WayManager>()._isToInPlace == true)
        {
          if (_universalMenu.GetComponent<MenuAnimation>()._isMenuUpped == true)
          {
            _universalMenu.GetComponent<MenuAnimation>().MenuDown();
          }

          _camera.GetComponent<Camera>().GetComponent<MainCamControll>().enabled = true;
          _cancel.GetComponent<ListCleaner>().OnClick();

          _camera.GetComponent<MainCamControll>().targetPosx = Start.transform.position.x;

          AI.GetComponent<AILerp>().canMove = true;

          NewTrails = Trail.AddComponent<TrailRenderer>();
          NewTrails.time = 99999;
          NewTrails.startWidth = 0.15f;
          NewTrails.endWidth = 0.15f;
          NewTrails.minVertexDistance = 0.001f;
          NewTrails.autodestruct = true;
          NewTrails.material = GreenWay;
          NewTrails.textureMode = LineTextureMode.Tile;
          NewTrails.sortingOrder = 5;

          AI.GetComponent<AILerp>().enabled = false;
          AI.GetComponent<AILerp>().enabled = true;

          _cancelWayButton.GetComponent<Animation>().Play("CancelWayButtonUp");

          GameObject.FindWithTag("TextFrom").GetComponent<TMP_InputField>().text = "";
          GameObject.FindWithTag("TextFrom").GetComponent<CustomInputField>().UpdateState();
          GameObject.FindWithTag("TextTo").GetComponent<TMP_InputField>().text = "";
          GameObject.FindWithTag("TextTo").GetComponent<CustomInputField>().UpdateState();

          _cancel.GetComponent<ListCleaner>().OnClick();

          _drawWayButton.GetComponent<Button>().enabled = false;

          _isWayDrawn = true;

          _wayManager.GetComponent<WayManager>()._isFromButtonActivated = false;
          _wayManager.GetComponent<WayManager>()._isToButtonActivated = false;

          _mapMarker.transform.position = new Vector3(-10, -40, 0);
          _mapMarker.GetComponentInChildren<Animation>().Stop();

          _drawWay.SetActive(false);
        }
      }
      else
      {
        Destroy(Trail.GetComponent<TrailRenderer>());
        _isWayDrawn = false;
        AI.GetComponent<AILerp>().canMove = false;
        StartCoroutine(Timer());
      }
    }
  }
  IEnumerator Timer()
  {
    yield return new WaitForSeconds(0.2f);
    AllowToDrawWay();
  }
  IEnumerator TextTimer()
  {
    yield return new WaitForSeconds(1f);
    _warningText.SetActive(false);
  }
}
