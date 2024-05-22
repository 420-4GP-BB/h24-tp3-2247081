using System.Collections;
using UnityEngine;

public class RetournerAuMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GestionnaireSauvegarde.Instance.SauvegarderPartie();
            StartCoroutine(waitTime());
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1);
    }
}
