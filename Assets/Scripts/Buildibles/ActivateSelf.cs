using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSelf : MonoBehaviour
{
    [SerializeField] private Transform _activatedObject;
    [SerializeField] private string _objectTag;
    [SerializeField] private float _activasionRange;
    public bool isActivated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //_activatedObject = GameObject.FindGameObjectWithTag(_objectTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        _activatedObject = GameObject.FindGameObjectWithTag(_objectTag).transform;
        Vector2 activasionDistance = this.transform.position - _activatedObject.position;

        if (activasionDistance.magnitude <= _activasionRange)
        {
            isActivated = true;
        }
        else
        {
            isActivated = false;
        }
    }
}
