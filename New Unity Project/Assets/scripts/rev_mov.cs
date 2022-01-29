using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class rev_mov : MonoBehaviour
{
    public float revspeed;
    private bool revrolling = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void FixedUpdate()
    {
        if (transform.position.y < -1)
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        if (revrolling)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(revRoll(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(revRoll(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(revRoll(Vector3.back));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(revRoll(Vector3.forward));
        }

    }
    
    IEnumerator revRoll(Vector3 direction)
    {
        revrolling = true;
     
        float rangle = 90;
        Vector3 rotcenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotaxis =  Vector3.Cross(Vector3.up, direction);

        while (rangle > 0)
        {
            float rotangle = Mathf.Min(Time.deltaTime * revspeed, rangle);
            transform.RotateAround(rotcenter, rotaxis, rotangle);
            rangle -= rotangle;
            yield return null;
        }
        revrolling = false;
    }
}
