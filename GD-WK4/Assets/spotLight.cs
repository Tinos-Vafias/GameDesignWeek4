using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotlightFollow2D : MonoBehaviour
{
    public Transform player; 
    public float lightIntensityIncrease = 0.5f; 
    public float maxIntensity = 2f; //max bright
    public float minIntensity = 0.5f; //min bright
    public float radiusIncrease = 1f; //inc factor
    public float maxRadius = 5f; //max radius
    public float minRadius = 0.5f; //min radius
    private Light2D spotlight;

    void Start()
    {
        spotlight = GetComponent<Light2D>();
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spotlight.intensity = Mathf.Min(spotlight.intensity + lightIntensityIncrease, maxIntensity);
        }

        spotlight.intensity = Mathf.Max(spotlight.intensity - Time.deltaTime * 0.5f, minIntensity);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            spotlight.pointLightOuterRadius = Mathf.Min(spotlight.pointLightOuterRadius + radiusIncrease * Time.deltaTime, maxRadius);
        }
        else
        {
            spotlight.pointLightOuterRadius = Mathf.Max(spotlight.pointLightOuterRadius - radiusIncrease * Time.deltaTime * 2f, minRadius);
        }
    }
}
