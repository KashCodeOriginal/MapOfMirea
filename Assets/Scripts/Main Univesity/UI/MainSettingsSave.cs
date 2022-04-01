using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Pathfinding;

public class MainSettingsSave : MonoBehaviour
{ 
  UserData _userData = new UserData();
  private string _path;

  [SerializeField] private GameObject[] _gameObjects;

  [SerializeField] private GameObject[] _gameObjectForLoad;

  private void Awake()
  {
#if UNITY_ANDROID && !UNITY_EDITOR
    _path = System.IO.Path.Combine(Application.persistentDataPath, "MainUserData.json");
#else
    _path = System.IO.Path.Combine(Application.streamingAssetsPath, "MainUserData.json");
#endif
    
    if (File.Exists(_path))
    {
      _userData = JsonUtility.FromJson<UserData>(File.ReadAllText(_path));
    }
    Load();
  }
  public void Save()
  {
    _userData.FirstFloor[0] = _gameObjects[0].GetComponent<SpriteRenderer>().color.r;
    _userData.FirstFloor[1] = _gameObjects[0].GetComponent<SpriteRenderer>().color.g;
    _userData.FirstFloor[2] = _gameObjects[0].GetComponent<SpriteRenderer>().color.b;

    _userData.SecondFloor[0] = _gameObjects[1].GetComponent<SpriteRenderer>().color.r;
    _userData.SecondFloor[1] = _gameObjects[1].GetComponent<SpriteRenderer>().color.g;
    _userData.SecondFloor[2] = _gameObjects[1].GetComponent<SpriteRenderer>().color.b;

    _userData.ThirdFloor[0] = _gameObjects[2].GetComponent<SpriteRenderer>().color.r;
    _userData.ThirdFloor[1] = _gameObjects[2].GetComponent<SpriteRenderer>().color.g;
    _userData.ThirdFloor[2] = _gameObjects[2].GetComponent<SpriteRenderer>().color.b;

    _userData.FourthFloor[0] = _gameObjects[3].GetComponent<SpriteRenderer>().color.r;
    _userData.FourthFloor[1] = _gameObjects[3].GetComponent<SpriteRenderer>().color.g;
    _userData.FourthFloor[2] = _gameObjects[3].GetComponent<SpriteRenderer>().color.b;

    _userData.SecondFloorBG[0] = _gameObjects[4].GetComponent<SpriteRenderer>().color.r;
    _userData.SecondFloorBG[1] = _gameObjects[4].GetComponent<SpriteRenderer>().color.g;
    _userData.SecondFloorBG[2] = _gameObjects[4].GetComponent<SpriteRenderer>().color.b;

    _userData.ThirdFloorBG[0] = _gameObjects[5].GetComponent<SpriteRenderer>().color.r;
    _userData.ThirdFloorBG[1] = _gameObjects[5].GetComponent<SpriteRenderer>().color.g;
    _userData.ThirdFloorBG[2] = _gameObjects[5].GetComponent<SpriteRenderer>().color.b;

    _userData.FourthFloorBG[0] = _gameObjects[6].GetComponent<SpriteRenderer>().color.r;
    _userData.FourthFloorBG[1] = _gameObjects[6].GetComponent<SpriteRenderer>().color.g;
    _userData.FourthFloorBG[2] = _gameObjects[6].GetComponent<SpriteRenderer>().color.b;

    _userData.Walls[0] = _gameObjects[7].GetComponent<Image>().color.r;
    _userData.Walls[1] = _gameObjects[7].GetComponent<Image>().color.g;
    _userData.Walls[2] = _gameObjects[7].GetComponent<Image>().color.b;
    
    _userData.BackGround[0] = _gameObjects[8].GetComponent<Camera>().backgroundColor.r;
    _userData.BackGround[1] = _gameObjects[8].GetComponent<Camera>().backgroundColor.g;
    _userData.BackGround[2] = _gameObjects[8].GetComponent<Camera>().backgroundColor.b;
    
    _userData.Text[0] = _gameObjects[9].GetComponent<TextMeshProUGUI>().color.r;
    _userData.Text[1] = _gameObjects[9].GetComponent<TextMeshProUGUI>().color.g;
    _userData.Text[2] = _gameObjects[9].GetComponent<TextMeshProUGUI>().color.b;
    
    /*
    _userData.WaySpeed = Convert.ToInt16(_gameObjects[6].GetComponent<AILerp>().speed);
    */

    string jsonString = JsonUtility.ToJson(_userData);
    File.WriteAllText(_path, jsonString);
  }
  public void Load()
  {
    if (File.Exists(_path))
    {
      string _userData = File.ReadAllText(_path);
      UserData _data = JsonUtility.FromJson<UserData>(_userData);

      _gameObjectForLoad[0].GetComponent<MainCamColorChanging>().OnFirstFloorLoad(_data.FirstFloor[0],_data.FirstFloor[1],_data.FirstFloor[2],0);
      _gameObjectForLoad[0].GetComponent<MainCamColorChanging>().OnSecondFloorLoad(_data.SecondFloor[0],_data.SecondFloor[1],_data.SecondFloor[2],1);
      _gameObjectForLoad[0].GetComponent<MainCamColorChanging>().OnThirdFloorLoad(_data.ThirdFloor[0],_data.ThirdFloor[1],_data.ThirdFloor[2],0);
      _gameObjectForLoad[0].GetComponent<MainCamColorChanging>().OnFourthFloorLoad(_data.FourthFloor[0],_data.FourthFloor[1],_data.FourthFloor[2],0);
      
      _gameObjectForLoad[0].GetComponent<MainCamColorChanging>().OnWallsLoad(_data.Walls[0],_data.Walls[1],_data.Walls[2]);
      
      _gameObjectForLoad[1].GetComponent<MainCamColorChanging>().OnSecondFloorBGLoad(_data.SecondFloorBG[0],_data.SecondFloorBG[1],_data.SecondFloorBG[2],1);
      _gameObjectForLoad[1].GetComponent<MainCamColorChanging>().OnThirdFloorBGLoad(_data.ThirdFloorBG[0],_data.ThirdFloorBG[1],_data.ThirdFloorBG[2],0);
      _gameObjectForLoad[1].GetComponent<MainCamColorChanging>().OnFourthFloorBGLoad(_data.FourthFloorBG[0],_data.FourthFloorBG[1],_data.FourthFloorBG[2],0);
      
      _gameObjectForLoad[1].GetComponent<MainCamColorChanging>().OnBackGroundLoad(_data.BackGround[0],_data.BackGround[1],_data.BackGround[2]);
      
      _gameObjectForLoad[2].GetComponent<MainTextColorControll>().OnTextLoad(_data.Text[0],_data.Text[1],_data.Text[2]);
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
    public float[] FirstFloor = new float[4];
    public float[] SecondFloor = new float[4];
    public float[] ThirdFloor = new float[4];
    public float[] FourthFloor = new float[4];
    
    public float[] SecondFloorBG = new float[4];
    public float[] ThirdFloorBG = new float[4];
    public float[] FourthFloorBG = new float[4];

    public float[] Walls = new float[3];
    
    public float[] BackGround = new float[3];
    public float[] Text = new float[3];

    public float[] Menu = new float[3];
    public float[] Icons = new float[3];

    public float[] Way = new float[3];
    public int WaySpeed;
  }
}
