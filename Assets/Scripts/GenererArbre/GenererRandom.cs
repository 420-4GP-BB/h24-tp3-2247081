using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererRandom : GenererArbre
{
    private List<Rect> listeAreaPris = new List<Rect>();

    public override void generationArbre(float boundsX, float boundsZ, GameObject arbre, Transform parentForet)
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 positionInstantiate = new Vector3(Random.Range(0, boundsX) , 0 , Random.Range(0, boundsZ));
            Rect nouveauArbre = new Rect(positionInstantiate.x, positionInstantiate.z, 3, 3);

            if (!checkOverlap(nouveauArbre))
            {
                GameObject.Instantiate(arbre, new Vector3(positionInstantiate.x, 0, positionInstantiate.z), Quaternion.Euler(0, Random.Range(0, 360), 0), parentForet);
                listeAreaPris.Add(nouveauArbre);
            }
        }
    }

    private bool checkOverlap(Rect nouveauArbre)
    {
        foreach (Rect areaPris in listeAreaPris)
        {
            if (nouveauArbre.Overlaps(areaPris))
            {
                return true;
            }
        }
        return false;
    }
}
