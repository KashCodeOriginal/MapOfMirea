using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WayDetailsController : MonoBehaviour
{
    [SerializeField] private Transform _list;
    [SerializeField] private GameObject _itemPrefab;
    
    public void AddPointToWayDetails(string _wayDetailText)
    {
        GameObject item = Instantiate(_itemPrefab,new Vector3(0,0,0),Quaternion.identity);
        item.transform.SetParent(_list, false);
        item.GetComponentInChildren<TextMeshProUGUI>().text = _wayDetailText;
    }
}
