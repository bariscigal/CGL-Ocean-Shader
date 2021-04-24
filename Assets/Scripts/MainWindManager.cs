using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindManager : MonoBehaviour
{
    public static MainWindManager instance;


    Transform _myTrns;
    public float windSwayPower = 0.3f;
    public float windSwaySpeed = 0.5f;

    void Start()
    {
        _myTrns = transform;
        if(MainWindManager.instance == null) {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        float windVal = Mathf.Sin(Time.time) * windSwaySpeed;
        _myTrns.transform.Rotate(Vector3.up, windVal, Space.World);
    }
}
