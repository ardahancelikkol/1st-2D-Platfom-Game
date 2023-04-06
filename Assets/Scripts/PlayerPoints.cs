using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    private AudioSource _audio;

    public void Awake()
    {
        _audio= GetComponent<AudioSource>();
        _text.text = score.totalscore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas")) ;
        {
            _audio.Play();
            Destroy(other.gameObject);
            score.totalscore++;
            _text.text = score.totalscore.ToString();
        }
    }
}
