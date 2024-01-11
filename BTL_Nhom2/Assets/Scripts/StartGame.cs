using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadMap1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void LoadMap2()
    {

        SceneManager.LoadScene("Map2");
    }
    public void LoadMap3()
    {

        SceneManager.LoadScene("Map3");
    }
    public void LoadMap4()
    {

        SceneManager.LoadScene("Map4");
    }
    public void LoadMap5()
    {

        SceneManager.LoadScene("Map5");
    }
    public void thoat()
    {
        SceneManager.LoadScene("StartGame");
    }
    
    public void quit()
    {
        Application.Quit();
    }

}
