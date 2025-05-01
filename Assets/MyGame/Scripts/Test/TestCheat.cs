using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheat : MonoBehaviour
{
    private Vector3 _checkpoint;
    private CharacterController _cc;

    private void Start()
    {
        _checkpoint = transform.position;
        _cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H)) // set checkpoint
        {
            _checkpoint = transform.position;
        }
        if (Input.GetKey(KeyCode.G)) // teleport to checkpoint
        {
            _cc.enabled = false;
            transform.position = _checkpoint;
            _cc.enabled = true;
        }
    }
}
