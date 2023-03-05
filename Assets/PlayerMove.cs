using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CharacterController controller; 
    Vector3 direction;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float gravity = 20f;
    [SerializeField] Text crystalScore;
    [SerializeField] Text TimeText;

    float fastSpeed;
    float normalSpeed;
    float time = 0;
    [SerializeField ] int crystals = 0;
    // Start is called before the first frame update
    void Start()
    {
        fastSpeed = speed * 2;
        normalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            direction = new Vector3(x, 0, z);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpSpeed;
            }
        }
        
        if (crystals < 5) 
        {
            time += Time.deltaTime;
            TimeText.text = time.ToString();
        }
        
        
        direction.y -= gravity * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = fastSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
        
        controller.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            crystals += 1;
            crystalScore.text = crystals.ToString();
            Destroy(other.gameObject);
        }
    }
}
