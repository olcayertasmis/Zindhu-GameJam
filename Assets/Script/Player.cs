using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float forwardspeed;
    [SerializeField] float horizontalspeed;
    float hor;
    Animator anim;
    public GameObject GameOverCanvas;
    public bool deadd = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(0, 0, forwardspeed * Time.deltaTime);
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * horizontalspeed * Time.deltaTime, 0, forwardspeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            anim.SetBool("jump", false);
            anim.SetBool("run", true);
        }
        if(other.gameObject.tag == "Finish")
        {
            GameOverCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Window")
        {
            float value = other.transform.parent.GetComponent<Window>().Value;
            int i;
            if (other.transform.parent.GetComponent<Window>().TypeWindow == WindowType.Positive)
            {
                i = 1;
            }
            else
            {
                i = -1;
            }
            value *= i;
            GetComponent<Growth>().Grow(value);
        }
        if (other.tag == "JumpPlace")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
        }
        if (other.tag == "Wall")
        {
            other.transform.GetComponent<Wall>().EnableRigidbody(false);
            DecreaseIncrease(-15);
            Camera.current.DOShakeRotation(0.5f, 5, 10, 10);
        }
        if (other.tag == "Drug")
        {
            float value = other.transform.GetComponent<Drug>().Value;
            int i;
            if (other.transform.GetComponent<Drug>().TypeDrug == DrugType.Positive)
            {
                i = 1;
            }
            else
            {
                i = -1;
            }
            value *= i;
            GetComponent<Growth>().Grow(value);
            Destroy(other.gameObject);
        }
        if (other.tag == "Dead")
        {
            deadd = true;
            GameOverCanvas.SetActive(true);
            GameOverCanvas.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "FAIL!";
            GameOverCanvas.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
            Invoke("dead",1f);
        }
    }

    void dead()
    {
        SceneManager.LoadScene(0);
    }

    public void DecreaseIncrease(float rate)
    {
        float scale = transform.localScale.x;
        float add = (scale * rate) / 100;

        transform.DOScale(scale + add, 1).SetEase(Ease.OutElastic);
        // GetComponent<Renderer>().material.DOColor(Color.green,0.25f).OnComplete(()=>
        // {
        //     GetComponent<Renderer>().material.DOColor(Color.yellow,0.25f);
        // });
    }
}
