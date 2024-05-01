using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMainManger : MonoBehaviour
{

    public float _speed = 5;

    private SpaceShipObject _shipObject;
    public BulletMovement _bulletObject;

    public List<BulletMovement> _bulletList;

    public void Init()
    {
        _bulletList = new List<BulletMovement>();
        _shipObject = transform.GetChild(0).GetComponent<SpaceShipObject>();    
    }

    public void UpdateScript()
    {
        Vector3 moveVector = _shipObject.transform.position;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector.x = moveVector.x + (_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector.x = moveVector.x + (-_speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector.y = moveVector.y + (_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector.y = moveVector.y + (-_speed * Time.deltaTime);

        }

        if (moveVector.x > 8)
        {
            moveVector.x = 8;
        }
        if (moveVector.x < -8)
        {
            moveVector.x = -8;
        }

        if (moveVector.y > 4)
        {
            moveVector.y = 4;
        }
        if (moveVector.y < -4)
        {
            moveVector.y = -4;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            //  _bulletFiredFlag = true;
           BulletMovement temp = Instantiate(_bulletObject, _shipObject.transform.position, _shipObject.transform.rotation);

            _bulletList.Add(temp);
        }

        _shipObject.transform.position = moveVector;




        int count =  _bulletList.Count;
        for (int i = count - 1; i >= 0; i--)
        {
            Vector3 bullVector = _bulletList[i].transform.position;

            bullVector.y = bullVector.y + 5 * Time.deltaTime;

            _bulletList[i].transform.position = bullVector;

            if (_bulletList[i].transform.position.y > 10)
            {
                BulletMovement temp = _bulletList[i];
                _bulletList.RemoveAt(i);

                Destroy(temp.gameObject);
            }
        }

    }
}
