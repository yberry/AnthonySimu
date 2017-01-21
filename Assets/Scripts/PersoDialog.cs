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

    DialogueRunner runner;
    int max;

    void Start()
    {
        runner = DialogueRunner.runner;
        IEnumerable<string> nodes = runner.dialogue.allNodes;
        max = nodes.Count(n => n.StartsWith(perso.ToString()));

        StartDialogue();
    }

    public void StartDialogue()
    {
        int num = Random.Range(0, max);
        runner.StartDialogue(perso.ToString() + num.ToString());
    }
}
