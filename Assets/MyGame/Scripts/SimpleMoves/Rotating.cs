using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float _rotatingSpeed;

    private void Update()
    {
        transform.Rotate(0, _rotatingSpeed * Time.deltaTime, 0);
    }
}
