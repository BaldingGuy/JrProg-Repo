using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeezer : FactoryBase
{
    private float squeezeTarget;
    public float GetSqueezeTarget() {  return squeezeTarget; }


    private void Awake()
    {
        pointSpeed = 2;
        factoryCost = 10;
    }

    protected override void UpdateManipulateVars(int factor)
    {
        if (factor == 0) return;

        if (factor > 0) manipulator.SetYTarget(1 / ((float)factor + 1f));
    }
}
