using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Slider chargeSlider;
    [SerializeField]
    float offset = 1f;
    IChargeable chargeable;
    Vector2 position;
    Camera camera;
    float sliderValue = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        chargeSlider = canvas.GetComponentInChildren<Slider>();
        chargeSlider.image.color = Color.yellow;
        canvas.enabled = false;
        camera = Camera.main;
        chargeable = GetComponent<IChargeable>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = chargeable.HoldDownTime;
        chargeSlider.value = sliderValue;
        if (sliderValue > .2f)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
        position = camera.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + offset));
        chargeSlider.transform.position = position;
    }
}
