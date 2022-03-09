using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MarkerToTapMover : MonoBehaviour
{
  [SerializeField] private GameObject _mapMarker;
  private string _className;

  public void OnClick()
  {
    _className = gameObject.name;
    _mapMarker.transform.position = new Vector3(Collection(_className).Item1, Collection(_className).Item2);
    _mapMarker.GetComponentInChildren<Animation>().Play("MarkerUpDown");
  }
  public (float,float) Collection(string _name)
  {
    var Rooms = new Dictionary<string, (float, float)>
    {
      {"Вход/Выход",(0.22f,-4.27f)},
      {"Кабинет №7",(-4.25f,-0.24f)},
      {"Кабинет №8",(-3.53f,-2.73f)},
      {"Кабинет №8А",(-2.34f,-2.73f)},
      {"Кабинет №8Б",(-2.94f, -4)},
      {"Кабинет №8В",(-4.86f, -3.76f)},
      {"Кабинет №9",(-5.35f, -0.24f)},
      {"Кабинет №10",(-6.4f, -3.36f)},
      {"Кабинет №10А",(-6.4f, -4.38f)},
      {"Кабинет №10Б",(-5.19f, -2.48f)},
      {"Кабинет №11",(-6.24f, -0.24f)},
      {"Кабинет №12",(-7.6f, -2.48f)},
      {"Кабинет №12А",(-7.54f, -3.76f)},
      {"Кабинет №12Б",(-8.5f, -3.76f)},
      {"Кабинет №13",(-7.45f, -0.24f)},
      {"Кабинет №14",(-9.37f, -2.48f)},
      {"Кабинет №14А",(-9.5f, -3.76f)},
      {"Кабинет №15",(-8.88f, -0.24f)},
      {"Кабинет №16",(-10.5f, -3.76f)},
      {"Кабинет №18",(-11.65f, -3.76f)},
      {"Кабинет №20",(-13.44f,-4.14f)},
      {"Кабинет №20В",(-15.38f, -4.18f)},
      {"Кабинет №22",(-15.12f,-3.22f)},
      {"Кабинет №23",(-11.63f,2.28f)},
      {"Кабинет №24",(-15,-2)},
      {"Кабинет №24А",(-14.27f,-0.74f)},
      {"Кабинет №28",(-14.27f,0)},
      {"Кабинет №32",(-15.1f,1.32f)},
      {"Кабинет №34",(-15.1f,2.36f)},
      {"Кабинет №38",(-11.34f,5.1f)},
      {"Туалет",(-11.34f,-1.16f)},
    };

    foreach(var room in Rooms)
    {
      if(room.Key == _name)
      {
        return (room.Value.Item1,room.Value.Item2);
      }
    }
    return (0, 0);
  }
}
