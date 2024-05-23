using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauvegarderPoulet : SauvegardeBase
{
    private Transform[] garderPoints;

    public override JsonData SavedData()
    {
        JsonData data = SavedTransform;
        data["mouvement"] = JsonUtility.ToJson(GetComponent<MouvementPoulet>());
        return data;
    }

    public override void LoadFromData(JsonData data)
    {
        GameObject[] points = GetComponent<MouvementPoulet>()._pointsDeDeplacement;
        garderPoints = points.Clone() as Transform[];
        JsonUtility.FromJsonOverwrite(data["mouvement"].ToString(), GetComponent<MouvementPoulet>());
        GetComponent<MouvementPoulet>()._pointsDeDeplacement = garderPoints.Clone() as GameObject[];

        LoadTransformFromData(data);
    }
}
