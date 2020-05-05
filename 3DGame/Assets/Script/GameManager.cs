using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Transform[] Terrain;
    public float TerrainSpeed = 1.5f;
    [Header("畫面物件")]
    public GameObject Win, Lose;
    public bool PassLv;
    public bool Dead;
    public void MoveTerrain()
    {
        //
        //Terrain[0].Translate(0, 0, -TerrainSpeed * Time.deltaTime);
        //Terrain[1].Translate(0, 0, -TerrainSpeed * Time.deltaTime);
        //if (Terrain[0].position.z <= -100)
            //Terrain[0].position = new Vector3(0, 0, Terrain[1].position.z + 100);
        //if (Terrain[1].position.z <= -100)
            //Terrain[1].position = new Vector3(0, 0, Terrain[0].position.z + 100);
        for (int i = 0; i < Terrain.Length; i++)
        {//如果地板.Z小於100
            if (Terrain[i].position.z <= -100)
            {//另一塊地板的前方100位置
            Terrain[i].position =  new Vector3(0, 0, Terrain[1 - i].position.z + 100);
            }//移動
        Terrain[i].Translate(0, 0, -TerrainSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        MoveTerrain();
        if (Dead) LoseGame();
    }
    /// <summary>
    /// 贏得遊戲
    /// </summary>
    public void WinGame()
    {
        Win.SetActive(true);
        PassLv = true;
    }
    /// <summary>
    /// 輸掉遊戲
    /// </summary>
    public void LoseGame()
    {
        Lose.SetActive(true);
    }
    /// <summary>
    /// 重新開始
    /// </summary>
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// 關閉遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 前往下一關
    /// </summary>
    public void NextLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
