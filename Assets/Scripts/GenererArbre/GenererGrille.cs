using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GenererGrille : GenererArbre
{
    public override void generationArbre(float boundsX, float boundsZ, GameObject arbre, Transform parentForet)
    {
        //Génération des arbres par grille avec une distance de 5 unités
        for (int i = 0; i  < boundsX; i++)
        {
            for(int j = 0; j < boundsZ; j++)
            {
                if (j % 5 == 0 && i % 5 == 0)
                {
                    GameObject.Instantiate(arbre, new Vector3(i, 0, j), Quaternion.identity, parentForet);
                }
            }
        }
    }
}
