using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arbre : MonoBehaviour, IAbattable
{
    [SerializeField] private GameObject logPrefab;
    private Transform player;
    private bool mustFall = false;

    private float rotationTotal = 0;
    private int DureeTombee = 2;
    private bool isRunning = false;

    public void Abattre(Inventaire inventaireJoueur)
    {
        player = GameObject.Find(ParametresParties.Instance.selectionPersonnage).GetComponent<Transform>();
        mustFall = true;
    }

    public EtatJoueur EtatAUtiliser(ComportementJoueur Sujet)
    {
        return new EtatAbattre(Sujet, this);
    }

    public bool Permis(ComportementJoueur sujet)
    {
        return true;
    }

    private void OnMouseDown()
    {
        if (mustFall)
        {
            mustFall = false;
        }
    }

    void Update()
    {
        if (rotationTotal < 90f && mustFall)
        {
            float vitesseTombee = 90.0f / DureeTombee;
            transform.Rotate(player.transform.right, Time.deltaTime * vitesseTombee, Space.World);
            rotationTotal += Mathf.Abs(vitesseTombee) * Time.deltaTime;
        }
        else if (rotationTotal >= 90f)
        {
            mustFall = false;
            if (!isRunning)
            {
                isRunning = true;
                StartCoroutine(affichageLog());
                isRunning = false;
            }
        }
    }

    IEnumerator affichageLog()
    {
        yield return new WaitForSeconds(1);
        Transform log = Instantiate(transform.GetChild(0), 
            new Vector3(transform.GetChild(0).position.x, 0.3f, transform.GetChild(0).position.z), 
            transform.GetChild(0).rotation);
        log.gameObject.AddComponent<Rigidbody>();
        Destroy(gameObject);
    }
}
