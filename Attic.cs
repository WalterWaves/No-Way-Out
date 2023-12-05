using UnityEngine;

public class Attic : MonoBehaviour
{
    public GameObject toLeftText;
    public GameObject toRightText;
    public GameObject toDuckText;
    public float battery = 100f;
    public GameObject battery1;
    public GameObject battery2;
    public GameObject battery3;
    public GameObject battery4;
    public GameObject door;
    bool toEntrance = false;
    bool batteryUnder25 = false;
    public bool doorClosed = false;
    public bool ducked = false;
    int batteryFlicker = 50;
    int entranceCooldown = 0;

    public AudioClip flash_on;
    public AudioClip flash_off;
    public AudioClip wood_scratch;

    void Update()
    {
        UpdateBattery();
        Door();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.name == "toEntrance")
                {
                    toEntrance = !toEntrance;
                    if (entranceCooldown == 0)
                    {
                        if (toEntrance)
                        {
                            transform.GetComponent<Animator>().Play("toEntrance");
                            toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                            toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                            toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                            entranceCooldown = 25;
                        }
                        else
                        {
                            transform.GetComponent<Animator>().Play("fromEntrance");
                            toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                            toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                            toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                            entranceCooldown = 25;
                        }
                    }
                }

                if (raycastHit.transform.name == "toLeft")
                {
                    transform.GetComponent<Animator>().Play("toLeft");
                    toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                    toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                }
                if (raycastHit.transform.name == "fromLeft")
                {
                    transform.GetComponent<Animator>().Play("fromLeft");
                    toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                    toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                }
                if (raycastHit.transform.name == "toRight")
                {
                    transform.GetComponent<Animator>().Play("toRight");
                    toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                    toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                }
                if (raycastHit.transform.name == "fromRight")
                {
                    transform.GetComponent<Animator>().Play("fromRight");
                    toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                    toDuckText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                }

                if (raycastHit.transform.name == "toDuck") {
                    transform.GetComponent<Animator>().Play("toDuck");
                    toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                    toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
                    ducked = true;
                }
                if (raycastHit.transform.name == "fromDuck") {
                    transform.GetComponent<Animator>().Play("fromDuck");
                    toRightText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                    toLeftText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                    ducked = false;
                }
            }
        }

        if (Input.GetKey("space") && battery >= 0)
        {
            transform.Find("Flashlight").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("space") && battery >= 0) {
            transform.GetComponent<AudioSource>().PlayOneShot(flash_on);
        }
        if (Input.GetKeyUp("space") && battery >= 0) {
            transform.GetComponent<AudioSource>().PlayOneShot(flash_off);
        }
    }

    void FixedUpdate()
    {
        if (batteryUnder25)
        {
            batteryFlicker--;
            if (batteryFlicker >= 25)
            {
                battery1.SetActive(true);
            }
            if (batteryFlicker <= 25)
            {
                battery1.SetActive(false);
            }
            if (batteryFlicker <= 0)
            {
                batteryFlicker = 50;
            }
        }

        if (entranceCooldown > 0)
        {
            entranceCooldown--;
        }

        if (Input.GetKey("space") && battery >= 0)
        {
            battery -= 0.1f;
        }
        transform.Find("Flashlight").gameObject.SetActive(false);
    }

    void UpdateBattery()
    {
        if (battery <= 75)
        {
            battery4.SetActive(false);
        }
        if (battery <= 50)
        {
            battery3.SetActive(false);
        }
        if (battery <= 25 && battery > 0)
        {
            battery2.SetActive(false);
            batteryUnder25 = true;
        }
        if (battery <= 0)
        {
            batteryUnder25 = false;
            battery1.SetActive(false);
        }
    }

    void Door()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.name == "Door")
                {
                    if (toEntrance && !doorClosed)
                    {
                        door.GetComponent<Animator>().Play("closeDoor");
                        doorClosed = true;
                        transform.GetComponent<AudioSource>().PlayOneShot(wood_scratch);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (doorClosed)
            {
                door.GetComponent<Animator>().Play("openDoor");
                doorClosed = false;
                transform.GetComponent<AudioSource>().PlayOneShot(wood_scratch);
            }
        }
    }
}
