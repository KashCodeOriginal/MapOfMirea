using UnityEngine;

public class WayDetailsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _start;
    private void OnAnimationPlay()
    {
        if (_start.transform.position.x != -9 && _start.transform.position.y != -40)
        {
            _backGround.SetActive(true);
            gameObject.GetComponent<Animation>().Play("WayDetailsMenuDown");
        }
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
