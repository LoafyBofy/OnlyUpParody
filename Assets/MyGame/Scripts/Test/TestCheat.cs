using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheat : MonoBehaviour
{
    private Vector3 _checkpoint;
    private CharacterController _cc;
    private BurgerCollector _burgerCollector;

    private void Start()
    {
        _checkpoint = transform.position;
        _cc = GetComponent<CharacterController>();
        _burgerCollector = GetComponent<BurgerCollector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // set checkpoint
        {
            _checkpoint = transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.G)) // teleport to checkpoint
        {
            _cc.enabled = false;
            transform.position = _checkpoint;
            _cc.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _burgerCollector.IncreaseBurgers(100);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            _burgerCollector.DecreaseBurgers(100);
        }
    }
}
