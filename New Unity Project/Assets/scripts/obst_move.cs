using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class obst_move : MonoBehaviour
{
    public float dir;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 orginalPosition = gameObject.transform.position;
        gameObject.transform.position = orginalPosition;
        Debug.Log(dir);





    }

    // Update is called once per frame

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * dir);
        if (transform.position.y >= 1.2f || transform.position.y <= -1.5)
            dir *= -1;
    }
}
