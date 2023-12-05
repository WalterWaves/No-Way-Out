using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntroCutscene : MonoBehaviour
{
    public float size = 0;
    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            if (size < 100) {
                size += 2;
            }
        } else {
            if (size > 0) {
                size -= 5;
            }
        }
    }

    void Update() {
        transform.Find("Circle").transform.Find("Square").transform.GetComponent<RectTransform>().localPosition = new Vector3(0f, size - 100f, 0f);
        if (size >= 100) {
            SceneManager.LoadScene("Attic");
        }
    }
}
