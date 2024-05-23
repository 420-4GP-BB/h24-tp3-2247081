using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauvegardeBuche : SauvegardeBase
{
    public override JsonData SavedData()
    {
        //Sauvegarde les informations de la bûche
        JsonData data = SavedTransform;
        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        //Load les informations de la bûche
        LoadTransformFromData(data);
    }
}
