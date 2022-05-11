using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
   
    private float speed = 10;
    private float turnSpeed = 45;
    private float turnSpeedTurrent = 0.5f;
    private float turnSpeedGun = 0.1f;
    private float horizontalInput;
    private float forwardInput;
    private float Cd=2f;
    public int misselsCount=2;
    public Vector3 targetPosition;
    public GameObject gun;
    public GameObject turrent;
    public GameObject turrentLook;
    public GameObject bullet;
    public GameObject misssile;
    public GameObject misssileGun;
    private bool stopTurrent = true;
    private bool stopGun = true;
    private bool reloadGun_1 = false;
    public static float attack=10;
    public ParticleSystem gunFire;
    private AudioSource playerAudio;
    public AudioClip fireAudio;
    public TextMeshProUGUI misselsCountText;
    public TextMeshProUGUI News;

    // Start is called before the first frame update
    void Start()
    {
        misselsCountText.text = "Ракеты: " + misselsCount;
        playerAudio = GetComponent<AudioSource>();
        GetLookPosition();
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        
    }
    // Update is called once per frame
    void Update()
    {
        RotationTurrent();
        GetLookPosition();
        if (Input.GetMouseButtonDown(0))
        {
            if (!reloadGun_1)
            {
                reloadGun_1 = true;
                playerAudio.PlayOneShot(fireAudio, 1.0f);
                gun.transform.localPosition = new Vector3(0, 0.59f, 1.56f);
                gunFire.Play();
                Instantiate(bullet, gunFire.transform.position, gun.transform.rotation);
                StartCoroutine(ReloadGun_1());
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (misselsCount > 0)
            {
                misselsCount--;
                Instantiate(misssile, misssileGun.transform.position, gun.transform.rotation);
                misselsCountText.text = "Ракеты: " + misselsCount;
            }
        
        }

        //if(gun.transform.position.y> -1.7)
        //{ gun.transform.Translate(Vector3.up * 0.05f); }
    }
    private void RotationTurrent()
    {

        if (turrentLook.transform.rotation.eulerAngles.y + 1 >= turrent.transform.rotation.eulerAngles.y && turrent.transform.rotation.eulerAngles.y >= turrentLook.transform.rotation.eulerAngles.y - 1)
        {
            stopTurrent = true;
        }
        if (turrentLook.transform.rotation.eulerAngles.x < 10)
        {
            if (turrentLook.transform.rotation.eulerAngles.x + 0.1f >= gun.transform.rotation.eulerAngles.x && gun.transform.rotation.eulerAngles.x >= turrentLook.transform.rotation.eulerAngles.x - 0.1f)
            {
                stopGun = true;
            }
        }

        if (!stopGun)
        {
            if (turrentLook.transform.rotation.eulerAngles.x < 10 && gun.transform.rotation.eulerAngles.x < turrentLook.transform.rotation.eulerAngles.x)
            {
                gun.transform.Rotate(Vector3.right * turnSpeedGun);
            }
            else
            {
                if (turrentLook.transform.rotation.eulerAngles.x < 10 && gun.transform.rotation.eulerAngles.x > turrentLook.transform.rotation.eulerAngles.x )
                {
                    gun.transform.Rotate(Vector3.left * turnSpeedGun);
                }
            }

        }

        if (!stopTurrent)
        {
            if (turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y > 0 && turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y < 180)
            {
                turrent.transform.Rotate(Vector3.down * turnSpeedTurrent);
            }
            else
            {
                if (turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y < 0 && turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y > -180)
                {
                    turrent.transform.Rotate(Vector3.up * turnSpeedTurrent);
                }

                else
                {
                    if (turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y > 0 && turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y < 180)
                    {
                        turrent.transform.Rotate(Vector3.down * turnSpeedTurrent);
                    }
                    else
                    {
                        if (turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y > 0 && turrent.transform.rotation.eulerAngles.y - turrentLook.transform.rotation.eulerAngles.y < 180)
                        {
                            turrent.transform.Rotate(Vector3.down * turnSpeedTurrent);
                        }
                        else
                        {
                            if (turrent.transform.rotation.eulerAngles.y < 180)
                            {
                                turrent.transform.Rotate(Vector3.down * turnSpeedTurrent);
                            }
                            else
                            {
                                if (turrent.transform.rotation.eulerAngles.y > 180)
                                {
                                    turrent.transform.Rotate(Vector3.up * turnSpeedTurrent);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
    IEnumerator ReloadGun_1()
    {
        yield return new WaitForSeconds(Cd);
        reloadGun_1 = false;
        gun.transform.localPosition = new Vector3(0, 0.59f, 1.71f);
    }
    
    private void GetLookPosition()
    {
       
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
           {
              targetPosition = hit.point;
              turrentLook.transform.LookAt(targetPosition);

           }
         stopTurrent = false;
         stopGun = false;    
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire5"))
        {
            HealthBar.Instance.AdjustCurrentValue(-10* SaveData.Instance.difficultyLevel);
        }
        if(other.gameObject.CompareTag("Fire1"))
        {
            HealthBar.Instance.AdjustCurrentValue(-1);
        }
        if (other.gameObject.CompareTag("Missile20"))
        {
            HealthBar.Instance.AdjustCurrentValue(-20* SaveData.Instance.difficultyLevel);
        }
        if (other.gameObject.CompareTag("CdUp"))
        {

            Cd = Cd - 0.5f;
            Destroy(other.gameObject);
            News.text = News.text + "скорость перезарядки увеличена\n";
            StartCoroutine(DeleteText());
        }
        if (other.gameObject.CompareTag("MaxHpUp"))
        {

            HealthBar.Instance.AddMaxHp(20);
            Destroy(other.gameObject);
            News.text = News.text + "Хп увеличено\n";
            StartCoroutine(DeleteText());
        }
        if (other.gameObject.CompareTag("MissileAdd"))
        {

            misselsCount = misselsCount + 2;
            misselsCountText.text = "Ракеты: " + misselsCount;
            Destroy(other.gameObject);
            News.text = News.text + "подобрал ракеты\n";
            StartCoroutine(DeleteText());
        }

        if (other.gameObject.CompareTag("Repair"))
        {

            HealthBar.Instance.AdjustCurrentValue(40);
            Destroy(other.gameObject);
            News.text = News.text + "ремонт произведён\n";
            StartCoroutine(DeleteText());

        }
        if (other.gameObject.CompareTag("SpeedUp"))
        {

            speed= speed+2;
            Destroy(other.gameObject);
            News.text = News.text + "скорость машины увеличена\n";
            StartCoroutine(DeleteText());
        }
    }
    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(3);
        News.text =  "";
    }

}

