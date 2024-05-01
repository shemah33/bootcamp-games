using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public string _stageName = "Stage Zero";

    public GMBaseState _currentState;

    public InitState _initStaet = new InitState();
    public LoadDataState _loadStaet = new LoadDataState();

    public PlayerMainManger _playerManager;

    public void SwitchState(GMBaseState nextState)
    {
        _currentState.OnExitState(this);
        _currentState = nextState;
        _currentState.OnEnterState(this);
    }

    public void InitStateOnEnterState()
    {
        Debug.Log("this is on Enter for init State");
        SwitchState(_loadStaet);
    }

    public void InitStateOnUpdateState()
    {
        Debug.Log("this is on Update for init State");
    }

    public void InitStateOnExitState()
    {
        Debug.Log("this is on Exit for init State");
    }

    public void DataLoadStateOnEnterState()
    {
        Debug.Log("this is on Enter for Load Data State");
    }

    public void DataLoadStateOnUpdateState()
    {
        Debug.Log("this is on Update for Load Data State");
      //  _playerManager.UpdateScript();
    }

    public void DataLoadStateOnExitState()
    {
        Debug.Log("this is on Exit for Load Data State");
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _currentState = _initStaet;
        _initStaet.OnEnterState(this);
    }

    private void Start()
    {
        _playerManager = GameObject.FindAnyObjectByType<PlayerMainManger>();

        _playerManager.Init();
    }

    public void Update()
    {
        _currentState.OnUpdateState(this);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(_loadStaet);
        }
    }
}
