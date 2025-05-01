using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    public Animator Animator
    {
        get
        {
            if (_animator == null)
                GetAnimatorComponent();

            return _animator;
        }
    }

    private void Start()
    {
        GetAnimatorComponent();
    }

    private void GetAnimatorComponent() => _animator = GetComponentInChildren<Animator>();
}
