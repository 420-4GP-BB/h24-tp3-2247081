public class ParametresParties
{
    public static ParametresParties Instance { get; private set; } = new ParametresParties();

    public string NomJoueur { get; set; } = "Mathurin";
    public int OrDepart { get; set; } = 200;
    public int OeufsDepart { get; set; } = 5;
    public int Chou { get; set; } = 0;
    public int Bois { get; set; } = 0;
    public int SemencesDepart { get; set; } = 5;
    public string selectionPersonnage { get; set; } = "Fermier";
    public string selectionArbre { get; set; } = "Grille";
    public float tempCourant { get; set; } = 8.0f / 24;
    public int numeroJour { get; set; } = 1;
    public float energie { get; set; } = 1;

    ///// <summary>
    ///// Nombre de jours nécessaires à un chou pour être prêts
    ///// 0 = le chou est déjà prêt dès qu'on le plante
    ///// </summary>
    public int TempsCroissance { get; set; } = 3;

    ///// <summary>
    ///// Nombre de jours pendant lesquels on peut cueillir un chou prêt
    ///// Plus cette valeur est petite, plus on doit se dépêcher avant qu'ils ne soient plus bons
    ///// </summary>
    public int DelaiCueillete { get; set; } = 5;

    private ParametresParties()
    {
    }
}