using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText, winText;
    private Rigidbody rb;
    private int count; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Whenever we have to use functionality of calculation of physics in unity we function (void Fixedupdate) instead of (void Update). 

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }
    // SetActive() is used for enable & diable of any gameobject 
    // Compare tag will check wether the Game Object has Tag or No 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count - " + count.ToString();

            if (count >= 7)
                winText.gameObject.SetActive(true);
        }

    }

}

