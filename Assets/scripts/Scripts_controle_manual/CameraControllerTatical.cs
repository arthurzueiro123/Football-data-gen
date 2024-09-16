using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTatical : MonoBehaviour
{
    public float rotationSpeed = 5.0f;  // Velocidade de rotação
    public float zoomSpeed = 2.0f;  // Velocidade de zoom
    public float minFOV = 2.0f;  // Valor mínimo do Field of View (FOV)
    public float maxFOV = 125.0f;  // Valor máximo do Field of View (FOV)

    private Camera cam;
    private float initialYRotation;
    private float initialZRotation;

    void Start()
    {
        // Obtém a referência da câmera no mesmo GameObject
        cam = GetComponent<Camera>();
        // Guarda a rotação inicial em Y
        initialYRotation = transform.eulerAngles.y;
        initialZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
      // Manter a rotação em Y constante
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = initialYRotation;
        currentRotation.z = initialZRotation;
        transform.eulerAngles = currentRotation;

        // Rotacionar a câmera ao redor do ponto
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Zoom in e zoom out
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }

        // Ajuste do Field of View (FOV)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cam.fieldOfView -= zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cam.fieldOfView += zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
        }

         // Zoom in e zoom out com scroll do mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            cam.fieldOfView -= scroll * zoomSpeed * 10; // Multiplicar por 10 para ajustar a sensibilidade do scroll
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
        }

    }
}
