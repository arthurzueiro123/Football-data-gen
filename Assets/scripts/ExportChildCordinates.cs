using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;

// public class ExportChildCoordinates : MonoBehaviour
// {
//     public GameObject parentObject; // Referência ao GameObject pai
//     public string fileName = "coordinates2.csv"; // Nome do arquivo CSV

//     private List<Transform> childTransforms = new List<Transform>();
//     private StreamWriter writer;

//     void Start()
//     {
//         // Obtenha todos os filhos do GameObject pai
//         foreach (Transform child in parentObject.GetComponentsInChildren<Transform>())
//         {
//             if (child != parentObject.transform)
//             {
//                 childTransforms.Add(child);
//             }
//         }

//         // Abra o arquivo CSV para escrita
//         writer = new StreamWriter(fileName);
        
//         // Escreva o cabeçalho no arquivo CSV
//         writer.Write("Frame,");
//         foreach (var child in childTransforms)
//         {
//             writer.Write($"{child.name}_x,{child.name}_y,{child.name}_z,");
//         }
//         writer.WriteLine();
//     }

//     void Update()
//     {
//         // Coleta de coordenadas a cada frame
//         writer.Write(Time.frameCount + ",");
//         foreach (var child in childTransforms)
//         {
//             Vector3 position = child.position;
//             // writer.Write($"{position.x},{position.y},{position.z},");
//             writer.Write($"{position.x.ToString(CultureInfo.InvariantCulture)},{position.y.ToString(CultureInfo.InvariantCulture)},{position.z.ToString(CultureInfo.InvariantCulture)},");
    
//         }
//         writer.WriteLine();
//     }

//     void OnApplicationQuit()
//     {
//         // Feche o arquivo CSV quando a aplicação terminar
//         writer.Close();
//     }
// }



// public class ExportChildCoordinates : MonoBehaviour
// {
//     public GameObject parentObject; // Referência ao GameObject pai
//     public string fileName = "coordinates2.csv"; // Nome do arquivo CSV

//     private List<Transform> childTransforms = new List<Transform>();
//     private StreamWriter writer;

//     void Start()
//     {
//         // Obtenha todos os filhos do GameObject pai
//         foreach (Transform child in parentObject.GetComponentsInChildren<Transform>())
//         {
//             if (child != parentObject.transform)
//             {
//                 childTransforms.Add(child);
//             }
//         }

//         // Abra o arquivo CSV para escrita
//         writer = new StreamWriter(fileName);
        
//         // Escreva o cabeçalho no arquivo CSV
//         writer.Write("Frame,");
//         foreach (var child in childTransforms)
//         {
//             writer.Write($"{child.name}_x,{child.name}_y,");
//         }
//         writer.WriteLine();
//     }

//     void Update()
//     {
//         // Coleta de coordenadas a cada frame
//         writer.Write(Time.frameCount + ",");
//         foreach (var child in childTransforms)
//         {
           
//             // Obter a câmera principal (com a tag "MainCamera")
//             Camera mainCamera = Camera.main;

//             if (mainCamera != null)
//             {
//                 // Pegar a posição do objeto em coordenadas mundiais
//                 Vector3 worldPosition = child.position;

//                 // Converter para coordenadas de tela
//                 Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

//                 // // Formatar e exibir as coordenadas x e y como strings separadas por vírgula
//                 // string coordinates = $"{screenPosition.x},{screenPosition.y}";
                
//                 writer.Write($"{screenPosition.x.ToString(CultureInfo.InvariantCulture)},{screenPosition.y.ToString(CultureInfo.InvariantCulture)},");

//             }
//             else
//             {
//                 Debug.LogWarning("Nenhuma câmera principal encontrada na cena.");
//             }

//         }
//         writer.WriteLine();
//     }

//     void OnApplicationQuit()
//     {
//         // Feche o arquivo CSV quando a aplicação terminar
//         writer.Close();
//     }
// }


// using System.Collections.Generic;
// using System.Globalization;
// using System.IO;
// using UnityEngine;

// public class ExportChildCoordinates : MonoBehaviour
// {
//     public GameObject parentObject; // Referência ao GameObject pai
//     private List<Transform> childTransforms = new List<Transform>();
//     private StreamWriter writer;
//     private bool isWriting = false;

//     void Start()
//     {
//         // Obtenha todos os filhos do GameObject pai
//         foreach (Transform child in parentObject.GetComponentsInChildren<Transform>())
//         {
//             if (child != parentObject.transform)
//             {
//                 childTransforms.Add(child);
//             }
//         }
//     }

//     void Update()
//     {
//         if (isWriting)
//         {
//             WriteCoordinates();
//         }
//     }

//     void OnApplicationQuit()
//     {
//         StopWritingToCSV();
//     }

//     public void StartWritingToCSV(string fileName)
//     {
//         // Abra o arquivo CSV para escrita
//         writer = new StreamWriter(fileName);

//         // Escreva o cabeçalho no arquivo CSV
//         writer.Write("Frame,");
//         foreach (var child in childTransforms)
//         {
//             writer.Write($"{child.name}_x,{child.name}_y,");
//         }
//         writer.WriteLine();

//         isWriting = true;
//     }

//     public void StopWritingToCSV()
//     {
//         if (writer != null)
//         {
//             // Feche o arquivo CSV quando a aplicação terminar
//             writer.Close();
//             writer = null;
//             isWriting = false;
//         }
//     }

//     private void WriteCoordinates()
//     {
//         // Coleta de coordenadas a cada frame
//         writer.Write(Time.frameCount + ",");
//         foreach (var child in childTransforms)
//         {
//             // Obter a câmera principal (com a tag "MainCamera")
//             Camera mainCamera = Camera.main;

//             if (mainCamera != null)
//             {
//                 // Pegar a posição do objeto em coordenadas mundiais
//                 Vector3 worldPosition = child.position;

//                 // Converter para coordenadas de tela
//                 Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

//                 // Formatar e exibir as coordenadas x e y como strings separadas por vírgula
//                 writer.Write($"{screenPosition.x.ToString(CultureInfo.InvariantCulture)},{screenPosition.y.ToString(CultureInfo.InvariantCulture)},");
//             }
//             else
//             {
//                 Debug.LogWarning("Nenhuma câmera principal encontrada na cena.");
//             }
//         }
//         writer.WriteLine();
//     }
// }

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class ExportChildCoordinates : MonoBehaviour
{
    public GameObject parentObject; // Referência ao GameObject pai
    private List<Transform> childTransforms = new List<Transform>();
    private StreamWriter writer;
    private bool isWriting = false;
    // public GameObject animator_controler;
    // private ControladorAnimacao animController; // Referência ao anim_controller

    void Start()
    {
        // Obtenha todos os filhos do GameObject pai
        foreach (Transform child in parentObject.GetComponentsInChildren<Transform>())
        {
            if (child != parentObject.transform)
            {
                childTransforms.Add(child);
            }
        }

        // if(animator_controler != null){
        //     // Obtenha a referência ao anim_controller (ajuste conforme necessário)
        //     animController = animator_controler.GetComponent<ControladorAnimacao>();
        // }
        
        // if (animController == null)
        // {
        //     Debug.LogError("anim_controller não encontrado no parentObject.");
        // }
    }

    void Update()
    {
        if (isWriting)
        {
            WriteCoordinates();
        }
    }

    void OnApplicationQuit()
    {
        StopWritingToCSV();
    }

    public void StartWritingToCSV(string fileName)
    {
        // Abra o arquivo CSV para escrita
        writer = new StreamWriter(fileName);

        // Escreva o cabeçalho no arquivo CSV
        writer.Write("Frame,");
        foreach (var child in childTransforms)
        {
            writer.Write($"{child.name}_x,{child.name}_y,");
        }
        // writer.Write("Label");
        writer.WriteLine();

        isWriting = true;
    }

    public void StopWritingToCSV()
    {
        if (writer != null)
        {
            // Feche o arquivo CSV quando a aplicação terminar
            writer.Close();
            writer = null;
            isWriting = false;
        }
    }

    private void WriteCoordinates()
    {
        // Coleta de coordenadas a cada frame
        writer.Write(Time.frameCount + ",");
        foreach (var child in childTransforms)
        {
            // Obter a câmera principal (com a tag "MainCamera")
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                // Pegar a posição do objeto em coordenadas mundiais
                Vector3 worldPosition = child.position;

                // Converter para coordenadas de tela
                Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

                // Formatar e exibir as coordenadas x e y como strings separadas por vírgula
                writer.Write($"{screenPosition.x.ToString(CultureInfo.InvariantCulture)},{screenPosition.y.ToString(CultureInfo.InvariantCulture)},");
            }
            else
            {
                Debug.LogWarning("Nenhuma câmera principal encontrada na cena.");
            }
        }

        // // Adicione o estado retornado pela função SetState do anim_controller
        // if (animController != null)
        // {
        //     string state = animController.getState(); // ajuste conforme necessário
        //     writer.Write(state);
        // }
        writer.WriteLine();
    }
}
