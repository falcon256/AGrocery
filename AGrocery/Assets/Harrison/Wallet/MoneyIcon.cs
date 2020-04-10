using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyIcon : MonoBehaviour
{
    public float dollarAmount;
    public Transform playerCamera;

    private void FixedUpdate()
    {
        LookAtCamera();
    }

    public float GetDollar()
    {
        return dollarAmount;
    }

    private void LookAtCamera()
    {
        this.transform.LookAt(playerCamera);
    }
}
