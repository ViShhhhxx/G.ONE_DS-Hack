using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class User
{
    public string name;
    public string id;
    public int age;
    public float weight;
    public float height;

    public User(string name, string id, int age, float weight, float height)
    {
        this.name = name;
        this.id = id;
        this.age = age;
        this.weight = weight;
        this.height = height;
    }
    public void Save()
    {
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetString("ID", id);
        PlayerPrefs.SetInt("Age", age);
        PlayerPrefs.SetFloat("Weight", weight);
        PlayerPrefs.SetFloat("Height", height);
        PlayerPrefs.SetInt("Speed", 1);
    }


}

public class CreateNewUser : MonoBehaviour
{
    public InputField Name, id, age, weight, height; 
    public void OnCreateNewUser()
    {
        if(Name.text == "" || id.text == "" || age.text == "" || weight.text == "" || height.text == "")
        {
            Debug.Log("Please fill all the fields");
            return;
        }else
        {
            User newUser = new User(Name.text, id.text, int.Parse(age.text), int.Parse(weight.text), int.Parse(height.text));
            newUser.Save();
        }
    }
}
