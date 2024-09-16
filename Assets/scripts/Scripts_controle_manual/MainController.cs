// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MainController : MonoBehaviour
// {

//     public string caminho = $"C:\\Users\\arthu\\Desktop\\dataset-v5";


//     public GameObject screenRec;
//     private ScreenRecorder screenRecorder;

//     public GameObject exportChildCoords;
//     private ExportChildCoordinates exportChildCoordinates;



//     private int scene, cam;

//     void Start()
//     {

//         if (screenRec == null)
//         {
//             Debug.LogError("A referência ao GameObject screenRec não foi definida.");
//             return;
//         }

//         screenRecorder = screenRec.GetComponent<ScreenRecorder>();
//         if (screenRecorder == null)
//         {
//             Debug.LogError("ScreenRecorder não encontrado no screenRec.");
//             return;
//         }

//         if (exportChildCoords == null)
//         {
//             Debug.LogError("A referência ao GameObject exportChildCoords não foi definida.");
//             return;
//         }

//         exportChildCoordinates = exportChildCoords.GetComponent<ExportChildCoordinates>();
//         if (exportChildCoordinates == null)
//         {
//             Debug.LogError("ExportChildCoordinates não encontrado no exportChildCoords.");
//             return;
//         }
//     }

//     void Update()
//     {
//         // Iniciar a gravação quando a tecla R é pressionada
//         if (Input.GetKeyDown(KeyCode.R))
//         {
//             // StartRecording("Caminho/para/seu/diretorio/nome_do_arquivo.mp4"); // Passe o caminho completo e o nome do arquivo desejado aqui
//             StartRecordData();
            
//         }

//         // Parar a gravação quando a tecla S é pressionada
//         if (Input.GetKeyDown(KeyCode.S))
//         {
    
//             StopRecordData();
            
//         }
//     }

//     public void StartRecordData()
//     {
//         if (screenRecorder == null || exportChildCoordinates == null)
//         {
//             Debug.LogError("camCont, screenRecorder ou exportChildCoordinates não foram inicializados corretamente.");
//             return;
//         }

       
//         string basePath = caminho;
//         string fileName = $"video_{scene}";

//         string videoPath = $"{basePath}\\{fileName}";//não precisa do .mp4
//         string csvPath = $"{basePath}\\{fileName}.csv";

    

//         screenRecorder.StartRecording(videoPath);
//         exportChildCoordinates.StartWritingToCSV(csvPath);
//     }

//     public void StopRecordData()
//     {
        

//             if (exportChildCoordinates != null)
//             {
//                 exportChildCoordinates.StopWritingToCSV();
//             }
//             else
//             {
//                 Debug.LogError("ExportChildCoordinates não encontrado no exportChildCoords.");
//             }

//             if (screenRecorder != null)
//             {
//                 screenRecorder.StopRecording();
//             }
//             else
//             {
//                 Debug.LogError("ScreenRecorder não encontrado no screenRec.");
//             }
        
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public string caminho = $"C:\\Users\\arthu\\Desktop\\dataset-v5";

    public GameObject screenRec;
    private ScreenRecorder screenRecorder;

    public GameObject exportChildCoords;
    private ExportChildCoordinates exportChildCoordinates;

    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private int scene = 1;

    void Start()
    {
        if (screenRec == null)
        {
            Debug.LogError("A referência ao GameObject screenRec não foi definida.");
            return;
        }

        screenRecorder = screenRec.GetComponent<ScreenRecorder>();
        if (screenRecorder == null)
        {
            Debug.LogError("ScreenRecorder não encontrado no screenRec.");
            return;
        }

        if (exportChildCoords == null)
        {
            Debug.LogError("A referência ao GameObject exportChildCoords não foi definida.");
            return;
        }

        exportChildCoordinates = exportChildCoords.GetComponent<ExportChildCoordinates>();
        if (exportChildCoordinates == null)
        {
            Debug.LogError("ExportChildCoordinates não encontrado no exportChildCoords.");
            return;
        }

        if (cameras == null || cameras.Length == 0)
        {
            Debug.LogError("A lista de câmeras não foi definida ou está vazia.");
            return;
        }

        // Desativar todas as câmeras no início
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // Ativar a primeira câmera
        if (cameras.Length > 0)
        {
            cameras[currentCameraIndex].enabled = true;
        }
    }

    void Update()
    {
        // Iniciar a gravação quando a tecla R é pressionada
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRecordData();
        }

        // Parar a gravação quando a tecla S é pressionada
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopRecordData();
            scene++; // Incrementar a variável scene
        }

        // Trocar a câmera quando a tecla C é pressionada
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void StartRecordData()
    {
        if (screenRecorder == null || exportChildCoordinates == null)
        {
            Debug.LogError("screenRecorder ou exportChildCoordinates não foram inicializados corretamente.");
            return;
        }

        string basePath = caminho;
        string fileName = $"video_{scene}";

        string videoPath = $"{basePath}\\{fileName}"; //não precisa do .mp4
        string csvPath = $"{basePath}\\{fileName}.csv";

        screenRecorder.StartRecording(videoPath);
        exportChildCoordinates.StartWritingToCSV(csvPath);
    }

    public void StopRecordData()
    {
        if (exportChildCoordinates != null)
        {
            exportChildCoordinates.StopWritingToCSV();
        }
        else
        {
            Debug.LogError("ExportChildCoordinates não encontrado no exportChildCoords.");
        }

        if (screenRecorder != null)
        {
            screenRecorder.StopRecording();
        }
        else
        {
            Debug.LogError("ScreenRecorder não encontrado no screenRec.");
        }
    }

    private void SwitchCamera()
    {
        if (cameras == null || cameras.Length == 0)
        {
            Debug.LogError("A lista de câmeras não foi definida ou está vazia.");
            return;
        }

        // Desativar a câmera atual
        cameras[currentCameraIndex].enabled = false;

        // Atualizar o índice da câmera
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Ativar a próxima câmera
        cameras[currentCameraIndex].enabled = true;
    }
}
