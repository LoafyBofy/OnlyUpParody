using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _lavaSpeed = 1f;
    private float _offset = 0f;

    private void Update()
    {
        _offset += Time.deltaTime;

        if (_material != null)
            _material.mainTextureOffset = new Vector2(_offset * _lavaSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonController player))
        {
            var startPoint = GameObject.FindWithTag("Respawn");
            player.TeleportTo(startPoint.transform.position);
        }
    }
}
