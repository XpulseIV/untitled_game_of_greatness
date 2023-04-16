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
    public GameObject tspelaren;
    private int _xPos, _yPos;
    public float maxRangeFromTspelaren;
    

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

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 distanceToTspelaren = mousePos - tspelaren.transform.position;

        if (distanceToTspelaren.magnitude >= maxRangeFromTspelaren)
        {
            SetCursorPos(_xPos, _yPos);
        }
    }
}
