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
      {"����/�����",(0.22f,-4.27f)},
      {"������� �7",(-4.25f,-0.24f)},
      {"������� �8",(-3.53f,-2.73f)},
      {"������� �8�",(-2.34f,-2.73f)},
      {"������� �8�",(-2.94f, -4)},
      {"������� �8�",(-4.86f, -3.76f)},
      {"������� �9",(-5.35f, -0.24f)},
      {"������� �10",(-6.4f, -3.36f)},
      {"������� �10�",(-6.4f, -4.38f)},
      {"������� �10�",(-5.19f, -2.48f)},
      {"������� �11",(-6.24f, -0.24f)},
      {"������� �12",(-7.6f, -2.48f)},
      {"������� �12�",(-7.54f, -3.76f)},
      {"������� �12�",(-8.5f, -3.76f)},
      {"������� �13",(-7.45f, -0.24f)},
      {"������� �14",(-9.37f, -2.48f)},
      {"������� �14�",(-9.5f, -3.76f)},
      {"������� �15",(-8.88f, -0.24f)},
      {"������� �16",(-10.5f, -3.76f)},
      {"������� �18",(-11.65f, -3.76f)},
      {"������� �20",(-13.44f,-4.14f)},
      {"������� �20�",(-15.38f, -4.18f)},
      {"������� �22",(-15.12f,-3.22f)},
      {"������� �23",(-11.63f,2.28f)},
      {"������� �24",(-15,-2)},
      {"������� �24�",(-14.27f,-0.74f)},
      {"������� �28",(-14.27f,0)},
      {"������� �32",(-15.1f,1.32f)},
      {"������� �34",(-15.1f,2.36f)},
      {"������� �38",(-11.34f,5.1f)},
      {"������",(-11.34f,-1.16f)},
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
