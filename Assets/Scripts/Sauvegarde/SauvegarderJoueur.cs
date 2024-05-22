using UnityEngine;
using LitJson;

public class SauvegarderJoueur : SauvegardeBase
{
    private Inventaire _inventaire;
    private EnergieJoueur _energieJoueur;
    private Soleil _soleil;
    private GameManager _gameManager;

    public override JsonData SavedData()
    {
        _inventaire = GetComponent<Inventaire>();
        _energieJoueur = GetComponent<EnergieJoueur>();
        _soleil = GameObject.Find("Directional Light").GetComponent<Soleil>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        PlayerPrefs.SetString("Nom", ParametresParties.Instance.NomJoueur);
        PlayerPrefs.SetString("Personnage", ParametresParties.Instance.selectionPersonnage);
        PlayerPrefs.SetString("Generation", ParametresParties.Instance.selectionArbre);

        PlayerPrefs.SetInt("Or", _inventaire.Or);
        PlayerPrefs.SetInt("Oeuf", _inventaire.Oeuf);
        PlayerPrefs.SetInt("Choux", _inventaire.Choux);
        PlayerPrefs.SetInt("Graines", _inventaire.Graines);
        PlayerPrefs.SetInt("Buche", _inventaire.Bois);

        PlayerPrefs.SetFloat("Energie", _energieJoueur.Energie);
        //PlayerPrefs.SetFloat("Temps", _soleil.ProportionRestante);
        PlayerPrefs.SetInt("Jour", _gameManager.NumeroJour);

        return SavedTransform;
    }

    public override void LoadFromData(JsonData data)
    {
        // IMPORTANT: Puisqu'il y a un CharacterController, on ne peut pas modifier la
        // transform sans le désactiver et réactiver.
        // On aurait Un problème similaire avec un NavMesh.
        GetComponent<CharacterController>().enabled = false;
        LoadTransformFromData(data);
        GetComponent<CharacterController>().enabled = true;
    }
}