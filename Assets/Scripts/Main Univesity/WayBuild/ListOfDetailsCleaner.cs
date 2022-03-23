using UnityEngine;

public class ListOfDetailsCleaner : MonoBehaviour
{
    [SerializeField] private Transform _list;

    public void CleanAllButtons()
    {
        foreach (Transform child in _list)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}