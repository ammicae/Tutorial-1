using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    //private int redcount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       // if (other.gameObject.CompareTag("Red Pick Up"))
       // {
          //  other.gameObject.SetActive(false);
          //  redcount = count - 1;
           // SetRedCountText();
       // }
    }
   // void SetRedCountText()
   // {
   //     redcountText.text = "Red Count: " + redcount.ToString();
    //}
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >=12)
        {
            winText.text = "You finished with a score of " + count.ToString();
        }
    }
    
}