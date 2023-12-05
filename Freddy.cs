using UnityEngine;
using UnityEngine.SceneManagement;

public class Freddy : MonoBehaviour
{
    public GameObject freddy1;
    public GameObject freddy2;
    public int wait;
    public int patience = 1000;
    public int leaving = 150;
    public bool freddyOne = false;
    public int rand;
    public bool willLeave = false;
    void Start()
    {
        wait = Random.Range(500, 4000);
    }

    void FixedUpdate()
    {
        if (wait > 0)
        {
            wait--;
            if (wait == 1) {
                rand = Random.Range(0, 2);
                if (rand == 0) {
                    freddyOne = true;
                } else {
                    freddyOne = false;
                }
            }
        }
        if (wait == 0)
        {
            patience--;
            if (freddyOne) {
                freddy1.SetActive(true);
            } else {
                freddy2.SetActive(true);
            }
        }
        if (patience <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (willLeave)
        {
            leaving--;
            if (leaving == 1)
            {
                wait = Random.Range(500, 4000);
                patience = 1000;
                freddy1.SetActive(false);
                freddy2.SetActive(false);
                leaving = 150;
            }
        }
    }

    void Update()
    {
        if (patience > 0 && wait == 0)
        {
            if (transform.GetComponent<Attic>().ducked)
            {
                willLeave = true;
            } else {
                leaving = 150;
                willLeave = false;
            }
        } else {
            leaving = 150;
            willLeave = false;
        }
    }
}
