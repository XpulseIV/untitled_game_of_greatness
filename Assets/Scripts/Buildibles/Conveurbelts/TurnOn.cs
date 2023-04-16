using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    private AreaEffector2D _areaEffector2D;
    private ActivateSelf _activateSelf;
    
    // Start is called before the first frame update
    void Start()
    {
        _areaEffector2D = GetComponent<AreaEffector2D>();
        _activateSelf = GetComponent<ActivateSelf>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_activateSelf.isActivated)
        {
            _areaEffector2D.enabled = true;
        }
        else
        {
            _areaEffector2D.enabled = false;
        }
    }
}
