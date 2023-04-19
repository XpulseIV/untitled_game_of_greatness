using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour

{
    private AreaEffector2D _areaEffector2D;
    private ActivateSelf _activateSelf;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _areaEffector2D = GetComponent<AreaEffector2D>();
        _activateSelf = GetComponent<ActivateSelf>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_activateSelf.isActivated)
        {
            _areaEffector2D.enabled = true;
            _animator.SetBool("IsOn", true);
        }
        else
        {
            _areaEffector2D.enabled = false;
            _animator.SetBool("IsOn", false);
        }
    }
}
