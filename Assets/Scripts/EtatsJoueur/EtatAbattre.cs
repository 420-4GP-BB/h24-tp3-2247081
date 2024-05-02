using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAbattre : EtatJoueur
{
    public override bool EstActif => true;
    public override bool DansDialogue => false;
    public override float EnergieDepensee => ConstantesJeu.COUT_ABATTRE;

    private IAbattable _abattable;
    private float _tempsDeAbattre = 0.0f;

    public EtatAbattre(ComportementJoueur sujet, IAbattable abattable) : base(sujet)
    {
        _abattable = abattable;
    }

    public override void Enter()
    {
        Animateur.SetBool("Pousser", true);
    }

    public override void Handle()
    {
        _tempsDeAbattre += Time.deltaTime;
        if (_tempsDeAbattre >= 2.0f)
        {
            _abattable.Abattre(Inventaire);
            Sujet.ChangerEtat(Sujet.EtatNormal);
        }
    }

    public override void Exit()
    {
        Animateur.SetBool("Pousser", false);
    }
}
