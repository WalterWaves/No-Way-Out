using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFirstCutscene : MonoBehaviour
{
    int timer = 0;
    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            timer++;
            if (timer == 2250)
            {
                SceneManager.LoadScene("Attic");
            }
        }
    }
}
