using UnityEngine;

public class Player : MonoBehaviour
{
    public float s = 5f;

    public Color c1 = Color.white;
    public Color c2 = Color.red;

    public Rigidbody rb;

    public float x;
    public float z;
    public bool m;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = c1;
    }

    void Update()
    {
        // Leer movimiento
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        // Saber si se está moviendo
        if (x != 0 || z != 0)
        {
            m = true;
        }
        else
        {
            m = false;
        }

        // Crear dirección
        Vector3 d = new Vector3(x, 0, z);

        // Evitar mayor velocidad diagonal
        if (d.magnitude > 1)
        {
            d.Normalize();
        }

        // Movimiento físico ejecutado dentro de Update
        Vector3 p = rb.position + d * s * Time.deltaTime;
        rb.MovePosition(p);

        // Cambiar el color
        if (m == true)
        {
            GetComponent<Renderer>().material.color = c2;
        }
        else
        {
            GetComponent<Renderer>().material.color = c1;
        }
    }
}