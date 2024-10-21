using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // SerializeField 사용하면 에디터에서 변수로 넣을 수 있음
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;


    void Start()
    {
        Destroy(gameObject, 1f);
    }


    // Update is called once per frame
    void Update()
    {

        transform.position += moveSpeed * Time.deltaTime * Vector3.up;
    }
}
