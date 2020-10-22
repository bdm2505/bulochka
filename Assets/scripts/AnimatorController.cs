using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMove(Vector2 vec)
    {
        _animator.Play(vec.x == 0 ? "Idle" : "Run");
    }
}