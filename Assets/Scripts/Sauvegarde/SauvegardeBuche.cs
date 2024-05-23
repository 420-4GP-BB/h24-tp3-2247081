using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauvegardeBuche : SauvegardeBase
{
    public override JsonData SavedData()
    {
        JsonData data = SavedTransform;
        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        LoadTransformFromData(data);
    }
}
