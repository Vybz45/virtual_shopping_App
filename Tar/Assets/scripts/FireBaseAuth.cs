using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;


public class FireBaseAuth : MonoBehaviour
{
    //Firebase Variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    //Login Variables
    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public Text warningLoginState;
    public Text confirmLoginState;
    //Regstration variables

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task=> 
        {
            dependencyStatus=task.Result;
            if(dependencyStatus==DependencyStatus.Available){
                InitializeFirebase();
            }else{
                Debug.Log("could not resolve dependency "+dependencyStatus);
            }
        
        });
        
    }
    private void InitializeFirebase(){
        Debug.Log("setting Up Firebase Authentication(auth)");
        auth=FirebaseAuth.DefaultInstance;
    }
    public void LoginButton(){
        StartCoroutine(Login(emailLoginField.text,passwordLoginField.text));
    }
    private IEnumerator Login(string _email,string _password){
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email,_password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if(LoginTask.Exception!=null){
            Debug.Log("some exeptions happend");
        }else{
            user=LoginTask.Result;
            Debug.LogFormat("login..{0}  {1}",user.DisplayName,user.Email);
            warningLoginState.text="Login Successfull";
        }
    }
    private IEnumerator Register(string _email,string _pass,string _username){
        if(_username=="")warningLoginState.text="Missing Username";
        //if(passwordLoginField.text)
        var RegisterTask=auth.CreateUserWithEmailAndPasswordAsync(_email,_pass);
        yield return new WaitUntil(predicate:() => RegisterTask.IsCompleted);

        if(RegisterTask.Exception!=null){
             Debug.Log("some exeptions happend");
        }
        else{
            //user is created
            user=RegisterTask.Result;
            if(user!=null){
                UserProfile profile = new UserProfile{DisplayName=_username};
                //update the profile
                var ProfileTask =user.UpdateUserProfileAsync(profile);
                //waite task complition
                if(ProfileTask.Exception!=null){
                    //handel error
                }else{
                    //user is set
                    //return user to login screen 
                    //call UImaneger to handele panel switching
                }
            }
        }
    }
   
}
