using UnityEngine;
using UnityEngine.SceneManagement;

public class Foxy : MonoBehaviour
{
    public GameObject foxy;
    public int wait;
    public int patience = 1000;
    public int leaving = 0;
    void Start()
    {
        wait = Random.Range(1000, 5000);
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
            foxy.SetActive(true);
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
                wait = Random.Range(1000, 5000);
                patience = 1000;
                foxy.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (patience > 0 && wait == 0)
        {
            if (transform.GetComponent<Attic>().doorClosed)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    leaving = 150;
                }
            } else {
                leaving = 0;
            }
        }
    }
}
