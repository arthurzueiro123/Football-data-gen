using UnityEngine;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine.Recorder;
using System.IO;

public class ScreenRecorder : MonoBehaviour
{
    private RecorderController recorderController;
    private RecorderControllerSettings recorderSettings;
    private MovieRecorderSettings videoRecorder;

    void Start()
    {
        // Configurar a gravação
        SetupRecorder();
    }

    // void Update()
    // {
    //     // Iniciar a gravação quando a tecla R é pressionada
    //     if (Input.GetKeyDown(KeyCode.R))
    //     {
    //         if (!recorderController.IsRecording())
    //         {
    //             StartRecording("Caminho/para/seu/diretorio/nome_do_arquivo.mp4"); // Passe o caminho completo e o nome do arquivo desejado aqui
    //         }
    //     }

    //     // Parar a gravação quando a tecla S é pressionada
    //     if (Input.GetKeyDown(KeyCode.S))
    //     {
    //         if (recorderController.IsRecording())
    //         {
    //             StopRecording();
    //         }
    //     }
    // }

    void SetupRecorder()
    {
        // Criar as configurações do controlador
        recorderSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();

        // Configurar as entradas de vídeo e áudio
        videoRecorder = ScriptableObject.CreateInstance<MovieRecorderSettings>();
        videoRecorder.name = "Meu gravador de vídeo";
        videoRecorder.Enabled = true;
        videoRecorder.ImageInputSettings = new GameViewInputSettings
        {
            OutputWidth = 1920,
            OutputHeight = 1080
        };

        // Adicionar as configurações ao controlador
        recorderSettings.AddRecorderSettings(videoRecorder);
        recorderSettings.FrameRate = 30;

        // Criar o controlador de gravação
        recorderController = new RecorderController(recorderSettings);
    }

    public void StartRecording(string fullPath)
    {
        if (!recorderController.IsRecording())
        {
            // Configurar o caminho de saída
            string directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            videoRecorder.OutputFile = fullPath;

            // Iniciar a gravação
            recorderController.PrepareRecording();
            recorderController.StartRecording();
            Debug.Log("Gravação iniciada.");
        }
    }

    public void StopRecording()
    {
        if (recorderController.IsRecording())
        {
            recorderController.StopRecording();
            Debug.Log("Gravação parada.");
        }
    }
}