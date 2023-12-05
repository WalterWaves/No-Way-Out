using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    public int gameTime = 0;
    public int ticks = 0;
    public GameObject dots;
    public GameObject dotsIntensity;
    public GameObject hours;
    int dotsFlicker = 0;
    int delay = 100;

    void FixedUpdate() {
        ticks++;
        if (ticks == 4000) {
            gameTime++;
            ticks = 0;
        }
        if (gameTime > 0) {
            hours.GetComponent<TMPro.TextMeshPro>().text = gameTime.ToString();
        }

        dotsFlicker++;
        if (dotsFlicker == 50) {
            dots.SetActive(false);
            dotsIntensity.GetComponent<Light>().intensity = 3;
        }
        if (dotsFlicker == 100) {
            dots.SetActive(true);
            dotsIntensity.GetComponent<Light>().intensity = 5;
            dotsFlicker = 0;
        }

        if (gameTime == 6) {
            delay--;
            if (delay <= 0) {
                LevelComplete.destination = "MainMenu";
                SceneManager.LoadScene("LevelComplete");
            }
        }
    }
}
