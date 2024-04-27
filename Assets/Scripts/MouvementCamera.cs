using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCamera : MonoBehaviour
{

    private UnityEngine.GameObject _joueur;
    [SerializeField] private Vector3 _offsetJoueur;

    // Start is called before the first frame update
    void Start()
    {
        if (ParametresParties.Instance.selectionPersonnage.Equals("Fermier"))
        {
            _joueur = UnityEngine.GameObject.Find("Fermier");
            Destroy(UnityEngine.GameObject.Find("Fermiere"));
        }
        else if (ParametresParties.Instance.selectionPersonnage.Equals("Fermiere"))
        {
            _joueur = UnityEngine.GameObject.Find("Fermiere");
            Destroy(UnityEngine.GameObject.Find("Fermier"));
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 translation = _joueur.transform.TransformDirection(_offsetJoueur); 
        Vector3 nouvellePosition = _joueur.transform.position + translation;
        transform.position = nouvellePosition;
        transform.LookAt(_joueur.transform.position + _joueur.transform.forward * 2);
    }
}
