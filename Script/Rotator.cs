using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    
    [Header("旋转速度")]
    public float minRotationSpeed;
    public float maxRotationSpeed;
    public bool On;

    public void Update()
    {
        if (On)
        {
            float RotationSpeed;
            RotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
            float rotation = Time.deltaTime * RotationSpeed;
            this.gameObject.transform.Rotate(new Vector3(0, 0, rotation));
            
        }
        
    }
}
