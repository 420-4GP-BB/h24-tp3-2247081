using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class GestionnaireInterface : MonoBehaviour
{
    [SerializeField] private Button _boutonDemarrer;

    enum Difficulte
    {
        Facile,
        Moyen,
        Difficile
    }

    enum Personnage
    {
        Fermier,
        Fermière
    }

    private Difficulte difficulte;
    private Personnage personnage;
    private string selectionPersonnage;


    [SerializeField] private TMP_InputField nomJoueur;
    [SerializeField] private TMP_Text presentation;

    [SerializeField] private int[] valeursFacile;
    [SerializeField] private int[] valeursMoyen;
    [SerializeField] private int[] valeursDifficile;

    [SerializeField] private TMP_Text[] valeursDepart;
    [SerializeField] private TMP_Dropdown difficulteDropdown;
    [SerializeField] private TMP_Dropdown personnageDropdown;

    [SerializeField] private GameObject showPersonnage;
    [SerializeField] private GameObject prefabFermier;
    [SerializeField] private GameObject prefabFermiere;

    // Start is called before the first frame update
    void Start()
    {
        nomJoueur.text = "Mathurin";
        ChangerNomJoueur();

        selectionPersonnage = "Fermier";
        difficulte = Difficulte.Facile;
        personnage = Personnage.Fermier;
        MettreAJour(valeursFacile);
    }

    void Update()
    {
        _boutonDemarrer.interactable = nomJoueur.text != string.Empty;
    }

    public void ChangerDifficulte()
    {
        difficulte = (Difficulte)difficulteDropdown.value;

        switch (difficulte)
        {
            case Difficulte.Facile:
                MettreAJour(valeursFacile);
                break;
            case Difficulte.Moyen:
                MettreAJour(valeursMoyen);
                break;
            case Difficulte.Difficile:
                MettreAJour(valeursDifficile);
                break;
        }
    }

    public void ChangerPersonnage()
    {
        personnage = (Personnage)personnageDropdown.value;

        switch (personnage)
        {
            case Personnage.Fermier:
                Destroy(showPersonnage);
                showPersonnage = Instantiate(prefabFermier, showPersonnage.transform.position, showPersonnage.transform.rotation);
                selectionPersonnage = "Fermier";
                break;
            case Personnage.Fermière:
                Destroy(showPersonnage);
                showPersonnage = Instantiate(prefabFermiere, showPersonnage.transform.position, showPersonnage.transform.rotation);
                selectionPersonnage = "Fermiere";
                break;
        }
    }

    public void DemarrerPartie()
    {
        int[] valeursActuelles = null;
        switch (difficulte)
        {
            case Difficulte.Facile:
                valeursActuelles = valeursFacile;
                break;
            case Difficulte.Moyen:
                valeursActuelles = valeursMoyen;
                break;
            case Difficulte.Difficile:
                valeursActuelles = valeursDifficile;
                break;
        }

        ParametresParties.Instance.NomJoueur = nomJoueur.text;
        ParametresParties.Instance.OrDepart = valeursActuelles[0];
        ParametresParties.Instance.OeufsDepart = valeursActuelles[1];
        ParametresParties.Instance.SemencesDepart = valeursActuelles[2];
        ParametresParties.Instance.TempsCroissance = valeursActuelles[3];
        ParametresParties.Instance.DelaiCueillete = valeursActuelles[4];
        ParametresParties.Instance.selectionPersonnage = selectionPersonnage;

        if (nomJoueur.text != string.Empty)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ferme");
        }
    }

    public void QuitterJeu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void MettreAJour(int[] valeurs)
    {
        for (int i = 0; i < valeursDepart.Length; i++)
        {
            valeursDepart[i].text = valeurs[i].ToString();
        }
    }

    public void ChangerNomJoueur()
    {
        presentation.text = $"\u266A \u266B Dans la ferme \u00e0  {nomJoueur.text} \u266B \u266A";
    }
}