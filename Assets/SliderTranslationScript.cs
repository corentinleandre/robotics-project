using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderTranslationScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _sliderText;

    //[SerializeField] private RobotPart robotPart;
    //public float translation;
    [SerializeField] private RobotDriverTrans _robotDriverTrans;
    
    [SerializeField] private TextMeshProUGUI _pos;
    

    
    // Le slider va modifier  de translation du robot
    // Start is called before the first frame update
    void Start()
    {

        _sliderText.text = (gameObject.name);
        _slider.onValueChanged.AddListener((v) => {
            _sliderText.text = v.ToString(gameObject.name + "0.00");
            /*robotPart.Translate(new Vector3(0, 0, v - translation));
            translation = v;*/
            _robotDriverTrans.SetTarget(v);

        }

        );


    }

    // Update is called once per frame
    void Update()
    {
    
        // on récupère le valeur du slider pour détecter si on recule ou on avance dans le slider
    }
}
