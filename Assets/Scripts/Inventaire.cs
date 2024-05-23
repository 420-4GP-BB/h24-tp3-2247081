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

    [HideInInspector][SerializeField] private int _or;
    [HideInInspector][SerializeField] private int _oeuf;
    [HideInInspector][SerializeField] private int _choux;
    [HideInInspector][SerializeField] private int _graines;
    [HideInInspector][SerializeField] private int _bois;

    void Awake()
    {
        if (_or == 0 && _oeuf == 0 && _choux == 0 && _graines == 0 && _bois == 0)
        {
            Or = ParametresParties.Instance.OrDepart;
            Oeuf = ParametresParties.Instance.OeufsDepart;
            Graines = ParametresParties.Instance.SemencesDepart;
            Choux = 0;
            Bois = 0;
        }
        else
        {
            Or = _or;
            Oeuf = _oeuf;
            Graines = _choux;
            Choux = _graines;
            Bois = _bois;
        }
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

    public void OnBeforeSerialize()
    {
        _or = Or;
        _oeuf = Oeuf;
        _choux = Choux;
        _graines = Graines;
        _bois = Bois;
    }

    public void OnAfterDeserialize()
    {
        Or = _or;
        Oeuf = _oeuf;
        Choux = _choux;
        Graines = _graines;
        Bois = _bois;
    }
}