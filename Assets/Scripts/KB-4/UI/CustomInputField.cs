using UnityEngine;
using TMPro;

public class CustomInputField : MonoBehaviour
{

  [HideInInspector] public TMP_InputField inputText;
  [HideInInspector] public Animator inputFieldAnimator;

  private string inAnim = "In";
  private string outAnim = "Out";

  void Start()
  {
        inputText = gameObject.GetComponent<TMP_InputField>();

    if (inputFieldAnimator == null)
        inputFieldAnimator = gameObject.GetComponent<Animator>();

    inputText.onSelect.AddListener(delegate { AnimateIn(); });
    inputText.onEndEdit.AddListener(delegate { AnimateOut(); });
    UpdateState();
  }

  void OnEnable()
  {
    if (inputText == null)
        return;

    inputText.ForceLabelUpdate();
    UpdateState();
  }

  public void AnimateIn()
  {
    inputFieldAnimator.Play(inAnim);
  }

  public void AnimateOut()
  {
    if (inputText.text.Length == 0)
        inputFieldAnimator.Play(outAnim);
  }

  public void UpdateState()
  {
    if (inputText.text.Length == 0)
        AnimateOut();
    else
        AnimateIn();
  }
}