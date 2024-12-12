using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private GameObject _pickable;
    [SerializeField] private GameObject _picked;

    public event Action<Item> OnPicked;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Activate();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.TryGetComponent(out Player player))
        if (other.CompareTag("Player"))
        {
            Deactivate();

            // Same same
            OnPicked?.Invoke(this);
            // Same same
            // if (OnPicked != null)
            // {
            //     OnPicked.Invoke();
            // }

        }
    }
    public void Deactivate()
    {
        _pickable.SetActive(false);
        _picked.SetActive(true);
    }

    public void Activate()
    {
        _pickable.SetActive(true);
        _picked.SetActive(false);
    }
}
