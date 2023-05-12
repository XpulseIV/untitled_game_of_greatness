using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NonScetchyMouseLock : MonoBehaviour
{

    [SerializeField] private float _lockRange;
    [SerializeField] private GameObject _deActivateThis;
    private GameObject _tPlayer;
    private Vector2 _mouseDistance;

    // Start is called before the first frame update
    void Start()
    {
        _tPlayer = GameObject.Find("T-spelaren");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        if (Input.GetKey(KeyCode.P))
        {   
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _deActivateThis.SetActive(false);
        }

        _mouseDistance = this.transform.position - _tPlayer.transform.position;
        if(_mouseDistance.magnitude >= _lockRange)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
