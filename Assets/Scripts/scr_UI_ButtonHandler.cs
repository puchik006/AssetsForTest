using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class scr_UI_ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private scr_Player_Animator _animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.SetPunch(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _animator.SetPunch(false);
    }
}
