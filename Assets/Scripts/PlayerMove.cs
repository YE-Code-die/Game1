using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed = 6.0f;
    public float jump = 8.0f;
    public float gravity = 20.0f;
    public float mousespeed = 5f;

    public float minmouseY = -45f;
    public float maxmouseY = 45f;
    CharacterController Controller;
    float RotationY = 0f;
    float RotationX = 0f;
    public Transform Camera;
    private Vector3 moveDirection = Vector3.zero;
    public static int count;
    public Text countText;
    public Text timeText;
    public static float timeCount = 200;
    private int second;
   
    void Start()
    {
        Cursor.visible = false;
        Controller = this.GetComponent<CharacterController>();
        timeText = GameObject.Find("time").GetComponent<Text>();

    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Controller.isGrounded)
        {
            // moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection *= speed;
            moveDirection = new Vector3(horizontal, 0, vertical);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jump;
            } 
        }
        moveDirection.y -= gravity * Time.deltaTime;
        Controller.Move(Controller.transform.TransformDirection(moveDirection * Time.deltaTime * speed));
        RotationX += Camera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;
        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);
        this.transform.eulerAngles = new Vector3(0, RotationX, 0);
        Camera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
        timeCount -= Time.deltaTime;
        second = (int)timeCount % 200;
        timeText.text = "Time:" + second.ToString();
        if(timeCount <= 0)
        {
            if (count >= 30)
            {
                SceneManager.LoadScene("winScene");
                count = 0;
                timeCount = 120;
            }
            else
            {
                SceneManager.LoadScene("loseScene");
                count = 0;
                timeCount = 120;

            }

        }
       // float x = Input.GetAxis("Horizontal");
      //  float z = Input.GetAxis("Vertical");
      //  Vector3 move = transform.right * x + transform.forward * z;
    //    Controller.Move(move * speed * Time.deltaTime);
    //    camera.Move(move * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            ValueCounter();
        }else if(other.gameObject.CompareTag("win")){
            other.gameObject.SetActive(false);
            count += 15;
            
            if (count >= 25)
            {
                SceneManager.LoadScene("winScene");
            }
            else 
            {
                SceneManager.LoadScene("loseScene");
            }
            ValueCounter();
        }else if (other.gameObject.CompareTag("secret"))
        {
            SceneManager.LoadScene("secret");
        }
        else if (other.gameObject.CompareTag("ball"))
        {
            SceneManager.LoadScene("mainGame");
        }
        else if (other.gameObject.CompareTag("devil"))
        {
            other.gameObject.SetActive(false);
            count--;
            ValueCounter();
        }
        else if (other.gameObject.CompareTag("bad"))
        {
            SceneManager.LoadScene("devil");
        }
    }
    void ValueCounter()
    {
        countText.text = "Score: " + count.ToString();
    } 
}
