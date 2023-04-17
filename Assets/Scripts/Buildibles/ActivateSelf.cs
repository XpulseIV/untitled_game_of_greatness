using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSelf : MonoBehaviour
{
    private GameObject _activatedObject;
    [SerializeField] private string _objectTag;
    [SerializeField] private float _activasionRange;
    [SerializeField] private string _normalTag;
    public bool isActivated = false;
    private Vector2 _activasionDistance;
    public GameObject mspelaren;
    private CustomCursor _customCursor;



    void Start()
    {
        _customCursor = mspelaren.GetComponent<CustomCursor>();
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

        if (_customCursor.inUtility == true && Input.GetKey(KeyCode.E))
        {
            this.gameObject.tag = _normalTag;
            Invoke("DeactivateInUtilty", 0.1f);
        }
    }

    private void DeactivateInUtilty()
    {
        _customCursor.inUtility = false;
    }
}