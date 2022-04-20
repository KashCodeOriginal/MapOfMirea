using System;
using System.Collections;
using Pathfinding;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainFromToButtonsControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _classRoomNumber;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _ai;
    [SerializeField] private GameObject _endPoint;
    [SerializeField] private GameObject _wayManager;
    [SerializeField] private GameObject _drawWay;
    [SerializeField] private GameObject _drawWayButton;
    [SerializeField] private GameObject _whereToPanelCancel;

    [SerializeField] private Animation _cancelWayButtonAnim;
    [SerializeField] private WayDetailsController _wayDetailsController;

    [SerializeField] private TMP_InputField _textFrom;
    [SerializeField] private TMP_InputField _textTo;

    [SerializeField] private GameObject _whereToPanel;

    [SerializeField] private GameObject _wayDetails;
    [SerializeField] private GameObject _wayDetailsButton;

    [SerializeField] private Camera _camera;
    
    private GameObject _room;
    public void OnFromClick()
    {
        _room = GameObject.Find(_classRoomNumber.text);

        float _zPos = Mathf.Round(_room.GetComponent<Renderer>().bounds.center.z);

        _zPos = (_zPos == 0) ? _zPos - 0.1f : _zPos + 0.1f;

        _startPoint.transform.position = new Vector3(_room.GetComponent<Renderer>().bounds.center.x,_room.GetComponent<Renderer>().bounds.center.y, _zPos);
        _startPoint.GetComponent<Animation>().Play("StartPutting");
        
        _textFrom.text = _classRoomNumber.text.Replace("Кабинет №", "");

        _ai.GetComponent<AILerp>().enabled = false;
        _ai.transform.position = _startPoint.transform.position;
        
        if (_ai.GetComponentInChildren<TrailRenderer>() != null)
        {
            Destroy(_ai.GetComponentInChildren<TrailRenderer>());
            _cancelWayButtonAnim.Play("CancelWayButtonDown");
            
            _wayDetails.GetComponent<WayDetailsAnimation>().AnimationStateControl();

            _wayDetailsButton.GetComponent<Animation>().Play("WayDetailsDown");
            
            _wayDetails.GetComponent<ListOfDetailsCleaner>().CleanAllButtons();
            
            if(_wayManager.GetComponent<WayManager>()._isFromInPlace)
            {
                _endPoint.transform.position = new Vector3(-9.5f, -40, 0);
            }
        }
        _wayManager.GetComponent<WayManager>()._isFromInPlace = true;
        _wayManager.GetComponent<WayManager>()._isFromButtonActivated = true;
        
        if (CanDrawWay(_wayManager.GetComponent<WayManager>()._isFromButtonActivated, _wayManager.GetComponent<WayManager>()._isToButtonActivated))
        {
            StartCoroutine(Timer());
        }

        if(_endPoint.transform.position.x == -9.5f && _endPoint.transform.position.y == -40)
        {
            _whereToPanel.GetComponent<Animation>().Play("WhereToDown");
        }
        
        _wayDetails.GetComponent<ListOfDetailsCleaner>().CleanAllButtons();
        
        _wayDetailsController.AddPointToWayDetails(_textFrom.text);
    }

    public void OnToCLick()
    {
        _room = GameObject.Find(_classRoomNumber.text);
        
        _endPoint.transform.position = new Vector3(_room.GetComponent<Renderer>().bounds.center.x,_room.GetComponent<Renderer>().bounds.center.y,_room.GetComponent<Renderer>().bounds.center.z);

        _endPoint.GetComponent<Animation>().Play("EndPutting");
        
        _drawWay.SetActive(true);        
        _textTo.text = _classRoomNumber.text.Replace("Кабинет №","");
        _drawWay.SetActive(false);

        _camera.GetComponent<MainCamControll>()._endPointText = _textTo.text;

        if (_ai.GetComponentInChildren<TrailRenderer>() != null)
        {
            _cancelWayButtonAnim.Play("CancelWayButtonDown");
            Destroy(_ai.GetComponentInChildren<TrailRenderer>());
            
            _wayDetails.GetComponent<WayDetailsAnimation>().AnimationStateControl();
            
            _wayDetailsButton.GetComponent<Animation>().Play("WayDetailsDown");
            
            _wayDetails.GetComponent<ListOfDetailsCleaner>().CleanAllButtons();
        }

        _wayManager.GetComponent<WayManager>()._isToInPlace = true;

        _wayManager.GetComponent<WayManager>()._isToButtonActivated = true;

        if (CanDrawWay(_wayManager.GetComponent<WayManager>()._isFromButtonActivated, _wayManager.GetComponent<WayManager>()._isToButtonActivated))
        {
            StartCoroutine(Timer());
        }

        if (_startPoint.transform.position.x == -9 && _startPoint.transform.position.y == -40)
        {
            _whereToPanel.GetComponent<Animation>().Play("WhereToDown");
        }
    }
    public bool CanDrawWay(bool first, bool second)
    {
        if (first && second)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Timer()
    {
        _drawWay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _drawWayButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        _whereToPanelCancel.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        _drawWay.SetActive(false);
    }
}
