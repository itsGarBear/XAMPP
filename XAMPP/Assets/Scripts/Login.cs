using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField userNameInput;
    public InputField passwordInput;
    public Button loginBtn;
    // Start is called before the first frame update
    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            StartCoroutine(Main.instance.web.Login(userNameInput.text, passwordInput.text));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
