using UnityEngine;

public class RetournerAuMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.F5))
        {
            GestionnaireSauvegarde.Instance.SauvegarderPartie();
        }
    }
}
