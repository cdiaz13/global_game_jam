using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{

    public float speed;
    private bool rolling = false;
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -1)
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        if (rolling)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(Roll(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(Roll(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(Roll(Vector3.forward));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(Roll(Vector3.back));
        }

    }

    IEnumerator Roll(Vector3 direction)
    {
        rolling = true;
     
        float rangle = 90;
        Vector3 rotcenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotaxis =  Vector3.Cross(Vector3.up, direction);

        while (rangle > 0)
        {
            float rotangle = Mathf.Min(Time.deltaTime * speed, rangle);
            transform.RotateAround(rotcenter, rotaxis, rotangle);
            rangle -= rotangle;
            yield return null;
        }
        rolling = false;
    }
}
