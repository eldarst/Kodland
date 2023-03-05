using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] float x = 647f;
    float y = 5;
    float z = 660f;
    [SerializeField] string sos = "Приём, приём! Свяжитесь со мной. Мои координаты: ";

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(x, y, z);
        print(sos);
        print("x = " + x);
        print("y = " + y);
        print("z = " + z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
