using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowImage : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        GameEvents.OnPlayerEnter += Flash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Flash(bool isActive)
    {
        _animator.SetBool(AnimatorValues.PlayerInside, isActive);
    }
}
