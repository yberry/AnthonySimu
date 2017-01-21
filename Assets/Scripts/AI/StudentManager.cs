using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{

    [System.Serializable]
    public enum ActivityTypes
    {
        pornLoad = 0,
        demand = 1,
    }

    [System.Serializable]
    public struct Activity
    {
        public ActivityTypes activity;
        public float timeToNext;
    }

    private GameObject[] students;
    private GameObject pornStudent, demandStudent;

    public Activity[] studentPlanning;
    private int nextPlanning = 0;

    public

    // Use this for initialization
    void Start()
    {
        students = GameObject.FindGameObjectsWithTag("Student");

        StartCoroutine(NextEvent());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(studentPlanning[nextPlanning].timeToNext);

            Debug.Log("Picking student for activity");
            switch (studentPlanning[nextPlanning].activity)
            {
                case ActivityTypes.pornLoad:

                    GameObject freeStudent = GetInactiveStudent();
                    Debug.Log(freeStudent);
                    if (freeStudent != null)
                    {
                        freeStudent.GetComponent<StatePatternEnnemy>().currentState.ToPornLoadState();
                        pornStudent = freeStudent;
                    }
                    break;

                case ActivityTypes.demand:

                    break;
            }

            nextPlanning = (nextPlanning + 1) % studentPlanning.Length;
        }
    }

    GameObject GetInactiveStudent()
    {
        int i = Random.Range(0, students.Length - 1);
        bool found = false;
        int iterations = 0;
        while (found != true)
        {
            if (students[i] != pornStudent && students[i] != demandStudent)
            {
                found = true;
            }
            else
            {
                i = (i + 1) % students.Length;
            }

            iterations++;
            if (iterations >= students.Length)
            {
                return null;
            }
        }

        return students[i];
    }
}

