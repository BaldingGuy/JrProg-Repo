using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    private float yTarget = 1f;
    private float xTarget = 1f;
    private Vector3 target;
    private float timer;
    private bool squeeze = true;

    // ENCAPSULATION
    public void SetYTarget(float value) { yTarget = value; }
    public void SetXTarget(float value) {  xTarget = value; }


    private void Start()
    {
        target = Vector3.one;
        timer = 0; 
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            target = new(xTarget, yTarget, 1);
            StartCoroutine(ManipulateAndReturn());
        }
    }


    IEnumerator ManipulateAndReturn()
    {
        if (squeeze)
        {
            // Manipulate
            yield return StartCoroutine(ScaleTo(target));
            squeeze = false;
        }
        else
        {
            // Return
            yield return StartCoroutine(ScaleTo(Vector3.one));
            squeeze = true;
        }
    }

    IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float time = 0;

        while (time < 1f)
        {
            transform.localScale = Vector3.Lerp(
                startScale,
                targetScale,
                time / 0.5f
                );
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

}
