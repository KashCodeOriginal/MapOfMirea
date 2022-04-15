using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEntred : MonoBehaviour
{
    [SerializeField] private WayDetailsController _wayDetails;

    [SerializeField] private Sprite _ladders;

    private List<string> _directionPhrases = new List<string>() {"����������� ������� �� ������� �����", "����������� ������� �� ������� �����", "����������� ������� �� �������� �����", "����������� ������� �� ���������� �����", "���� �� �������� �� ������ ����", "����� �� �������� �� ������ ����", "���� �� �������� �� ������ ����", "����� �� �������� �� ������ ����", "���� �� �������� �� ������ ����", "����� �� �������� �� ��������� ����"};    
    private void OnTriggerEnter(Collider col)
    {
        switch (col.name)
        {
            case "1":
                DirectionCheck(col, $"{_directionPhrases[5]} � ����������", $"{_directionPhrases[4]} � ����������");
                break;
            case "2":
                DirectionCheck(col, $"{_directionPhrases[5]} � ���������",$"{_directionPhrases[4]} � ���������");
                break;
            case "3":
                DirectionCheck(col,$"{_directionPhrases[5]} � �173",$"{_directionPhrases[4]} � �216");
                break;
            case "4":
                DirectionCheck(col, $"{_directionPhrases[5]} � �178", $"{_directionPhrases[4]} � �233");
                break;
            case "5":
                DirectionCheck(col,$"{_directionPhrases[5]} � �172",$"{_directionPhrases[4]} � �5");
                break;
            case "6":
                DirectionCheck(col,"����� �� ������� �������� �� ������ ����","���� �� ������� �������� �� ������ ����");
                break;
            case "7":
                DirectionCheck(col, $"{_directionPhrases[5]} � �117",$"{_directionPhrases[4]} � �212");
                break;
            case "8":
                DirectionCheck(col,$"{_directionPhrases[5]} � �115",$"{_directionPhrases[4]} � �210");
                break;
            case "9":
                DirectionCheck(col,$"{_directionPhrases[5]} � �124",$"{_directionPhrases[4]} � �208 � ��������");
                break;
            case "10":
                DirectionCheck(col,$"{_directionPhrases[5]} � ����� ����� ��������",$"{_directionPhrases[4]} � �203");
                break;
            case "11":
                DirectionCheck(col,$"{_directionPhrases[7]} � ������� �",$"{_directionPhrases[6]} � ������� �");
                break;
            case "12":
                DirectionCheck(col,$"{_directionPhrases[7]} � ������� �",$"{_directionPhrases[6]} � ������� �");
                break;
            case "13":
                DirectionCheck(col,$"{_directionPhrases[7]} � ������� �",$"{_directionPhrases[6]} � ������� �");
                break;
            case "14":
                DirectionCheck(col,$"{_directionPhrases[7]} � ������� �",$"{_directionPhrases[6]} � ������� �");
                break;
            case "15":
                DirectionCheck(col,$"{_directionPhrases[7]} ������� �",$"{_directionPhrases[6]} � �200");
                break;
            case "16":
                DirectionCheck(col,$"{_directionPhrases[7]} � �7",$"{_directionPhrases[6]} � �323");
                break;
            case "17":
                DirectionCheck(col,$"{_directionPhrases[7]} � �223",$"{_directionPhrases[6]} � �336");
                break;
            case "18":
                DirectionCheck(col,$"{_directionPhrases[7]} � �5",$"{_directionPhrases[6]} � �321");
                break;
            case "19":
                DirectionCheck(col,"����� �� ������� �������� �� ������ ����","���� �� ������� �������� �� ������ ����");
                break;
            case "20":
                DirectionCheck(col,$"{_directionPhrases[7]} � �212",$"{_directionPhrases[6]} � �316");
                break;
            case "21":
                DirectionCheck(col,$"{_directionPhrases[7]} � �3",$"{_directionPhrases[6]} � �315");
                break;
            case "22":
                DirectionCheck(col,$"{_directionPhrases[7]} � �1",$"{_directionPhrases[6]} � �312.1");
                break;
            case "23":
                DirectionCheck(col,$"{_directionPhrases[7]} � �203",$"{_directionPhrases[6]} � �301");
                break;
            case "24":
                DirectionCheck(col,$"{_directionPhrases[9]} � ������� �",$"{_directionPhrases[8]} � ������� �");
                break;
            case "25":
                DirectionCheck(col,$"{_directionPhrases[9]} � ������� �",$"{_directionPhrases[8]} � ������� �");
                break;
            case "26":
                DirectionCheck(col,$"{_directionPhrases[9]} � ������� �",$"{_directionPhrases[8]} � ������� �");
                break;
            case "27":
                DirectionCheck(col,$"{_directionPhrases[9]} � ������� �",$"{_directionPhrases[8]} � ������� �");
                break;
            case "28":
                DirectionCheck(col,$"{_directionPhrases[9]} � �336",$"{_directionPhrases[8]} � �426");
                break;
            case "29":
                DirectionCheck(col,$"{_directionPhrases[9]} � �312.1",$"{_directionPhrases[8]} � �412");
                break;
            case "30":
                DirectionCheck(col,$"{_directionPhrases[9]} � �301",$"{_directionPhrases[8]} � �401");
                break;
            case "31":
                DirectionCheck(col,$"{_directionPhrases[9]} � �10 ",$"{_directionPhrases[8]} � �412");
                break;
            case "32":
                DirectionCheck(col,$"{_directionPhrases[9]} � �18 ",$"{_directionPhrases[8]} � �426");
                break;
        }
    }
    //DirectionCheck(col,"","");

    private void DirectionCheck(Collider _col,string _firstDirection, string _secondDirection)
    {   
        if (_col.GetComponent<TriggerDirection>()._direction == TriggerDirection.WayDirection.Up)
        {
            OnDirectionFirst(_firstDirection);
        }
        else if (_col.GetComponent<TriggerDirection>()._direction == TriggerDirection.WayDirection.Down)
        {
            OnDirectionSecond(_secondDirection);
        }
    }
    
    private void OnDirectionFirst(string _text)
    {
        _wayDetails.AddPointToWayDetails(_text);
    }
    private void OnDirectionSecond(string _text)
    {
        _wayDetails.AddPointToWayDetails(_text);
    }
}

