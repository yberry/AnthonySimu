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

    List<GameObject> pornStudents;
    List<GameObject> demandStudents;

    public Activity[] studentPlanning;
    private int nextPlanning = 0;

    public bool isPornLoading = false;

    // Use this for initialization
    void Start()
    {
        students = GameObject.FindGameObjectsWithTag("Student");

        StartCoroutine(NextEvent());

        pornStudents = new List<GameObject>();
        demandStudents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopPornStudents()
    {
        foreach (GameObject pornStudent in pornStudents)
        {
            pornStudent.GetComponent<StatePatternEnnemy>().currentState.ToPatrolState();
        }

        //This clears out the list so that it is
        //empty.
        pornStudents.Clear();
        isPornLoading = false;
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
                    if (freeStudent != null)
                    {
                        freeStudent.GetComponent<StatePatternEnnemy>().currentState.ToPornLoadState();
                        pornStudents.Add( freeStudent );
                        isPornLoading = true;
                    }
                    break;

                case ActivityTypes.demand:

                    break;
            }

            Debug.Log(pornStudents[0]);
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
            if ( !pornStudents.Contains(students[i]) && !demandStudents.Contains(students[i]))
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

