using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _animatedObject;
    public GameObject AnimatedObject { get => _animatedObject; set => _animatedObject = value; }
    public Animator _animator;
    private float _xScaleValue = 0;

    private void Awake()
    {
        _xScaleValue = _animatedObject.transform.parent.localScale.x;
        _animator = _animatedObject.GetComponent<Animator>();
    }
    public void FlipSprite(bool isOnRight)
    {
        if (isOnRight)
        {
            _animatedObject.transform.parent.localScale = new Vector3(_xScaleValue, _animatedObject.transform.parent.localScale.y, _animatedObject.transform.parent.localScale.z);
            return;
        }
        _animatedObject.transform.parent.localScale = new Vector3(-_xScaleValue, _animatedObject.transform.parent.localScale.y, _animatedObject.transform.parent.localScale.z);
    }
    public void TurnOnAnimationParameter(string animationName)
    {
        _animator.SetBool(animationName, true);
    }
    public void TurnOffAnimationParameter(string animationName)
    {
        _animator.SetBool(animationName, false);
    }
    public void TurnOnAnimationTriggerParameter(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }
    public void PlaySpecificAnimation(string animationName)
    {
        _animator.Play(animationName);
    }
    public void SetAnimationSpeed(float newSpeed)
    {
        _animator.speed = newSpeed;
    }
}



