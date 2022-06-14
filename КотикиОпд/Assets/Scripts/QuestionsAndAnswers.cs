using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class QuestionsAndAnswers : MonoBehaviour
{
    public Flowchart flowchart;
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject playButton;
    public GameObject testPanel;
    public Text moneyText;
    public Animator answerAnim;
    public AudioSource moneyAudioSource;
    public GameObject panelEndDay;

    List<object> qList;
    QuestionList crntQ;
    private int numberQuestion;

    private int countCorrectAns;
    private int countIncorrectAns;
    private SaveAndLoadNewScene saveAndLoadNewScene;

    private void Awake()
    {
        flowchart.SetStringVariable("late", PlayerPrefs.GetString("Late"));
        saveAndLoadNewScene = gameObject.GetComponent<SaveAndLoadNewScene>();
    }

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        QuestionGenerate();
        testPanel.SetActive(true);
        playButton.SetActive(false);
    }

    public void QuestionGenerate()
    {
        qList = new List<object>(questions);

        if (numberQuestion < questions.Length)
        {
            crntQ = qList[numberQuestion] as QuestionList;
            List<string> answers = new List<string>(crntQ.answers);
            qText.text = questions[numberQuestion].question;

            for (var i = 0; i < 4; i++)
            {
                var rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }

            numberQuestion++;
        }
        else
        {
            testPanel.SetActive(false);
            if (countCorrectAns >= countIncorrectAns)
            {
                print("получил монеты");
                moneyText.text = (int.Parse(moneyText.text) + 110).ToString();
                panelEndDay.transform.GetChild(0).GetComponent<Text>().text = "Премия: +110 котокоинов";
            }
            else
            {
                print("не получил монеты!");
                panelEndDay.transform.GetChild(0).GetComponent<Text>().text = "Премия: отсутствует";
            } 

            moneyAudioSource.Play();
            moneyText.text = (int.Parse(moneyText.text) + 730).ToString();
            panelEndDay.SetActive(true);
            


            //saveAndLoadNewScene.LoadNewScene();

        }
    }

    public void CheckAnswerButton(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) StartCoroutine(TrueOrFalse(true));
        else StartCoroutine(TrueOrFalse(false));
    }


    IEnumerator TrueOrFalse(bool check)
    {
        //yield return new WaitForSeconds(1);

        if (check)
        {
            answerAnim.SetTrigger("correctAns");

            QuestionGenerate();
            countCorrectAns++;  
            yield break;
        }
        else
        {
            answerAnim.SetTrigger("incorrectAns"); 
            QuestionGenerate();
            countIncorrectAns++;
            yield break;
        }
    }

    [System.Serializable]
    public class QuestionList
    {
        public string question;
        public string[] answers = new string[4];
    }
}
