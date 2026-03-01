using UnityEngine;
using System.Collections.Generic;

public class Deeds : MonoBehaviour
{
    [System.Serializable]
    public class Deed
    {
        public string description;
        public float weight;
        public int hellCircle; // 0 for good deeds

        public Deed(string desc, float w, int circle)
        {
            description = desc;
            weight = w;
            hellCircle = circle;
        }
    }

    private List<Deed> goodDeeds = new List<Deed>();
    private List<Deed> badDeeds = new List<Deed>();

    // Selected outputs
    public string Gdeed1, Gdeed2, Gdeed3;
    public string Bdeed1, Bdeed2, Bdeed3;

    public int Bcircle1, Bcircle2, Bcircle3;

    void Start()
    {
        InitializeDeeds();
        GenerateRandomDeeds();
    }

    void InitializeDeeds()
    {
        // ---------------------
        // GOOD DEEDS (weight random 1–5)
        // ---------------------
        goodDeeds.Add(new Deed("He gave his coat to a stranger.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She confessed before being accused.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He returned stolen money with interest.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She shielded a child from harm.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He took blame to spare another.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She forgave the one who hurt her.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He fed those who could not repay him.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She refused a bribe.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He stood against a violent crowd.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She hid a hunted family.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He admitted his failure publicly.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She carried an injured man to safety.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He worked without recognition.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She repaid debt she could have escaped.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He told the truth at personal cost.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She stayed when others fled.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He protected a rival from harm.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She donated anonymously.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He broke a cycle of abuse.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She chose mercy over revenge.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He gave up wealth for justice.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She endured suffering without passing it on.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He apologized without excuse.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She rebuilt what she once destroyed.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He warned others of danger.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She testified against corruption.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He saved a life at risk to his own.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She cared for the abandoned.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("He turned himself in willingly.", Random.Range(1f, 5f), 0));
        goodDeeds.Add(new Deed("She tried, even when she failed.", Random.Range(1f, 5f), 0));

        // ---------------------
        // BAD DEEDS (weight random 1–5 + circle)
        // ---------------------
        badDeeds.Add(new Deed("He betrayed his brother for safety.", Random.Range(1f, 5f), 9));
        badDeeds.Add(new Deed("She seduced for pleasure and left ruin behind.", Random.Range(1f, 5f), 2));
        badDeeds.Add(new Deed("He ate while they starved.", Random.Range(1f, 5f), 3));
        badDeeds.Add(new Deed("She hoarded gold she would never spend.", Random.Range(1f, 5f), 4));
        badDeeds.Add(new Deed("He burned the store for insurance money.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("She faked the charity accounts.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("He struck first and enjoyed it.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("She pushed him from the ledge.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("He sold military secrets to the enemy.", Random.Range(1f, 5f), 9));
        badDeeds.Add(new Deed("She denied the soul and mocked the divine.", Random.Range(1f, 5f), 6));
        badDeeds.Add(new Deed("He lied under oath without remorse.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("She watched the assault and did nothing.", Random.Range(1f, 5f), 5));
        badDeeds.Add(new Deed("He abandoned his child in winter.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("She poisoned her rival slowly.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("He manipulated faith for profit.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("She framed an innocent man.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("He betrayed a friend to save himself.", Random.Range(1f, 5f), 9));
        badDeeds.Add(new Deed("She exploited addicts for gain.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("He incited a riot and hid.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("She forged signatures for inheritance.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("He took pleasure in another’s humiliation.", Random.Range(1f, 5f), 5));
        badDeeds.Add(new Deed("She profited from war contracts.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("He stole medicine meant for children.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("She broke sacred vows knowingly.", Random.Range(1f, 5f), 2));
        badDeeds.Add(new Deed("He refused aid to a drowning man.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("She built wealth through crushing debt.", Random.Range(1f, 5f), 4));
        badDeeds.Add(new Deed("He ordered executions to maintain power.", Random.Range(1f, 5f), 7));
        badDeeds.Add(new Deed("She exposed a hiding family to authorities.", Random.Range(1f, 5f), 9));
        badDeeds.Add(new Deed("He denied truth to protect reputation.", Random.Range(1f, 5f), 8));
        badDeeds.Add(new Deed("She would commit the same sin again without regret.", Random.Range(1f, 5f), 6));
    }

    void GenerateRandomDeeds()
    {
        // GOOD
        Gdeed1 = goodDeeds[Random.Range(0, goodDeeds.Count)].description;
        Gdeed2 = goodDeeds[Random.Range(0, goodDeeds.Count)].description;
        Gdeed3 = goodDeeds[Random.Range(0, goodDeeds.Count)].description;

        // BAD
        Deed b1 = badDeeds[Random.Range(0, badDeeds.Count)];
        Deed b2 = badDeeds[Random.Range(0, badDeeds.Count)];
        Deed b3 = badDeeds[Random.Range(0, badDeeds.Count)];

        Bdeed1 = b1.description;
        Bdeed2 = b2.description;
        Bdeed3 = b3.description;

        Bcircle1 = b1.hellCircle;
        Bcircle2 = b2.hellCircle;
        Bcircle3 = b3.hellCircle;
    }
}