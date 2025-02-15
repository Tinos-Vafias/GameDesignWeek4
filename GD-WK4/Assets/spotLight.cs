using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SpotlightFollow2D : MonoBehaviour
{
    public Transform player; 
    public float lightIntensityIncrease = 0.5f; 
    public float maxIntensity = 2f;
    public float minIntensity = 0.5f; 
    public float radiusIncrease = 1f; 
    public float maxRadius = 5f;
    public float minRadius = 0.5f; 

    private Light2D spotlight;
    private float boostTime;
    private float cooldownTimer;

    [SerializeField] private Slider boostBar;
    private bool isOnCooldown = false;
    private float maxBoostTime = 15f;
    private float cooldownTime = 15f;

    void Start()
    {
        boostBar.gameObject.SetActive(true);
        spotlight = GetComponent<Light2D>();
        boostBar.maxValue = maxBoostTime;
        boostBar.value = 0;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        spotlight.intensity = Mathf.Max(spotlight.intensity - Time.deltaTime * 0.5f, minIntensity);


        if (Input.GetKey(KeyCode.LeftShift) && !isOnCooldown)
        {
            spotlight.pointLightOuterRadius = Mathf.Min(spotlight.pointLightOuterRadius + radiusIncrease * Time.deltaTime, maxRadius);
            boostTime += Time.deltaTime;
            boostBar.value = boostTime;
            Debug.Log("BOOST IS ON " + boostTime);
        }
        else if(isOnCooldown || !Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Lights are low");
            spotlight.pointLightOuterRadius = Mathf.Max(spotlight.pointLightOuterRadius - radiusIncrease * Time.deltaTime * 2f, minRadius);

            if (isOnCooldown)
        {
            Debug.Log("cool down is on " + cooldownTimer);
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
                boostTime = 0;  
                boostBar.value = 0;
            }
            return;
        }
        }

        if (boostTime >= maxBoostTime)
        {
            isOnCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
}
