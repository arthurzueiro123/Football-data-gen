using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // O ponto ao redor do qual a câmera irá rotacionar
    public float rotationSpeed = 5.0f;  // Velocidade de rotação
    public float zoomSpeed = 2.0f;  // Velocidade de zoom
    public float minFOV = 2.0f;  // Valor mínimo do Field of View (FOV)
    public float maxFOV = 125.0f;  // Valor máximo do Field of View (FOV)

    
    private Camera cam;

    void Start()
    {
        // Obtém a referência da câmera no mesmo GameObject
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (target != null)
        {
            // Rotacionar a câmera ao redor do ponto
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(target.position, Vector3.up, -rotationSpeed * Time.deltaTime);
            }

            // Zoom in e zoom out
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Camera.main.fieldOfView -= zoomSpeed;
                // Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
                transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Camera.main.fieldOfView += zoomSpeed;
                // Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
                 transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }

            

            // // Zoom in e zoom out
            // if (Input.GetKeyDown(KeyCode.X))
            // {
            //     Camera.main.fieldOfView -= zoomSpeed;
            //     Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
            // }
            // else if (Input.GetKeyDown(KeyCode.Z))
            // {
            //     Camera.main.fieldOfView += zoomSpeed;
            //     Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
            // }

            // // Zoom in e zoom out
            // if (Input.GetKey(KeyCode.UpArrow))
            // {
            //     Camera.main.fieldOfView -= zoomSpeed;
            //     Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
            // }
            // else if (Input.GetKey(KeyCode.DownArrow))
            // {
            //     Camera.main.fieldOfView += zoomSpeed;
            //     Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
            // }

             // Zoom in e zoom out com teclas 'X' e 'Z'
            if (Input.GetKey(KeyCode.X))
            {
                cam.fieldOfView -= zoomSpeed * Time.deltaTime;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                cam.fieldOfView += zoomSpeed * Time.deltaTime;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
            }

            // Zoom in e zoom out com scroll do mouse
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f)
            {
                cam.fieldOfView -= scroll * zoomSpeed * 10; // Multiplicar por 10 para ajustar a sensibilidade do scroll
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
            }

            // Manter a câmera olhando para o ponto
            transform.LookAt(target);
        }
    }
}
