using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartbuttonController : MonoBehaviour
{
   public void onRestartButton_Click()
    {
        SceneManager.LoadScene("Level1");
    }
}
