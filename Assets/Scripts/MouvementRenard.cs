using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementRenard : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GameObject[] _pointsDeDeplacement;
    private GameObject[] pouleFerme;
    private GameObject pouleTarget;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _pointsDeDeplacement = GameObject.FindGameObjectsWithTag("PointsRenard");
        Initialiser();
    }

    void Initialiser()
    {
        // Position initiale sur la ferme
        transform.position = _pointsDeDeplacement[Random.Range(0, _pointsDeDeplacement.Length)].transform.position;
    }

    void ChoisirDestinationAleatoire()
    {
        GameObject point = _pointsDeDeplacement[Random.Range(0, _pointsDeDeplacement.Length)];
        _agent.SetDestination(point.transform.position);
    }

    bool PouletVisible()
    {
        pouleFerme = GameObject.FindGameObjectsWithTag("Poule");
        float closestDistance = Mathf.Infinity;
        GameObject pouletProche = null;

        foreach (GameObject poule in pouleFerme)
        {
            float distance = Vector3.Distance(transform.position, poule.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                pouletProche = poule;
            }
        }
        //Condition qui regarde quel poule est la plus proche
        if (pouletProche != null && closestDistance < 5)
        {
            pouleTarget = pouletProche;
            return true;
        }

        return false;
    }

    void Update()
    {
        if (PouletVisible()) //Regarde si la poule est visible
        {
            _agent.SetDestination(pouleTarget.transform.position);
        }
        else if (!_agent.pathPending && _agent.remainingDistance < 0.5f && !PouletVisible())
        {
            //Sinon, continue sa patrouille
            ChoisirDestinationAleatoire();
        }
    }
}