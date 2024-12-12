using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _goodGameText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => HideGoodGame(); 
    
    public void HideGoodGame() => _goodGameText.SetActive(false);
    public void ShowGoodGame() => _goodGameText.SetActive(true);
    
}
