using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ketHopEnemy : MonoBehaviour
{
    public GameObject enemyUltra;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QUAIVAT"))
        {
            // Xóa hai quái vật cũ
            Destroy(gameObject);
            Destroy(other.gameObject);

            // Tạo ra một quái vật mới
            GameObject newEnemy = Instantiate(enemyUltra, transform.position, Quaternion.identity);

            //Phóng to vật thể
            // Transform Enemy = newEnemy.transform;
            // Enemy.localScale = new Vector3(1.5f, 1.5f, 0f);


            // // Cập nhật kích thước của Collider2D
            // BoxCollider2D spawnedObjectCollider = newEnemy.GetComponent<BoxCollider2D>();
            // if (spawnedObjectCollider != null)
            // {
            //     spawnedObjectCollider.size = Enemy.localScale;
            // }
        }
    }

}
