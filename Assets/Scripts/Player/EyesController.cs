using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    private Transform parentTransform;

    private void Start()
    {
        parentTransform = transform.parent.transform;
    }

    private void LateUpdate()
    {
        transform.rotation = parentTransform.rotation;
    }
}
