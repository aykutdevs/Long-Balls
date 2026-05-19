using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{

    [SerializeField] private GameObject _ballPrefab;


    [SerializeField] private TMP_Text _ballCountText = null;

    [SerializeField] private List<GameObject> _balls = new List<GameObject>();
    [SerializeField] private float _horizontalSpeed = 5f;
    [SerializeField] private float _forwardSpeed = 5f;   // ileri hýz
    [SerializeField] private float _horizontalLimit = 3f;

    private float _horizontal;

    private int _gateNumber;

    private int _targetCount;

    void Update()
    {
        HorizontalBallMove();
        ForwardMove();
        UpdateBallCountText();
       
    }

    private void HorizontalBallMove()
    {
        if (Input.GetMouseButton(0)) // basýlý tutulduðu sürece
        {
            _horizontal = Input.GetAxis("Mouse X");

            float _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
            _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

            transform.position = new Vector3(
                _newX,
                transform.position.y,
                transform.position.z
            );
        }
    }

    private void ForwardMove()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }

    private void UpdateBallCountText()
    {
        _ballCountText.text = _balls.Count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball Stack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z - 1f);
            _balls.Add(other.gameObject);
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            _gateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetCount = _balls.Count + _gateNumber;

            if (_gateNumber > 0)
            {
                IncreaseBallCount();
            }
            else if (_gateNumber < 0) {

                DecraseBallCount();
            }


        }
    }

    private void IncreaseBallCount()
    {
        for (int i = 0; i < _gateNumber; i++)
        {
            GameObject _newBall = Instantiate(_ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z - 1f);
            _balls.Add(_newBall);
        }

    }

    private void DecraseBallCount()
    {
        int removeCount = Mathf.Min(-_gateNumber, _balls.Count); // eksi deðer + güvenlik

        for (int i = 0; i < removeCount; i++)
        {
            GameObject ballToRemove = _balls[_balls.Count - 1]; // en sondaki top
            _balls.RemoveAt(_balls.Count - 1);
            Destroy(ballToRemove); // yok et (istersen SetActive(false) da olur)
        }
    }




}




