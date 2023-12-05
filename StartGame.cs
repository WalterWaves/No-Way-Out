using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject startGame;
    public GameObject skip;
    int timer = 0;
    int delay = 150;
    bool started = false;

    void Start() {
        startGame.GetComponent<Animator>().Play("SetAlphaTo100");
    }

    void Update()
    {
        if (delay == 0)
        {
            if (Input.GetKey("space"))
            {
                if (!started)
                {
                    transform.GetComponent<Animator>().Play("CameraUp");
                    startGame.GetComponent<Animator>().Play("SetAlphaTo0");
                    started = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (delay > 0)
        {
            delay--;
        }
        if (started)
        {
            timer++;
            if (timer == 110)
            {
                videoPlayer.SetActive(true);
                skip.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
