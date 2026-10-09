using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP = 100f;
    public float displayHP = 100f;
    public float dmg = 20f;
    public Image HPBar;

    void Update()
    {
        displayHP = Mathf.Lerp(displayHP, currentHP, Time.deltaTime * 5f);
        HPBar.fillAmount = displayHP / maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0f);

        if (currentHP <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
