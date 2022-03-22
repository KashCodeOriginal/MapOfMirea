using UnityEngine;

public class WayDetailsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _backGround;
    private void OnAnimationPlay()
    {
        _backGround.SetActive(true);
        gameObject.GetComponent<Animation>().Play("WayDetailsMenuDown");
    }

    private void OnAnimationStop()
    {
        gameObject.GetComponent<Animation>().Play("WayDetailsMenuUp");
    }

    public void AnimationStateControl()
    {
        if(_backGround.activeSelf)
        {
            OnAnimationStop();
        }
        else
        {
            OnAnimationPlay();
        }
    }
}
