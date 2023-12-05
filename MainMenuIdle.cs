using UnityEngine;

public class MainMenuIdle : MonoBehaviour
{
    public GameObject titleNormal;
    public GameObject titleGlitched;
    public GameObject authorNormal;
    public GameObject authorGlitched;

    int timer = -100;

    void FixedUpdate()
    {
        timer++;
        if (timer >= 0) {
            titleNormal.GetComponent<TMPro.TextMeshPro>().alpha += 0.01f;
            authorNormal.GetComponent<TMPro.TextMeshPro>().alpha += 0.01f;
        }

        if (timer == 100)
        {
            glitchedTitle(true);
        }
        if (timer == 105)
        {
            glitchedTitle(false);
        }
        if (timer == 120)
        {
            glitchedTitle(true);
        }
        if (timer == 140)
        {
            glitchedTitle(false);
        }
        if (timer == 150)
        {
            glitchedTitle(true);
        }

        if (timer == 110)
        {
            glitchedAuthor(false);
        }
        if (timer == 115)
        {
            glitchedAuthor(true);
        }
        if (timer == 135)
        {
            glitchedAuthor(true);
        }
        if (timer == 145)
        {
            glitchedAuthor(false);
        }
        if (timer == 150)
        {
            glitchedAuthor(true);
        }

        if (timer == 155)
        {
            glitchedTitle(false);
            glitchedAuthor(false);
            timer = 0;
        }
    }

    void glitchedTitle(bool enabled)
    {
        titleNormal.SetActive(!enabled);
        titleGlitched.SetActive(enabled);
    }
    void glitchedAuthor(bool enabled)
    {
        authorNormal.SetActive(!enabled);
        authorGlitched.SetActive(enabled);
    }
}
