using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    protected int pointSpeed;
    protected int factoryCount;

    private float timer;

    private void Start()
    {
        timer = 0;
    }


    protected virtual void Update()
    {
        // ABSTRACTION
        ManufacturePoints();        
    }

    private void ManufacturePoints()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            int pointAmount = pointSpeed * factoryCount;
            GameManager.Instance.AddPoints(pointAmount);
        }
    }
}
