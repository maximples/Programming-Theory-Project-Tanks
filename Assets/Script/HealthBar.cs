using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class HealthBar : MonoBehaviour
{
	public static HealthBar Instance;
	public float maxValue = 240;
	public float maxHp = 240;
	public float Hp = 240;
	public Color color = Color.red;
	public int width = 4;
	public Slider slider;
	public bool isRight;
	public TextMeshProUGUI HpPlayer;
	private static float current;
	
	void Start()
	{
		Instance = this;
		slider.fillRect.GetComponent<Image>().color = color;

		slider.maxValue = maxValue;
		slider.minValue = 0;
		current = maxValue;

		UpdateUI();
	}

	public static float currentValue
	{
		get { return current; }
	}

	void Update()
	{
		slider.maxValue = maxValue;
		if (current < 0) current = 0;
		if (current > maxValue) current = maxValue;
		slider.value = current;
		HpPlayer.text= maxHp + "/"+Hp;
	}

	void UpdateUI()
	{
		RectTransform rect = slider.GetComponent<RectTransform>();

		int rectDeltaX = Screen.width / width;
		float rectPosX = 0;

		if (isRight)
		{
			rectPosX = rect.position.x - (rectDeltaX - rect.sizeDelta.x) / 2;
			slider.direction = Slider.Direction.RightToLeft;
		}
		else
		{
			rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
			slider.direction = Slider.Direction.LeftToRight;
		}

		rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
		rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
	}

	public  void AdjustCurrentValue(float adjust)
	{
		current += adjust;
		Hp += adjust;
        if (Hp > maxHp)
        {
			Hp = maxHp;
        }
		if (Hp <= 0) { GameManager.Instance.Lose();}
	}
	public  void AddMaxHp(float add)
	{
		maxHp += add;
		maxValue += add;

	}
}