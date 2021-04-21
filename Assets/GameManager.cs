using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public enum GameState
{
    WAIT,
    LOADING,
    PLAY,
    RESULT,
}

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update

    public int level = 1;
    private bool loaded = false;
    bool loadComplete = false;
    public GameState state;
    public List<GameObject> enemies; 
    void Start()
    {
        
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.UpdateParam();
    }

    // Update is called once per frame
    void Update()
    {
        if (loaded == false)
        {
            state = GameState.LOADING;
        }
        
        switch (state)
        {
            case GameState.WAIT:
                Time.timeScale = 0f;
                break;
            case GameState.LOADING:
                Time.timeScale = 0f;
                
                if (loadComplete == false)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        GenrateEnemy(enemies[0]);    
                    }
                    loadComplete = true;
                }
                else
                {
                    loaded = true;
                    state = GameState.PLAY;
                }
                break;
            case GameState.PLAY:
                Time.timeScale = 1.0f;
                break;
            case GameState.RESULT:
                level++;
                // NextState();
                break;
        }
    }
    
    //敵を登場させる関数
    public void GenrateEnemy(GameObject enemy)
    {
        //乱数で範囲内に敵を出現させる。
        // 0,0 , 150,150
        float min = 5f;
        float max = 145f;

        float x = Random.Range(min, max);
        float z = Random.Range(min, max);

        //0番目のモンスターを生成 連番は敵の強さと関連している　大きい＝強い
        Instantiate(enemy, new Vector3(x, 0, z), Quaternion.identity);

    }
}
