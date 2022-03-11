using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName;
    public string UserPassword;
    public string Level;
    public string Coins;
    
    public void SetCredentials(string username, string userPassword)
    {
        UserName = username;
        UserPassword = userPassword;
    }

    public void SetID(string id)
    {
        UserID = id;
    }
}
