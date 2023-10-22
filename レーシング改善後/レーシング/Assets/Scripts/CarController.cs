using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private float horizontalInput;
    public static float verticalInput;
    public static bool begin;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        begin=false;
    }
    void Start(){
        Invoke("Begin", 3);
    }
    void Begin(){
        verticalInput = 1;
        begin=true;
    }
    private void Update()
    {
        // キー入力の取得
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //Debug.Log(verticalInput);
    }

    private void FixedUpdate()
    {
        // 車の移動
        MoveCar();
        // 車の回転
        RotateCar();
    }

    private void MoveCar()
    {
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void RotateCar()
    {
        float rotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion rotationQuaternion = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * rotationQuaternion);
    }
}
