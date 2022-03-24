using TMPro;
using UnityEngine;

public class MainWhereToController : MonoBehaviour
{
    [SerializeField] private GameObject _numberOfClassroom;
    [SerializeField] private GameObject _classRoomInfo;

    [SerializeField] private GameObject _marker;
    
    public void OnClick()
    {
        _numberOfClassroom.GetComponent<TMP_Text>().text = gameObject.name;
        ObjectInfoGetter();

        _marker.transform.position = new Vector3(gameObject.GetComponent<Renderer>().bounds.center.x,gameObject.GetComponent<Renderer>().bounds.center.y + 0.3f, gameObject.transform.position.z - 0.1f);
        _marker.GetComponentInChildren<Animation>().Play("MarkerUpDown");
    }
    private void ObjectInfoGetter()
    {
        switch (gameObject.GetComponent<RoomsSorting>().RoomType)
        {
            case RoomsSorting.RoomsTypes.PracticeStudyingClass:
                _classRoomInfo.GetComponent<TMP_Text>().text = "������� ���������";
                break;
            case RoomsSorting.RoomsTypes.Toilet:
                _classRoomInfo.GetComponent<TMP_Text>().text = "������";   
                break;
            case RoomsSorting.RoomsTypes.Shop:
                _classRoomInfo.GetComponent<TMP_Text>().text = "�����/��������";   
                break;
            case RoomsSorting.RoomsTypes.DressingRoom:
                _classRoomInfo.GetComponent<TMP_Text>().text = "��������";   
                break;
            case RoomsSorting.RoomsTypes.MedicalRoom:
                _classRoomInfo.GetComponent<TMP_Text>().text = "����������� �����";   
                break;
            case RoomsSorting.RoomsTypes.SportRoom:
                _classRoomInfo.GetComponent<TMP_Text>().text = "���������� ���";   
                break;
            case RoomsSorting.RoomsTypes.ReadingStudyingClass:
                _classRoomInfo.GetComponent<TMP_Text>().text = "���������� ���������";
                break;
            case RoomsSorting.RoomsTypes.InOutPlace:
                _classRoomInfo.GetComponent<TMP_Text>().text = "���� � ������/����� �� ������";
                break;
            case RoomsSorting.RoomsTypes.Library:
                _classRoomInfo.GetComponent<TMP_Text>().text = "����������";
                break;
            case RoomsSorting.RoomsTypes.SecurityControlRoom:
                _classRoomInfo.GetComponent<TMP_Text>().text = "������";
                break;
            case RoomsSorting.RoomsTypes.EntryControlRoom:
                _classRoomInfo.GetComponent<TMP_Text>().text = "���� ���������";
                break;
        }
    }
}
