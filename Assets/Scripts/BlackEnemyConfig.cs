using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackEnemyConfig : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        DataPost dp = GetComponent<DataPost>();
        if (col.gameObject.tag == "Player")
        {
            string parent = gameObject.transform.parent.name;
            Die();
            dp.DeathReason = parent;
            dp.Send();
        }
    }

    private void Die()
    {
        BoxCollider2D boxCollider2D = new BoxCollider2D();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
