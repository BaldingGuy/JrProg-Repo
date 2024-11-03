using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : FactoryBase
{
    private float stretchTarget;
    public float GetStretchTarget() {  return stretchTarget; }

    private void Awake()
    {
        pointSpeed = 4;
        factoryCost = 25;
    }

    protected override void UpdateManipulateVars(int factor)
    {
        if (factor == 0) return;

        if (factor > 0) manipulator.SetXTarget((float)factor + 1f);
    }

}
