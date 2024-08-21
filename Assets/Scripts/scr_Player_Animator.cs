using UnityEngine;

public class scr_Player_Animator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetIsForward(bool isMovingForward)
    {
        // Set the "IsForward" parameter in the animator
        _animator.SetBool("IsForward", isMovingForward);
    }

    public void SetIsBackward(bool isMovingBackward)
    {
        // Set the "IsBackward" parameter in the animator
        _animator.SetBool("IsBackward", isMovingBackward);
    }
}
