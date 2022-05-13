using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject michinegunPrefab, handgunPrefab;

    private void Awake()
    {
        instance = this;
    }

    public PlayerController GetPlayerController() => playerController;

    public GameObject GetMichineGun() => michinegunPrefab;
    public GameObject GetHandGun() => handgunPrefab;
}
