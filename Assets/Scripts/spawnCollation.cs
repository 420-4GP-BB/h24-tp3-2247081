using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCollation : MonoBehaviour
{
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private GameObject[] tableCollation;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        createCollation();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPlace.transform.childCount <= 0 && !isRunning)
        {
            isRunning = true;
            StartCoroutine(compterSecondes());
        }
    }

    void createCollation()
    {
        Instantiate(tableCollation[Random.Range(0,3)], transform.position, Quaternion.identity, spawnPlace);
        isRunning = false;
    }

    IEnumerator compterSecondes()
    {
        yield return new WaitForSecondsRealtime(30);
        createCollation();
    }
}
