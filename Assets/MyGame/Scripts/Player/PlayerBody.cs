using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private ThirdPersonController _personController;

    private void Start()
    {
        _personController = GetComponentInParent<ThirdPersonController>();
    }

    public void SetNewBody(GameObject prefab)
    {
        if (prefab != null)
        {
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(prefab, transform);
            _personController.GetAnimator();
        }
    }
}
