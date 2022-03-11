using System;
using TMPro;
using UnityEngine;

public class MainWhereToController : MonoBehaviour
{
    [SerializeField] private GameObject _numberOfClassroom;
    [SerializeField] private GameObject _classRoomInfo;
    
    public void OnClick()
    {
        _numberOfClassroom.GetComponent<TMP_Text>().text = gameObject.name;
        ObjectInfoGetter();
    }

    private void ObjectInfoGetter()
    {
        switch (gameObject.GetComponent<RoomsSorting>().RoomType)
        {
            case RoomsSorting.RoomsTypes.StudyingClass:
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
        }
    }
}
