using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

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
    enum Generation
    {
        Grille,
        Random,
        Simulation
    }


    private Difficulte difficulte;
    private Personnage personnage;
    private Generation generation;
    private string selectionPersonnage;
    private string selectionArbre;
    private GameManager gameManager;
    private EnergieJoueur energie;

    [SerializeField] private Button boutonCharger;

    [SerializeField] private TMP_InputField nomJoueur;
    [SerializeField] private TMP_Text presentation;

    [SerializeField] private int[] valeursFacile;
    [SerializeField] private int[] valeursMoyen;
    [SerializeField] private int[] valeursDifficile;

    [SerializeField] private TMP_Text[] valeursDepart;
    [SerializeField] private TMP_Dropdown difficulteDropdown;
    [SerializeField] private TMP_Dropdown personnageDropdown;
    [SerializeField] private TMP_Dropdown generationDropdown;

    [SerializeField] private GameObject showPersonnage;
    [SerializeField] private GameObject prefabFermier;
    [SerializeField] private GameObject prefabFermiere;

    // Start is called before the first frame update
    void Start()
    {
        nomJoueur.text = "Mathurin";
        ChangerNomJoueur();

        selectionPersonnage = "Fermier";
        selectionArbre = "Grille";
        difficulte = Difficulte.Facile;
        personnage = Personnage.Fermier;
        MettreAJour(valeursFacile);

        // Ajouter la méthode charger partie au bouton
        boutonCharger.onClick.AddListener(RestaurerPartie);
        boutonCharger.interactable = GestionnaireSauvegarde.Instance.FichierExiste;

        //gameManager = GetComponent<GameManager>();
        //energie = GameObject.Find(ParametresParties.Instance.selectionPersonnage).GetComponent<EnergieJoueur>();
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

    public void ChangerGeneration()
    {
        generation = (Generation)generationDropdown.value;

        switch (generation)
        {
            case Generation.Grille:
                selectionArbre = "Grille";
                break;
            case Generation.Random:
                selectionArbre = "Random";
                break;
            case Generation.Simulation:
                selectionArbre = "Simulation";
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
        ParametresParties.Instance.selectionArbre = selectionArbre;
        ParametresParties.Instance.tempCourant = 8.0f / 24;
        ParametresParties.Instance.numeroJour = 1;
        ParametresParties.Instance.energie = 1;

        if (nomJoueur.text != string.Empty)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ferme");
        }
    }

    public void RestaurerPartie()
    {
        ParametresParties.Instance.NomJoueur = PlayerPrefs.GetString("Nom");
        ParametresParties.Instance.selectionPersonnage = PlayerPrefs.GetString("Personnage");
        ParametresParties.Instance.selectionArbre = PlayerPrefs.GetString("Generation");

        GestionnaireSauvegarde.Instance.ChargerPartie("Ferme");
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