using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererSimulation : GenererArbre
{
    private List<Rect> listeAreaPris = new List<Rect>();
    //Aide avec ChatGPT
    private readonly (int, int)[] directions = {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1),         (0, 1),
        (1, -1), (1, 0), (1, 1)
    };

    public override void generationArbre(float boundsX, float boundsZ, GameObject arbre, Transform parentForet)
    {
        int gridSize = 128;
        bool[,] arbreGrid = new bool[gridSize, gridSize];

        // Initialiser les arbres sur un grid
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                arbreGrid[x, z] = Random.value < 0.7f; //Une chance de 70% d'être présent
            }
        }

        // Faire rouler 10 génération (Aide avec ChatGPT)
        for (int generation = 0; generation < 10; generation++)
        {
            bool[,] nextGeneration = new bool[gridSize, gridSize];

            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    int neighbors = CountNeighbors(arbreGrid, x, z);

                    if (arbreGrid[x, z])
                    {
                        nextGeneration[x, z] = neighbors == 3 || neighbors == 4 || neighbors == 6 || neighbors == 7 || neighbors == 8;
                    }
                    else
                    {
                        nextGeneration[x, z] = neighbors == 3 || neighbors == 6 || neighbors == 7 || neighbors == 8;
                    }
                }
            }

            arbreGrid = nextGeneration;
        }

        // Créer les arbres après les 10 générations
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                if (arbreGrid[x, z])
                {
                    Rect nouveauArbre = new Rect(x, z, 1.5f, 1.5f);

                    if (!checkOverlap(nouveauArbre))
                    {
                        GameObject.Instantiate(arbre,
                            new Vector3(x + Random.Range(-1.25f, 1.25f), 0, z + Random.Range(-1.25f, 1.25f)),
                            Quaternion.Euler(0, Random.Range(0, 360), 0),
                            parentForet);
                        listeAreaPris.Add(nouveauArbre);
                    }
                }
            }
        }
    }

    //Regarde si les arbres overlaps sur les autres
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
    
    //Compter les voisins d'arbre autour de l'arbre (Aide avec ChatGPT)
    private int CountNeighbors(bool[,] grid, int x, int z)
    {
        int count = 0;
        foreach (var (dx, dz) in directions)
        {
            int newX = x + dx;
            int newZ = z + dz;
            if (newX > 0 && newX < grid.GetLength(0) && newZ > 0 && newZ < grid.GetLength(1) && grid[newX, newZ])
            {
                count++;
            }
        }
        Debug.Log(count);
        return count;
    }
}
