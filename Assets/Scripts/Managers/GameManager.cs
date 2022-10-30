using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.Managers
{
    public class GameManager : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            StartCoroutine(LoadLevel(name));
        }

        IEnumerator LoadLevel(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }
    }
}