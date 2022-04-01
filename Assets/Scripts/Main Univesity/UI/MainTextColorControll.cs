using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainTextColorControll : MonoBehaviour
{
    [SerializeField] private List<GameObject> _modelTextList;
    [SerializeField] private List<GameObject> _modelTextWaytList;

    [SerializeField] private MainCamControll _camera;
    public void OnTextClick()
    {
        foreach (var text in _camera._textList)
        {
            try
            {
                text.GetComponentInChildren<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
            }
            catch
            {
                text.GetComponentInChildren<SpriteRenderer>().color = gameObject.GetComponent<Image>().color;
            }

        }
        foreach (var modelText in _modelTextList)
        {
            modelText.GetComponent<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
        }
        foreach (var modelWayText in _modelTextWaytList)
        {
            modelWayText.GetComponent<TextMeshProUGUI>().color = gameObject.GetComponent<Image>().color;
        }
    }
    public void OnTextLoad(float r, float g, float b)
    {
        foreach (var modelText in _modelTextList)
        {
            modelText.GetComponent<TextMeshProUGUI>().color = new Color(r, g, b);
        }
        foreach (var modelWayText in _modelTextList)
        {
            modelWayText.GetComponent<TextMeshProUGUI>().color = new Color(r, g, b);
        }
        foreach (var text in _camera._textList)
        {
            try
            {
                text.GetComponentInChildren<TextMeshProUGUI>().color = new Color(r, g, b);
            }
            catch
            {
                text.GetComponentInChildren<SpriteRenderer>().color = new Color(r, g, b);
            }

        }
    }
}
