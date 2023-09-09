using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Outscal.UnityAdvanced.Mat2.Scenes
{
    public class LobbySceneManager : MonoBehaviour
    {
        [SerializeField]
        private List<Button> levelButtons;

        [SerializeField]
        private List<int> levelScenesBuildIndices;

        private void Awake()
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                int local = i;
                levelButtons[i].onClick.AddListener(() => { LoadLevel(local); });
            }
        }

        private void LoadLevel(int index) {
            if (index < 0 || index > levelScenesBuildIndices.Count - 1)
                throw new KeyNotFoundException(index + " is out of bounds");
            SceneManager.LoadScene(levelScenesBuildIndices[index]);
        }
    }
}
