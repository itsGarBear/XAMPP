using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    public InputField userNameInput;
    public InputField passwordInput;
    public InputField confirmPasswordInput;
    public Button submitBtn;
    // Start is called before the first frame update
    void Start()
    {
        submitBtn.onClick.AddListener(() =>
        {
            if (passwordInput.text == confirmPasswordInput.text)
            {
                StartCoroutine(Main.instance.web.RegisterUser(userNameInput.text, passwordInput.text));
            }
            else
            {
                print("Passwords do not match. Try Again!");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
