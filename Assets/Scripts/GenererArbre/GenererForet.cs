using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererForet : MonoBehaviour
{
    [SerializeField] private GameObject prefabArbre;
    private GenererArbre creerArbre;

    void Start()
    {
        // Generate trees based on selected algorithm
        Vector3 center = transform.position;
        Vector3 size = transform.localScale;
        //creerArbre.generationArbre(center, size, prefabArbre);
    }
}
