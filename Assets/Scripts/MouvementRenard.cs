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
    private float pouletClosest;

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
        if (pouleFerme != null)
        {
            foreach (GameObject poule in pouleFerme)
            {
                RaycastHit hit;
                Vector3 directionPoulet = poule.transform.position - transform.position;

                // Regarde s'il y a un obstacle entre le renard et la poule
                if (Physics.Raycast(transform.position, directionPoulet, out hit))
                {
                    if (hit.transform.CompareTag("Poule") && hit.distance < 5)
                    {
                        pouleTarget = poule;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    void Update()
    {
        if (PouletVisible())
        {
            _agent.SetDestination(pouleTarget.transform.position);
        }
        else if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            ChoisirDestinationAleatoire();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poule"))
        {
            _agent.SetDestination(pouleTarget.transform.position);
        }
    }
}