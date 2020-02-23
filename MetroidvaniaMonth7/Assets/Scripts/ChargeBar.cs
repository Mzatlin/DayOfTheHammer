using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    [SerializeField]
    Slider chargeSlider;
    IChargeable chargeable;
    Vector2 Position;
    Camera camera;
    float sliderValue = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        chargeSlider.enabled = false;
        camera = Camera.main;
        chargeable = GetComponent<IChargeable>();

    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = chargeable.HoldDownTime;
        chargeSlider.value = sliderValue;
        if(sliderValue > .1f)
        {
            chargeSlider.enabled = true;
        }
        else
        {
            chargeSlider.enabled = false;
        }
        Position = camera.WorldToScreenPoint(transform.position);
        chargeSlider.transform.position = Position;
    }
}
