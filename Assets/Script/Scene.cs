using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void SceneLoader(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

        public void Keluar()
        {
            Debug.Log ("KAMU TELAH KELUAR!");
            Application.Quit();
    }
}
