using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    float enemyLifetime = 7f;
    float x, y;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private void Awake()
    {
        x = transform.position.x - 1.5f;
        y = transform.position.y + 0.4f;
    }
    private IEnumerator SpawnEnemies()
    {
        while (true) // Vòng lặp vô hạn để sinh liên tục
        {
            // Tạo enemy và đặt vị trí ngẫu nhiên
            GameObject newEnemy =Instantiate(enemyPrefab, new Vector2(x, y), Quaternion.identity);//x-2,y+0.5 so vs flower
            // Chờ đợi 2 giây
            yield return new WaitForSeconds(2f);
            Destroy(newEnemy, enemyLifetime);
        }
    }
}
