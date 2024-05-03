using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementRenard : MonoBehaviour
{
    private UnityEngine.GameObject _zoneRelachement;
    private float _angleDerriere;  // L'angle pour que le poulet soit derrière le joueur
    private UnityEngine.GameObject joueur;
    private bool _suivreJoueur = true;

    private NavMeshAgent _agent;
    private Animator _animator;

    private GameObject[] _pointsDeDeplacement;

    void Start()
    {
        _animator = GetComponent<Animator>();
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

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            ChoisirDestinationAleatoire();
        }
    }
}