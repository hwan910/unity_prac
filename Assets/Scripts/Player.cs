using UnityEngine;
public class Player : MonoBehaviour
{

    // SerializeField 사용하면 에디터에서 변수로 넣을 수 있음
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShootTime = 0f;





    // Update is called once per frame 
    void Update()
    {
        // 키보드 입력 이벤트1
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalIntput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new(horizontalInput, 0f, 0f);
        // transform.position += moveSpeed * Time.deltaTime * moveTo;

        // or (둘중 하나 사용 )

        // 키보드 입력 이벤트2
        // Vector3  moveTo  =new(moveSpeed * Time.deltaTime,0,0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // }else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }


        // 마우스 드래그 이벤트
        // Log   Debug.Log(mousePos);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);


        if (!GameManager.instance.isGameOver)
        {

            Shoot();
        }

    }

    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);

            lastShootTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);


        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }


}
