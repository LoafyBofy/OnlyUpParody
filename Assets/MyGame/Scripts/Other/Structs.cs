using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AnimalItem
{
    public Animals name;
    public GameObject prefab;
    public RenderTexture renderTexture;
    public bool isUnlocked;
}