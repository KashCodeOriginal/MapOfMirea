using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
  public void SceneChanger(int sceneNumber)
  {
    SceneManager.LoadScene(sceneNumber);
  }
}
