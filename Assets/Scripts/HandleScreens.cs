using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class HandleScreens : MonoBehaviour
{
    Color colorFromHex;

    // Solução e Main Canvas
    public GameObject MainCanvas;
    public GameObject Solution;

    // Câmeras
    public GameObject mainCamera;
    public GameObject builderScreenCamera;

    // Telas

    public GameObject initialScreen;
    public GameObject gameScreen;
    public GameObject calibrationScreen;
    public GameObject builderScreen;

    // Elementos
    public GameObject calibrationDoneBtn;
    public GameObject calibrationScreenManager;
    public GameObject builderScreenManager;

    public void InitialScreen () {
        // Câmeras
        mainCamera.SetActive(true);
        ColorUtility.TryParseHtmlString("#63A3CC", out colorFromHex);
        mainCamera.GetComponent<Camera>().backgroundColor = colorFromHex;
        builderScreenCamera.SetActive(false);

        // Telas
        gameScreen.SetActive(false);
        initialScreen.SetActive(true);
        calibrationScreen.SetActive(false);
        builderScreen.SetActive(false);

        // Elementos
        calibrationScreenManager.SetActive(true);
        calibrationDoneBtn.SetActive(true);
        builderScreenManager.SetActive(false);
    }

    public void GameScreen () {
        MainCanvas.SetActive(true);
        Solution.SetActive(true);

        // Câmeras
        mainCamera.SetActive(true);
        ColorUtility.TryParseHtmlString("#ECECEC", out colorFromHex);
        mainCamera.GetComponent<Camera>().backgroundColor = colorFromHex;
        builderScreenCamera.SetActive(false);

        // Telas
        gameScreen.SetActive(true);
        initialScreen.SetActive(false);
        calibrationScreen.SetActive(false);
        builderScreen.SetActive(false);

        // Elementos
        calibrationScreenManager.SetActive(false);
        calibrationDoneBtn.SetActive(false);
        builderScreenManager.SetActive(false);
    }

    public void CalibrationScreen () {
        MainCanvas.SetActive(true);
        Solution.SetActive(true);
        // Câmeras
        mainCamera.SetActive(true);
        ColorUtility.TryParseHtmlString("#63A3CC", out colorFromHex);
        mainCamera.GetComponent<Camera>().backgroundColor = colorFromHex;
        builderScreenCamera.SetActive(false);

        // Telas
        gameScreen.SetActive(false);
        initialScreen.SetActive(false);
        calibrationScreen.SetActive(true);
        builderScreen.SetActive(false);

        // Elementos
        calibrationScreenManager.SetActive(true);
        calibrationDoneBtn.SetActive(true);
        builderScreenManager.SetActive(false);
    }

    public void BuilderScreen () {
        MainCanvas.SetActive(false);
        Solution.SetActive(false);
        // Câmeras
        builderScreenCamera.SetActive(true);
        mainCamera.SetActive(false);

        builderScreenManager.SetActive(true);
        // Telas
        gameScreen.SetActive(false);
        initialScreen.SetActive(false);
        calibrationScreen.SetActive(false);
        builderScreen.SetActive(true);

        // Elementos
        calibrationScreenManager.SetActive(false);
        calibrationDoneBtn.SetActive(false);
    }
}