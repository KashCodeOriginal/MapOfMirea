using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEntred : MonoBehaviour
{
    [SerializeField] private WayDetailsController _wayDetails;

    [SerializeField] private Sprite _ladders;

    private List<string> _directionPhrases = new List<string>() {"Продолжайте маршрут по первому этажу", "Продолжайте маршрут по второму этажу", "Продолжайте маршрут по третьему этажу", "Продолжайте маршрут по четвертому этажу", "Вниз по лестнице на первый этаж", "Вверх по лестнице на второй этаж", "Вниз по лестнице на второй этаж", "Вверх по лестнице на третий этаж", "Вниз по лестнице на третий этаж", "Вверх по лестнице на четвертый этаж"};    
    private void OnTriggerEnter(Collider col)
    {
        switch (col.name)
        {
            case "1":
                DirectionCheck(col, $"{_directionPhrases[5]} у библиотеки", $"{_directionPhrases[4]} к библиотеке");
                break;
            case "2":
                DirectionCheck(col, $"{_directionPhrases[5]} у киберзоны",$"{_directionPhrases[4]} к киберзоне");
                break;
            case "3":
                DirectionCheck(col,$"{_directionPhrases[5]} у А173",$"{_directionPhrases[4]} у А216");
                break;
            case "4":
                DirectionCheck(col, $"{_directionPhrases[5]} у А178", $"{_directionPhrases[4]} у А233");
                break;
            case "5":
                DirectionCheck(col,$"{_directionPhrases[5]} у А172",$"{_directionPhrases[4]} у А5");
                break;
            case "6":
                DirectionCheck(col,"Вверх по главной лестнице на второй этаж","Вниз по главной лестнице на первый этаж");
                break;
            case "7":
                DirectionCheck(col, $"{_directionPhrases[5]} у А117",$"{_directionPhrases[4]} у А212");
                break;
            case "8":
                DirectionCheck(col,$"{_directionPhrases[5]} у А115",$"{_directionPhrases[4]} у А210");
                break;
            case "9":
                DirectionCheck(col,$"{_directionPhrases[5]} у А124",$"{_directionPhrases[4]} у А208 к столовой");
                break;
            case "10":
                DirectionCheck(col,$"{_directionPhrases[5]} в самом конце коридора",$"{_directionPhrases[4]} у А203");
                break;
            case "11":
                DirectionCheck(col,$"{_directionPhrases[7]} в корпусе Г",$"{_directionPhrases[6]} в корпусе Г");
                break;
            case "12":
                DirectionCheck(col,$"{_directionPhrases[7]} в корпусе В",$"{_directionPhrases[6]} в корпусе В");
                break;
            case "13":
                DirectionCheck(col,$"{_directionPhrases[7]} в корпусе Б",$"{_directionPhrases[6]} в корпусе Б");
                break;
            case "14":
                DirectionCheck(col,$"{_directionPhrases[7]} в корпусе Д",$"{_directionPhrases[6]} в корпусе Д");
                break;
            case "15":
                DirectionCheck(col,$"{_directionPhrases[7]} корпуса И",$"{_directionPhrases[6]} к И200");
                break;
            case "16":
                DirectionCheck(col,$"{_directionPhrases[7]} у А7",$"{_directionPhrases[6]} у А323");
                break;
            case "17":
                DirectionCheck(col,$"{_directionPhrases[7]} у А223",$"{_directionPhrases[6]} у А336");
                break;
            case "18":
                DirectionCheck(col,$"{_directionPhrases[7]} у А5",$"{_directionPhrases[6]} у А321");
                break;
            case "19":
                DirectionCheck(col,"Вверх по главной лестнице на третий этаж","Вниз по главной лестнице на второй этаж");
                break;
            case "20":
                DirectionCheck(col,$"{_directionPhrases[7]} у А212",$"{_directionPhrases[6]} у А316");
                break;
            case "21":
                DirectionCheck(col,$"{_directionPhrases[7]} у А3",$"{_directionPhrases[6]} у А315");
                break;
            case "22":
                DirectionCheck(col,$"{_directionPhrases[7]} у А1",$"{_directionPhrases[6]} у А312.1");
                break;
            case "23":
                DirectionCheck(col,$"{_directionPhrases[7]} у А203",$"{_directionPhrases[6]} у А301");
                break;
            case "24":
                DirectionCheck(col,$"{_directionPhrases[9]} в корпусе Г",$"{_directionPhrases[8]} в корпусе Г");
                break;
            case "25":
                DirectionCheck(col,$"{_directionPhrases[9]} в корпусе В",$"{_directionPhrases[8]} в корпусе В");
                break;
            case "26":
                DirectionCheck(col,$"{_directionPhrases[9]} в корпусе Б",$"{_directionPhrases[8]} в корпусе Б");
                break;
            case "27":
                DirectionCheck(col,$"{_directionPhrases[9]} в корпусе Д",$"{_directionPhrases[8]} в корпусе Д");
                break;
            case "28":
                DirectionCheck(col,$"{_directionPhrases[9]} у А336",$"{_directionPhrases[8]} у А426");
                break;
            case "29":
                DirectionCheck(col,$"{_directionPhrases[9]} у А312.1",$"{_directionPhrases[8]} у А412");
                break;
            case "30":
                DirectionCheck(col,$"{_directionPhrases[9]} у А301",$"{_directionPhrases[8]} у А401");
                break;
            case "31":
                DirectionCheck(col,$"{_directionPhrases[9]} у А10 ",$"{_directionPhrases[8]} у А412");
                break;
            case "32":
                DirectionCheck(col,$"{_directionPhrases[9]} у А18 ",$"{_directionPhrases[8]} у А426");
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

