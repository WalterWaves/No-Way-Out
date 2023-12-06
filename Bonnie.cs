using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonnie : MonoBehaviour
{
    public GameObject bonnie;
    public int wait;
    public int patience = 2000;
    public int leaving = 0;
    public int blind = 0;
    void Start()
    {
        wait = Random.Range(2000, 5000);
    }

    void FixedUpdate()
    {
        if (wait > 0)
        {
            wait--;
        }
        if (wait == 0)
        {
            patience--;
            bonnie.SetActive(true);
        }
        if (patience <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (leaving > 0)
        {
            leaving--;
            if (leaving == 1)
            {
                wait = Random.Range(2000, 5000);
                patience = 2000;
                bonnie.SetActive(false);
            }
        }

        if (patience > 0 && wait == 0)
        {
            if (transform.GetComponent<Attic>().lookingUp)
            {
                if (Input.GetKey("space") && transform.GetComponent<Attic>().battery > 0 && leaving == 0)
                {
                    blind++;
                }
            }
        }
        if (blind >= 100)
        {
            blind = 0;
            leaving = 150;
        }
    }
}