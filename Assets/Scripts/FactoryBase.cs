using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.IO.LowLevel.Unsafe;

public abstract class FactoryBase : MonoBehaviour
{
    [SerializeField] protected int pointSpeed;
    [SerializeField] protected int factoryCost;
    [SerializeField] private TextMeshPro factoryCountDisplay;
    [SerializeField] protected Transform ball;
    protected Manipulator manipulator;

    private int factoryCount;
    private float timer;

    private void Start()
    {
        manipulator = ball.GetComponent<Manipulator>();

        timer = 0;
        factoryCount = 0;
        UpdateFactoryCountDisplay();
    }


    protected virtual void Update()
    {
        // ABSTRACTION
        ManufacturePoints();        
    }

    // ABSTRACTION
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

    // POLYMORPHISM
    abstract protected void UpdateManipulateVars(int factor);

    // ABSTRACTION
    public void BuildFactory()
    {
        int currentPoints = GameManager.Instance.GetScore();
        if (currentPoints >= factoryCost)
        {
            GameManager.Instance.DeductPoints(factoryCost);
            factoryCount += 1;
            UpdateFactoryCountDisplay();
            UpdateManipulateVars(factoryCount);
        }
    }

    // ABSTRACTION
    private void UpdateFactoryCountDisplay()
    {
        factoryCountDisplay.text = factoryCount.ToString();
    }




}
