using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outscal.UnityAdvanced.Mat2.Scenes
{
    public class InitialSceneManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                LoadLevelScene();
            }
        }

        private void LoadLevelScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
