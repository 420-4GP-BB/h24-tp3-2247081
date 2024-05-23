using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCollation : MonoBehaviour
{
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private GameObject[] tableCollation;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        //Créer la collation au début du jeu
        createCollation();
    }

    // Update is called once per frame
    void Update()
    {
        //Condition permettant de voir si il y a déjà un collation
        if (spawnPlace.transform.childCount <= 0 && !isRunning)
        {
            isRunning = true;
            StartCoroutine(compterSecondes());
        }
    }

    void createCollation()
    {
        //Création de la collation
        Instantiate(tableCollation[Random.Range(0,3)], transform.position, Quaternion.identity, spawnPlace);
        isRunning = false;
    }

    IEnumerator compterSecondes()
    {
        //Compte à rebours
        yield return new WaitForSecondsRealtime(30);
        createCollation();
    }
}
