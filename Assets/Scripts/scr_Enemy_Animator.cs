using UnityEngine;

public class scr_Enemy_Animator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetIsForward(bool isMovingForward)
    {
        _animator.SetBool("IsForward", isMovingForward);
    }

    public void SetIsBackward(bool isMovingBackward)
    {
        _animator.SetBool("IsBackward", isMovingBackward);
    }
    public void SetPunch(bool isPunch)
    {
        _animator.SetBool("IsPunch", isPunch);
    }
}


