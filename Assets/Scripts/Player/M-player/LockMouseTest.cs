using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.InteropServices;

public class LockMouseTest : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    [SerializeField] private GameObject _setCursorTest;
    private int _xPos, _yPos;
    

    private void Start()
    {
        _xPos = Screen.width / 2;
        _yPos = Screen.height / 2;
    }

    private void Update()
    {
        if (Input.GetKey("1"))
        {
            Cursor.visible = true;
            _setCursorTest.SetActive(false);
        }

        if(Input.mousePosition.x < _xPos / 2)
        {
            SetCursorPos(_xPos, _yPos);
        }
    }
}
