using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class PersoDialog : MonoBehaviour {

    public enum Perso
    {
        Eleve,
        Natking,
        TitiPenaud,
        ChausseGravier,
        Anton
    }

    public Perso perso;
    public float distanceDialogue = 5f;

    DialogueRunner runner;
    int max;
    Transform player;

    bool IsNear
    {
        get
        {
            Vector3 diff = transform.position - player.position;
            diff.y = 0f;
            return diff.magnitude <= distanceDialogue;
        }
    }

    void Start()
    {
        runner = DialogueRunner.runner;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        IEnumerable<string> nodes = runner.dialogue.allNodes;
        max = nodes.Count(n => n.StartsWith(perso.ToString()));
    }

    public void StartDialogue()
    {
        if (perso != Perso.Anton)
        {
            Jauge.Flemme.Add(10f);
        }
        int num = Random.Range(0, max);
        runner.StartDialogue(perso.ToString() + num.ToString());
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceDialogue);
    }
}
