using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererRandom : GenererArbre
{
    public override void generationArbre(float boundsX, float boundsZ, GameObject arbre, Transform parentForet)
    {
        for (int i = 0; i < 500; i++)
        {
            GameObject.Instantiate(arbre, new Vector3(Random.Range(0, boundsX), 0, Random.Range(0, boundsZ)), Quaternion.identity, parentForet);
        }
    }
}
