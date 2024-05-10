using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererSimulation : GenererArbre
{
    private bool[,] arbreGrid;
    public override void generationArbre(float boundsX, float boundsZ, GameObject arbre, Transform parentForet)
    {
        InitialiserGrid(boundsX, boundsZ);
        genererArbreGrid();
    }

    void InitialiserGrid(float boundsX, float boundsZ)
    {
        for(int x = 0;x < boundsX; x++)
        {
            for(int z = 0;z < boundsZ; z++)
            {
                arbreGrid[x, z] = Random.value < 0.7;
            }
        }
    }

    void genererArbreGrid()
    {
        for (int generation = 0; generation < 10; generation++)
        {

        }
    }
}
