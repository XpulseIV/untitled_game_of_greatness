using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStats : MonoBehaviour
{
    public float damageTickSpeed;
    public float damageOverTime;
    public float burstSpeed;
    public float burstDamage;

    private Animator _animator;
    private ActivateSelf _activateSelf;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _activateSelf = GetComponent<ActivateSelf>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_activateSelf.isActivated)
        {
            _animator.SetBool("IsOn", true);

            if (Input.GetKey("space"))
            {
                _animator.SetBool("IsInBurst", true);
                _animator.SetBool("IsInBurst", false);
            }
        }
        else
        {
            _animator.SetBool("IsOn", false);
        }
    }
}
