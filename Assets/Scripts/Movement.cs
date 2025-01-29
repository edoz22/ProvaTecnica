using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 rotation;
    public Camera cam;
    public float lookSensitivity = 5f;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move;
        int w, a, s, d;

        // Controllo dei tasti
        if (Input.GetKey("w")) w = 1; else w = 0;
        if (Input.GetKey("a")) a = 1; else a = 0;
        if (Input.GetKey("s")) s = 1; else s = 0;
        if (Input.GetKey("d")) d = 1; else d = 0;

        // Calcolo del movimento
        move.y = w - s; // Avanti (+) e indietro (-)
        move.x = d - a; // Destra (+) e sinistra (-)

        // Rotazione della camera con il mouse
        rotation.y += Input.GetAxis("Mouse X") * lookSensitivity;
        rotation.x += Input.GetAxis("Mouse Y") * lookSensitivity;

        // Limita la rotazione verticale per evitare ribaltamenti
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        // Aggiorna la rotazione della camera e del giocatore
        cam.transform.eulerAngles = new Vector3(-rotation.x, rotation.y, 0);
        cam.transform.position = transform.position + new Vector3(0, 1, 0);
        transform.eulerAngles = new Vector3(0, rotation.y, 0);

        // Calcolo del movimento nel mondo
        Vector3 desiredVelocity = transform.TransformDirection(new Vector3(move.x, 0, move.y) * moveSpeed);
        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);
    }
}
