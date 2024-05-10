using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererForet : MonoBehaviour
{
    [SerializeField] private GameObject prefabArbre;
    private GenererArbre creerArbre;
    private Transform parentForet;
    private Mesh planeMesh;
    private Bounds bounds;

    void Start()
    {
        parentForet = GameObject.Find("===== Foret =====").transform;
        planeMesh = GetComponent<MeshFilter>().mesh;
        bounds = planeMesh.bounds;

        float boundsX = transform.localScale.x * bounds.size.x;
        float boundsZ = transform.localScale.z * bounds.size.z;

        switch (ParametresParties.Instance.selectionArbre)
        {
            case "Grille":
                creerArbre = new GenererGrille();
                break;
            case "Random":
                creerArbre = new GenererRandom();
                break;
            case "Simulation":
                creerArbre = new GenererSimulation();
                break;
        }

        creerArbre.generationArbre(boundsX, boundsZ, prefabArbre, parentForet);
    }
}
