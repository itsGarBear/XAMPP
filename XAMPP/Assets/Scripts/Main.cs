using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    public Web web;
    public UserInfo UserInfo;
    public Login login;

    public GameObject UserProfile;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        web = GetComponent<Web>();
        UserInfo = GetComponent<UserInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
