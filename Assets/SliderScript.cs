using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _sliderText;

    //[SerializeField] private RobotPart robotPart;
    public float angle;
    [SerializeField] private RobotDriver _robotDriver;
    
    // Le slider va modifier l'angle de rotation du robot
    // Start is called before the first frame update
    void Start()
    {

        _sliderText.text = (gameObject.name);
        _slider.onValueChanged.AddListener((v) =>{
            _sliderText.text = v.ToString(gameObject.name + "0.00");
            /*robotPart.Rotate((v - angle));
            angle = v; */
            _robotDriver.SetTarget(v);
        }
        );


    }

    // Update is called once per frame
    void Update()
    {

        // on récupère le valeur du slider pour détecter si on recule ou on avance dans le slider
    }
}
