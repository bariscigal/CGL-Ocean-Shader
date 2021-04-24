using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWindManager : MonoBehaviour
{
    public Transform[] boneArray;//must place from root to tip in order

    Quaternion[] startAngleArr;

    float windVal;
    public float treeMass = 1;
    public bool isRandomMovAdd = false;
    public float randomMovementVal = 1;
    void Start()
    {
        startAngleArr = new Quaternion[boneArray.Length];
        for (int i = 0; i < boneArray.Length; i++)
        {
            //dud for now
            startAngleArr[i] = boneArray[i].rotation;
        }

       if(isRandomMovAdd) randomMovementVal = Random.Range(-randomMovementVal, randomMovementVal);
    }


    void Update()
    {
        for (int i = 0; i < boneArray.Length; i++) {
            windVal = Mathf.Sin(Time.time) * 0.045f * treeMass * randomMovementVal;
            boneArray[i].transform.Rotate(MainWindManager.instance.transform.right, windVal ,Space.World);
        }
    }

}
