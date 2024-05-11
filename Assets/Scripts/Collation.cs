using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collation : MonoBehaviour, IRamassable
{
    private spawnCollation collation;
    private EnergieJoueur energieJoueur;

    public void Ramasser(Inventaire inventaireJoueur)
    {
        energieJoueur = GameObject.Find(ParametresParties.Instance.selectionPersonnage).GetComponent<EnergieJoueur>();

        energieJoueur.Energie += ConstantesJeu.GAIN_ENERGIE_MANGER_COLLATION;
        Destroy(gameObject);
    }


    public EtatJoueur EtatAUtiliser(ComportementJoueur Sujet)
    {
        return new EtatRamasserObjet(Sujet, this);
    }

    public bool Permis(ComportementJoueur sujet)
    {
        return true;
    }
}
