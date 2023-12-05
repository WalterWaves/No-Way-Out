using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject confettiObject;
    public GameObject canvas;
    public static string destination = "";
    public int delay = 1000;

    void Start()
    {
        for (int i = 1; i <= 200; i++)
        {
            GameObject confetti = Instantiate(confettiObject);
            confetti.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360)));
            confetti.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(0, 3000), Random.Range(650, 2000), 0);
            confetti.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
            confetti.transform.SetParent(canvas.transform);
        }
        confettiObject.SetActive(false);
    }

    void FixedUpdate()
    {
        delay--;
        if (delay <= 0) {
            SceneManager.LoadScene(destination);
        }
    }
}
