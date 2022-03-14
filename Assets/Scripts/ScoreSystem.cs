using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private TMP_Text ScoreText;

    private float score;

    private void Update()
    {

        score += Time.deltaTime *scoreMultiplier;
        ScoreText.text = Mathf.FloorToInt(score).ToString();
    }
}
