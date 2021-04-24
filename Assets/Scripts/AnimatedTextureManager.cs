using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTextureManager : MonoBehaviour
{

    public Texture[] texturesArr;
    Material _myMat;
    int currentTexId = 0;

    void Start()
    {
        _myMat = GetComponent<MeshRenderer>().sharedMaterial;
        StartCoroutine(AnimateTexture());
    }

    IEnumerator AnimateTexture()
    {
        while (true) {
            currentTexId++;
            if (currentTexId >= texturesArr.Length) currentTexId = 0;
            _myMat.SetTexture("_BaseMap", texturesArr[currentTexId]);
            yield return new WaitForSeconds(0.08f);
        }
    }
   
}
