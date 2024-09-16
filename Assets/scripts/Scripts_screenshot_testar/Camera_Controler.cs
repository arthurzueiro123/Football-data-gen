using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;

public class Camera_Controler
{
    private Camera cameraToControl;
    private Vector2 rotationRangeX;
    private Vector2 rotationRangeY;
    private float rotationStep;
    private float currentX;
    private float currentY;

    public Camera_Controler(Camera camera, Vector2 rangeX, Vector2 rangeY, float step)
    {
        cameraToControl = camera;
        rotationRangeX = rangeX;
        rotationRangeY = rangeY;
        rotationStep = step;
        currentX = rangeX.x;
        currentY = rangeY.x;
    }

    // Função que avança para a próxima iteração de rotação da câmera
    // Retorna o número de iterações restantes
    public int NextIteration()
    {
        if (currentX > rotationRangeX.y)
        {
            return 0; // Todas as iterações foram concluídas
        }

        // Rotaciona a câmera para a posição atual
        cameraToControl.transform.rotation = Quaternion.Euler(currentX, currentY, 0);

        // Atualiza os ângulos para a próxima iteração
        currentY += rotationStep;
        if (currentY > rotationRangeY.y)
        {
            currentY = rotationRangeY.x;
            currentX += rotationStep;
        }

        // Calcula quantas iterações restam
        int iterationsRemaining = Mathf.CeilToInt((rotationRangeX.y - currentX) / rotationStep) *
                                  Mathf.CeilToInt((rotationRangeY.y - currentY) / rotationStep);

        return iterationsRemaining > 0 ? iterationsRemaining : 0;
    }
}
