using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Pathfinding;


public class SettingsSave : MonoBehaviour
{
  UserData _userData = new UserData();
  private string _path;

  [SerializeField] private GameObject[] _gameObjects;

  [SerializeField] private GameObject[] _gameObjectForLoad;

  private void Awake()
  {
#if UNITY_ANDROID && !UNITY_EDITOR
    _path = System.IO.Path.Combine(Application.persistentDataPath, "UserData.json");
#else
    _path = System.IO.Path.Combine(Application.streamingAssetsPath, "UserData.json");
#endif
    
    if (File.Exists(_path))
    {
      _userData = JsonUtility.FromJson<UserData>(File.ReadAllText(_path));
    }
    Load();
  }
  public void Save()
  {
    _userData.BackGround[0] = _gameObjects[0].GetComponent<Camera>().backgroundColor.r;
    _userData.BackGround[1] = _gameObjects[0].GetComponent<Camera>().backgroundColor.g;
    _userData.BackGround[2] = _gameObjects[0].GetComponent<Camera>().backgroundColor.b;

    _userData.Rooms[0] = _gameObjects[1].GetComponent<SpriteRenderer>().color.r;
    _userData.Rooms[1] = _gameObjects[1].GetComponent<SpriteRenderer>().color.g;
    _userData.Rooms[2] = _gameObjects[1].GetComponent<SpriteRenderer>().color.b;

    _userData.Text[0] = _gameObjects[2].GetComponent<TextMeshProUGUI>().color.r;
    _userData.Text[1] = _gameObjects[2].GetComponent<TextMeshProUGUI>().color.g;
    _userData.Text[2] = _gameObjects[2].GetComponent<TextMeshProUGUI>().color.b;

    _userData.Icons[0] = _gameObjects[3].GetComponent<Image>().color.r;
    _userData.Icons[1] = _gameObjects[3].GetComponent<Image>().color.g;
    _userData.Icons[2] = _gameObjects[3].GetComponent<Image>().color.b;

    _userData.Menu[0] = _gameObjects[4].GetComponent<Image>().color.r;
    _userData.Menu[1] = _gameObjects[4].GetComponent<Image>().color.g;
    _userData.Menu[2] = _gameObjects[4].GetComponent<Image>().color.b;

    _userData.Way[0] = _gameObjects[5].GetComponent<SpriteRenderer>().color.r;
    _userData.Way[1] = _gameObjects[5].GetComponent<SpriteRenderer>().color.g;
    _userData.Way[2] = _gameObjects[5].GetComponent<SpriteRenderer>().color.b;

    _userData.WaySpeed = Convert.ToInt16(_gameObjects[6].GetComponent<AILerp>().speed);

    string jsonString = JsonUtility.ToJson(_userData);
    File.WriteAllText(_path, jsonString);
  }
  public void Load()
  {
    if (File.Exists(_path))
    {
      string _userData = File.ReadAllText(_path);
      UserData _data = JsonUtility.FromJson<UserData>(_userData);

      _gameObjectForLoad[0].GetComponent<MapColorChanging>().OnWallsLoad(_data.Rooms[0], _data.Rooms[1], _data.Rooms[2]);
      _gameObjectForLoad[1].GetComponent<MapColorChanging>().OnBackGroundLoad(_data.BackGround[0], _data.BackGround[1], _data.BackGround[2]);
      _gameObjectForLoad[2].GetComponent<MapColorChanging>().OnTextLoad(_data.Text[0], _data.Text[1], _data.Text[2]);
      _gameObjectForLoad[3].GetComponent<MenuColorChanging>().OnMenuLoad(_data.Menu[0], _data.Menu[1], _data.Menu[2]);
      _gameObjectForLoad[4].GetComponent<IconsColorChanger>().OnIconSettingsLoad(_data.Icons[0], _data.Icons[1], _data.Icons[2]);
      _gameObjectForLoad[5].GetComponent<WayColorSetiings>().OnWayLoad(_data.Way[0], _data.Way[1], _data.Way[2]);
      _gameObjectForLoad[6].GetComponent<WayBuilderSpeed>().WayBuilderSpeedLoad(_data.WaySpeed);
    }
  }
#if UNITY_ANDROID && !UNITY_EDITOR
  private void OnApplicationPause(bool pause)
  {
    if (pause) Save();
  }
#endif
  private void OnApplicationQuit()
  {
    Save();
  }

  [Serializable]
  public class UserData
  {
    public float[] Rooms = new float[3];
    public float[] BackGround = new float[3];
    public float[] Text = new float[3];

    public float[] Menu = new float[3];
    public float[] Icons = new float[3];

    public float[] Way = new float[3];
    public int WaySpeed;
  }
}


