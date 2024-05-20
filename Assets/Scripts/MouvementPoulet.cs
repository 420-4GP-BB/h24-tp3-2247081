using UnityEngine;
using UnityEngine.AI;

public class MouvementPoulet : MonoBehaviour
{
    private UnityEngine.GameObject _zoneRelachement;
    private float _angleDerriere;  // L'angle pour que le poulet soit derrière le joueur
    private UnityEngine.GameObject joueur;
    private bool _suivreJoueur = true;
    public bool oeufPoulet = false;

    private NavMeshAgent _agent;
    private Animator _animator;

    public GameObject[] _pointsDeDeplacement;

    void Start()
    {
        _zoneRelachement = UnityEngine.GameObject.Find("ZoneRelachePoulet");
        joueur = UnityEngine.GameObject.Find(ParametresParties.Instance.selectionPersonnage);
        _suivreJoueur = true;
        _angleDerriere = Random.Range(-60.0f, 60.0f);

        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _pointsDeDeplacement = GameObject.FindGameObjectsWithTag("PointsPoulet");
        _animator.SetBool("Walk", true);
        Initialiser();
    }

    void Initialiser()
    {
        // Position initiale sur la ferme
        _agent.enabled = false;
        if (_suivreJoueur && !oeufPoulet)
        {
            Vector3 directionAvecJoueur = Quaternion.AngleAxis(_angleDerriere, Vector3.up) * joueur.transform.forward;
            transform.position = joueur.transform.position - directionAvecJoueur;
            transform.rotation = joueur.transform.rotation;
        }
        _agent.enabled = true;
    }

    void ChoisirDestinationAleatoire()
    {
        if (_suivreJoueur)
        {
            _agent.SetDestination(joueur.transform.position - joueur.transform.forward);
        }
        else
        {
            GameObject point = _pointsDeDeplacement[Random.Range(0, _pointsDeDeplacement.Length)];
            _agent.SetDestination(point.transform.position);
        }
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            ChoisirDestinationAleatoire();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Relache"))
        {
            _suivreJoueur = false;
            _agent.speed = 0.25f;
            gameObject.GetComponent<PondreOeufs>().enabled = true;
        }

        if (other.CompareTag("Renard"))
        {
            Destroy(gameObject);
        }
    }
}