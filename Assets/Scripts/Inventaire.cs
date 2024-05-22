using UnityEngine;

public class Inventaire : MonoBehaviour
{
    [HideInInspector][SerializeField] public int Or { get; set; }
    [HideInInspector][SerializeField] public int Oeuf { get; set; }
    [HideInInspector][SerializeField] public int Choux { get; set; }
    [HideInInspector][SerializeField] public int Graines { get; set; }
    [HideInInspector][SerializeField] public int Bois { get; set; }

    void Awake()
    {
        Or = ParametresParties.Instance.OrDepart;
        Oeuf = ParametresParties.Instance.OeufsDepart;
        Graines = ParametresParties.Instance.SemencesDepart;
        Choux = 0;
        Bois = 0;
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
}