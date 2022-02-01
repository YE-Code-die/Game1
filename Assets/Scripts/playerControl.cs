using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 100f;
    public Transform player;
 //   public GameObject player1;
    private Vector3 offset;
    float xRotation = 0f;
    public int count;
    public Text countText;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
  //      offset = transform.position - player1.transform.position;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
  //      transform.position = player1.transform.position + offset;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            ValueCounter();
        }
    }
    void ValueCounter()
    {
        countText.text = "Count: " + count.ToString();
    }
}
