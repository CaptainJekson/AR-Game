using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public bool IsActice => _meshRenderer.enabled;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
