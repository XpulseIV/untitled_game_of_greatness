using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSelf : MonoBehaviour
{
    private GameObject _activatedObject;
    [SerializeField] private string _objectTag;
    [SerializeField] private float _activasionRange;
    public bool isActivated = false;
    private Vector2 _activasionDistance;



    void Start()
    {
        
    }

    
    void Update()
    {
        _activatedObject = GameObject.FindGameObjectWithTag(_objectTag);
        if (_activatedObject != null)
        {
            _activasionDistance = this.transform.position - _activatedObject.transform.position;
            if (_activasionDistance.magnitude <= _activasionRange)
            {
                isActivated = true;
            }
        }
        else
        {
            isActivated = false;
        }        
    }
}
