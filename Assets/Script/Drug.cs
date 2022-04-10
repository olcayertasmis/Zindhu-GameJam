using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrugType
{
    Positive, Negative
}
public class Drug : MonoBehaviour
{

    [SerializeField] DrugType typeDrug;

    [SerializeField] int value;
    public DrugType TypeDrug { get => typeDrug; }
    public int Value { get => value; }
}
