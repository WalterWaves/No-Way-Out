using UnityEngine;

public class Fan : MonoBehaviour
{
    int z = 0;
    void Update() {
        transform.Find("Blades").transform.localRotation = Quaternion.Euler(new Vector3(0, 0 , z));
    }

    void FixedUpdate() {
        z += 20;
    }
}
