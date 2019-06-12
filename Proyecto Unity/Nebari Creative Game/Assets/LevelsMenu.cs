using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Menu_principal");
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Pruebas");
    }
}
