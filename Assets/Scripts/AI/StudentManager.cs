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

    public void RemoveDemandStudent(GameObject demandStudent)
    {
        demandStudents.Remove(demandStudent);
        Debug.Log(demandStudents.Count);
    }

    IEnumerator NextEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(studentPlanning[nextPlanning].timeToNext);

            Debug.Log("Picking student for activity");
            GameObject freeStudent = GetInactiveStudent();

            if (freeStudent != null)
            {
                switch (studentPlanning[nextPlanning].activity)
                {
                    case ActivityTypes.pornLoad:

                            freeStudent.GetComponent<StatePatternEnnemy>().currentState.ToPornLoadState();
                            pornStudents.Add(freeStudent);
                            isPornLoading = true;
                        
                        break;

                    case ActivityTypes.demand:

                            freeStudent.GetComponent<StatePatternEnnemy>().setNeedAnton(true);
                            demandStudents.Add(freeStudent);
                        
                        break;
                }
            }

            nextPlanning = (nextPlanning + 1) % studentPlanning.Length;
        }
    }

    GameObject GetInactiveStudent()
    {
        int i;
        i = Random.Range(0, students.Length);
        Debug.Log(i);
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

            
            if (iterations >= students.Length)
            {
                return null;
            }
            iterations++;
        }
        
        return students[i];
    }
}

