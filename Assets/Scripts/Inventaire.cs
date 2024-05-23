using PlasticGui.WorkspaceWindow.PendingChanges;
using System.Collections;
using UnityEngine;

public class Inventaire : MonoBehaviour, ISerializationCallbackReceiver
{
    public int Or { get; set; }
    public int Oeuf { get; set; }
    public int Choux { get; set; }
    public int Graines { get; set; }
    public int Bois { get; set; }

    //Varaible qui permet les sauvegardes
    [HideInInspector][SerializeField] private int _or;
    [HideInInspector][SerializeField] private int _oeuf;
    [HideInInspector][SerializeField] private int _choux;
    [HideInInspector][SerializeField] private int _graines;
    [HideInInspector][SerializeField] private int _bois;

    void Awake()
    {

    }

    public void ToutPerdre()
    {
        Or = 0;
        Oeuf = 0;
        Choux = 0;
        Graines = 0;
        Bois = 0;
    }

    public void RemplirPourTester()
    {
        Or = 1000;
        Oeuf = 1000;
        Choux = 1000;
        Graines = 1000;
        Bois = 1000;
    }

    //Référence : https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html
    //Permet de set les informations lors de la charge
    public void OnBeforeSerialize()
    {
        _or = Or;
        _oeuf = Oeuf;
        _choux = Choux;
        _graines = Graines;
        _bois = Bois;
    }

    //Permet de set les informations après de la charge
    public void OnAfterDeserialize()
    {
        Or = _or;
        Oeuf = _oeuf;
        Choux = _choux;
        Graines = _graines;
        Bois = _bois;
    }
}