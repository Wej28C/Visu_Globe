using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbite : MonoBehaviour
{
    public GameObject cible; 
    public float anglesParSeconde=45;
    public float rotationSpeed = 2.0f; // Vitesse de rotation de la caméra

    // Start is called before the first frame update
    void Start()
    {
        this.transform.transform.position = new Vector3(2, 0, 0);
        this.transform.transform.rotation = Quaternion.Euler(0,-90f,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(cible.transform.position, Vector3.up, anglesParSeconde * Time.deltaTime);
        RotateWithMouseInput();
        RotateWithArrowKeys();
    }
    void RotateWithMouseInput()
    {
        // Obtient la variation de la souris
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Applique la rotation en fonction de la variation de la souris
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        transform.Rotate(Vector3.left * mouseY * rotationSpeed);

        // Assurez-vous que la caméra ne tourne pas complètement à l'envers
        float xRotation = transform.eulerAngles.x;
        if (xRotation > 80.0f && xRotation < 180.0f)
        {
            xRotation = 80.0f;
        }
        else if (xRotation > 180.0f && xRotation < 280.0f)
        {
            xRotation = 280.0f;
        }

        // Applique la restriction de rotation
        transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, 0.0f);
    }

    void RotateWithArrowKeys()
    {
        // Obtient les entrées du pavé directionnel
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcule la rotation en fonction des entrées du pavé directionnel
        Vector3 rotation = new Vector3(verticalInput, horizontalInput, 0) * rotationSpeed;

        // Applique la rotation
        transform.Rotate(rotation);
    }
}
