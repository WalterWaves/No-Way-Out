using UnityEngine;

public class ConfettiOrientation : MonoBehaviour
{
    public int speed = 0;
    void Start()
    {
        speed = Random.Range(5, 8);
    }
    void FixedUpdate()
    {
        transform.GetComponent<RectTransform>().localPosition = new Vector3(transform.GetComponent<RectTransform>().localPosition.x, transform.GetComponent<RectTransform>().localPosition.y - speed, transform.GetComponent<RectTransform>().localPosition.z);
    }
}
