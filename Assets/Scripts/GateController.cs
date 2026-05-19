using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    [SerializeField] private TMP_Text _gateNumberText = null;

    [SerializeField]
    private enum GateType
    {
        PositiveGate,
        NegativeGate
    }

    [SerializeField] private GateType _gateType;

    [SerializeField] private int _gateNumber;

    public int GetGateNumber()
    {
        return _gateNumber;
    }

    void Start()
    {
        RandomGateNumber(); // BAÞLANGIÇTA ÇAÐIR
    }

    private void RandomGateNumber()
    {
        switch (_gateType)
        {
            case GateType.PositiveGate:
                _gateNumber = Random.Range(1, 11); // 1-10 arasý
                break;

            case GateType.NegativeGate:
                _gateNumber = Random.Range(-10, 0); // -10 ile -1 arasý
                break;
        }

        _gateNumberText.text = _gateNumber.ToString();
    }
}
