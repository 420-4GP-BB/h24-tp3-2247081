using UnityEngine;
using LitJson;

public class SauvegarderJoueur : SauvegardeBase
{
    public override JsonData SavedData()
    {
        //Sauvegarde les informations de le joueur
        JsonData data = SavedTransform;
        data["inventaire"] = JsonUtility.ToJson(GetComponent<Inventaire>());
        data["energie"] = JsonUtility.ToJson(GetComponent<EnergieJoueur>());
        data["temps"] = JsonUtility.ToJson(GameObject.Find("Directional Light").GetComponent<Soleil>());
        data["gameManager"] = JsonUtility.ToJson(GameObject.Find("GameManager").GetComponent<GameManager>());

        PlayerPrefs.SetString("Nom", ParametresParties.Instance.NomJoueur);
        PlayerPrefs.SetString("Personnage", ParametresParties.Instance.selectionPersonnage);
        PlayerPrefs.SetString("Generation", ParametresParties.Instance.selectionArbre);
        PlayerPrefs.Save();

        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        //Load les informations de la joueur
        JsonUtility.FromJsonOverwrite(data["inventaire"].ToString(), GetComponent<Inventaire>());
        JsonUtility.FromJsonOverwrite(data["energie"].ToString(), GetComponent<EnergieJoueur>());
        JsonUtility.FromJsonOverwrite(data["temps"].ToString(), GameObject.Find("Directional Light").GetComponent<Soleil>());
        JsonUtility.FromJsonOverwrite(data["gameManager"].ToString(), GameObject.Find("GameManager").GetComponent<GameManager>());

        // IMPORTANT: Puisqu'il y a un CharacterController, on ne peut pas modifier la
        // transform sans le désactiver et réactiver.
        // On aurait Un problème similaire avec un NavMesh.
        GetComponent<CharacterController>().enabled = false;
        LoadTransformFromData(data);
        GetComponent<CharacterController>().enabled = true;
    }
}