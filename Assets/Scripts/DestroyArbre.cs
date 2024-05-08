using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArbre : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arbre"))
        {
            Destroy(other.gameObject);
        }
    }
}
