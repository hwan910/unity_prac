using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]

    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 5f;

    private readonly float minY = -7f;

    [SerializeField]
    private float hp = 1f;



    public void SetMoveSpeend(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;

        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            if (hp <= 0)
            {
                if (gameObject.CompareTag("Boss"))
                {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);

            }

            Destroy(other.gameObject);
        }
    }
}
