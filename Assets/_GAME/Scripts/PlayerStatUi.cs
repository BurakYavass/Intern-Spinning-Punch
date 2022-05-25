using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUi : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private PlayerStats _playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = _playerStats.pTotalPower;
        slider.value = _playerStats.pDefPower;
    }
    
    public void PlayerUIControl(bool control)
    {
        gameObject.SetActive(control);
    }
    
    void Update()
    {
        slider.value = _playerStats.pCurrentPower;
    }
}
