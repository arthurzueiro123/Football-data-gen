using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;

public class Main_Controler_Screnshoot : MonoBehaviour
{
    public GameObject parentObject; // Referência ao GameObject pai
    private List<Transform> childTransforms = new List<Transform>();
    private StreamWriter writer;
    public Camera cameraToControl; // A câmera que será rotacionada
    public Vector2 rotationRangeX = new Vector2(-30, 30); // Intervalo de rotação no eixo X
    public Vector2 rotationRangeY = new Vector2(-30, 30); // Intervalo de rotação no eixo Y
    public float rotationStep = 5f; // Passo da rotação
    private int imageCounter = 0; // Contador de imagens capturadas
    private bool isWriting = false;
    
    private CameraIterator cameraIterator; // Referência para a nova classe CameraIterator

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

        // Inicializa a classe CameraIterator com a câmera e os parâmetros de rotação
        cameraIterator = new CameraIterator(cameraToControl, rotationRangeX, rotationRangeY, rotationStep);
    }

    public void StartWritingToCSV(string fileName)
    {
        // Abra o arquivo CSV para escrita
        writer = new StreamWriter(fileName);

        // Escreva o cabeçalho no arquivo CSV
        writer.Write("ImageName,");
        foreach (var child in childTransforms)
        {
            writer.Write($"{child.name}_x,{child.name}_y,");
        }
        writer.WriteLine();

        isWriting = true;
        StartCoroutine(CaptureProcess());
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

    IEnumerator CaptureProcess()
    {
        // Captura enquanto houverem iterações restantes
        while (cameraIterator.NextIteration() > 0)
        {
            // Espera um frame para a rotação ser aplicada
            yield return new WaitForEndOfFrame();

            // Tira uma foto
            CaptureScreenshot();

            // Coleta as coordenadas dos objetos e escreve no CSV
            WriteCoordinates();
        }

        StopWritingToCSV(); // Para de escrever no CSV quando o processo de rotação acabar
    }

    private void CaptureScreenshot()
    {
        // Define o nome da imagem
        string imageName = $"screenshot_{imageCounter}.png";
        string imagePath = Path.Combine(Application.dataPath, imageName);

        // Captura a tela e salva a imagem
        ScreenCapture.CaptureScreenshot(imagePath);
        Debug.Log($"Imagem capturada: {imageName}");

        // Incrementa o contador de imagens
        imageCounter++;
    }

    private void WriteCoordinates()
    {
        // Coleta de coordenadas no momento da captura de imagem
        writer.Write($"screenshot_{imageCounter - 1}.png,");

        foreach (var child in childTransforms)
        {
            // Obter a posição em coordenadas de tela
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(child.position);

            // Formatar as coordenadas x e y
            writer.Write($"{screenPosition.x.ToString(CultureInfo.InvariantCulture)},{screenPosition.y.ToString(CultureInfo.InvariantCulture)},");

        }

        writer.WriteLine();
    }
}
