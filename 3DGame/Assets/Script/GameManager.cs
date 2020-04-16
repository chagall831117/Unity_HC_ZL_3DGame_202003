using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] Terrain;
    public float TerrainSpeed = 1.5f;
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
    }
}
