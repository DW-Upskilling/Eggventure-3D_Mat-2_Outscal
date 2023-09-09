using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Outscal.UnityAdvanced.Mat2.Scenes
{
    public class LevelSceneManager : MonoBehaviour
    {
        [SerializeField]
        private Button restartButton;
        [SerializeField]
        private Button resumeButton;
        [SerializeField]
        private Button mainMenuButton;

        [SerializeField]
        private List<GameObject> onEnableGameObjects;
        [SerializeField]
        private List<GameObject> onDisableGameObjects;

        private bool isPaused;

        private void Awake()
        {
            isPaused = false;

            restartButton.onClick.AddListener(RestartButtonAction);
            resumeButton.onClick.AddListener(ResumeButtonAction);
            mainMenuButton.onClick.AddListener(MainMenuButtonAction);
        }

        private void Start()
        {
            TogglePauseScreen();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                TogglePauseScreen();
            }
        }

        private void TogglePauseScreen()
        {
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else
            {
                // Hide the cursor and lock it to the center of the screen
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            onEnableGameObjects.ForEach(e => e.SetActive(isPaused));
            onDisableGameObjects.ForEach(e => e.SetActive(!isPaused));
        }

        private void RestartButtonAction() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void ResumeButtonAction()
        {
            isPaused = false;
            TogglePauseScreen();
        }

        private void MainMenuButtonAction() {
            SceneManager.LoadScene(0);
        }
    }
}
