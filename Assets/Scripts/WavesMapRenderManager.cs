using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesMapRenderManager : MonoBehaviour
{
    Camera _myCam;
    public Renderer sandMesh;
    public Renderer oceanMesh;
    float wetnessFadeVal = 0f;
    float startDelay = 1.55f;

    IEnumerator Start()
    {
        _myCam = GetComponent<Camera>();
        _myCam.enabled = false;
        StartCoroutine(TakeSnapshot());
        oceanMesh.enabled  = false;
        yield return new WaitForEndOfFrame();
        oceanMesh.enabled = true;
    }

  

    IEnumerator TakeSnapshot()
    {
        wetnessFadeVal = 0;
        sandMesh.sharedMaterial.SetFloat("_fadeVal", wetnessFadeVal);
        yield return new WaitForSeconds(startDelay);
        while (true) {

            _myCam.Render();
            Debug.Log("captured");
            yield return StartCoroutine(FadeWetness(true));
            StartCoroutine(FadeWetness(false));
            yield return new WaitForSeconds(startDelay * 2);
        }
    }

    IEnumerator FadeWetness(bool fadeIn) {

        if (fadeIn)
        {
            while(wetnessFadeVal < 1) { 
                wetnessFadeVal +=  Time.deltaTime * 3;
                sandMesh.sharedMaterial.SetFloat("_fadeVal", wetnessFadeVal);
                yield return null;
            }
            yield break;
        }
        else { //fading out
            while (wetnessFadeVal > 0)
            {
                wetnessFadeVal -= Time.deltaTime;
                sandMesh.sharedMaterial.SetFloat("_fadeVal", wetnessFadeVal);
                yield return null;
            }
            yield break;
        }
    }
}
