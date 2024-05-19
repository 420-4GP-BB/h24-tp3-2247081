using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OeufEclore : MonoBehaviour
{
    [SerializeField] private GameObject prefabPoulet;
    private Soleil _soleil;
    private int journeesDeVie = 0;
    private float _tempsCroissance;

    public bool Eclore
    {
        get => journeesDeVie >= ParametresParties.Instance.TempsCroissance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _soleil = FindObjectOfType<Soleil>();
    }

    // Update is called once per frame
    void Update()
    {
        _tempsCroissance += _soleil.DeltaMinutesEcoulees;
        if (_tempsCroissance >= ConstantesJeu.MINUTES_PAR_JOUR)
        {
            _tempsCroissance = 0.0f;
            JourneePassee();
        }
    }

    public void JourneePassee()
    {
        journeesDeVie++;
        if (journeesDeVie >= 3)
        {
            if (Random.Range(0, 100) <= 75)
            {
                oeufPerdu();
            }
            else
            {
                oeufEclore();
            }
        }
    }

    private void oeufPerdu()
    {
        Destroy(gameObject);
    }

    private void oeufEclore()
    {
        GameObject poulet = Instantiate(prefabPoulet, transform.position, transform.rotation);
        MouvementPoulet mouvement = poulet.GetComponent<MouvementPoulet>();
        mouvement.oeufPoulet = true;
        Destroy(gameObject);
    }
}
