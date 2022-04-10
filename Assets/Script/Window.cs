using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum WindowType
{
    Positive, Negative
}
public class Window : MonoBehaviour
{
    [SerializeField] WindowType typeWindow;

    [SerializeField] int value;
    [SerializeField] TextMeshPro textMesh;

    void Start()
    {
        setWindowType();
        setValue();
        SetTextValue();
    }

    void setWindowType()
    {
        // if (Random.Range(1, 101) > 50)
        // {
        //     typeWindow = WindowType.Negative;
        // }
        // else
        // {
        //     typeWindow = WindowType.Positive;
        // }
    }

    void setValue()
    {
        // value = Random.Range(1, 4);
    }

    void SetTextValue()
    {
        textMesh.color = typeWindow == WindowType.Positive ? Color.green : Color.red;
        textMesh.text += value.ToString();
    }
    public WindowType TypeWindow { get => typeWindow; }
    public int Value { get => value; }
}