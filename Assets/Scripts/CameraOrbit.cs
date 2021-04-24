using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    Transform _myTrns;

    void Start()
    {
        _myTrns = transform;

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mouseMovement = new Vector3(0f, Input.GetAxis("Mouse X") * 5f,0f);
            _myTrns.Rotate(mouseMovement);
        }
    }
}