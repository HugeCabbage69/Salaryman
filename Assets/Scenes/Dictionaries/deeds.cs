using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class GoodDeed
{
    public string deed;
    public float weight = 0.5f;

    public GoodDeed(string d, float w) { deed = d; weight = w; }
}

[System.Serializable]
public class BadDeed
{
    public string deed;
    public int lvl;
    public float weight = 0.5f;

    public BadDeed(string d, int l, float w) { deed = d; lvl = l; weight = w; }
}

public class Deeds : MonoBehaviour
{
    [Header("Deed Pools")]
    public List<GoodDeed> goodDeedsPool = new List<GoodDeed>();
    public List<BadDeed> badDeedsPool = new List<BadDeed>();

    [Header("Current Selection")]
    public List<GoodDeed> selectedGoodDeeds = new List<GoodDeed>();
    public List<BadDeed> selectedBadDeeds = new List<BadDeed>();

    void Start()
    {

        if (goodDeedsPool.Count == 0) PopulateDefaultDeeds();
    }

    void OnEnable()
    {
        SelectDeeds();
    }

    public void SelectDeeds()
    {
        selectedGoodDeeds.Clear();
        selectedBadDeeds.Clear();

        int goodCount = Random.Range(0, 4);
        int badCount = Random.Range(0, 4);

       
        if (goodCount == 0 && badCount == 0)
        {
            if (Random.value < 0.5f) goodCount = 1;
            else badCount = 1;
        }

        List<GoodDeed> tempGoodPool = new List<GoodDeed>(goodDeedsPool);
        for (int i = 0; i < goodCount && tempGoodPool.Count > 0; i++)
        {
            int index = GetWeightedRandomIndex(tempGoodPool, d => d.weight);
            selectedGoodDeeds.Add(tempGoodPool[index]);
            tempGoodPool.RemoveAt(index);
        }

        List<BadDeed> tempBadPool = new List<BadDeed>(badDeedsPool);
        for (int i = 0; i < badCount && tempBadPool.Count > 0; i++)
        {
            int index = GetWeightedRandomIndex(tempBadPool, d => d.weight);
            selectedBadDeeds.Add(tempBadPool[index]);
            tempBadPool.RemoveAt(index);
        }
    }

    
    private int GetWeightedRandomIndex<T>(List<T> pool, System.Func<T, float> getWeight)
    {
        float total = 0f;
        foreach (var item in pool)
            total += getWeight(item);

        float roll = Random.Range(0f, total);
        float cumulative = 0f;

        for (int i = 0; i < pool.Count; i++)
        {
            cumulative += getWeight(pool[i]);
            if (roll <= cumulative)
                return i;
        }

        return pool.Count - 1; 

    private void PopulateDefaultDeeds()
    {
        // Good Deeds
        goodDeeds.Add(("He gave his coat to a stranger.", 0.5f));
        goodDeeds.Add(("She confessed before being accused.", 0.5f));
        goodDeeds.Add(("He returned stolen money with interest.", 0.5f));
        goodDeeds.Add(("She shielded a child from harm.", 0.5f));
        goodDeeds.Add(("He took blame to spare another.", 0.5f));
        goodDeeds.Add(("She forgave the one who hurt her.", 0.5f));
        goodDeeds.Add(("He fed those who could not repay him.", 0.5f));
        goodDeeds.Add(("She refused a bribe.", 0.5f));
        goodDeeds.Add(("He stood against a violent crowd.", 0.5f));
        goodDeeds.Add(("She hid a hunted family.", 0.5f));
        goodDeeds.Add(("He admitted his failure publicly.", 0.5f));
        goodDeeds.Add(("She carried an injured man to safety.", 0.5f));
        goodDeeds.Add(("He worked without recognition.", 0.5f));
        goodDeeds.Add(("She repaid debt she could have escaped.", 0.5f));
        goodDeeds.Add(("He told the truth at personal cost.", 0.5f));
        goodDeeds.Add(("She stayed when others fled.", 0.5f));
        goodDeeds.Add(("He protected a rival from harm.", 0.5f));
        goodDeeds.Add(("She donated anonymously.", 0.5f));
        goodDeeds.Add(("He broke a cycle of abuse.", 0.5f));
        goodDeeds.Add(("She chose mercy over revenge.", 0.5f));
        goodDeeds.Add(("He gave up wealth for justice.", 0.5f));
        goodDeeds.Add(("She endured suffering without passing it on.", 0.5f));
        goodDeeds.Add(("He apologized without excuse.", 0.5f));
        goodDeeds.Add(("She rebuilt what she once destroyed.", 0.5f));
        goodDeeds.Add(("He warned others of danger.", 0.5f));
        goodDeeds.Add(("She testified against corruption.", 0.5f));
        goodDeeds.Add(("He saved a life at risk to his own.", 0.5f));
        goodDeeds.Add(("She cared for the abandoned.", 0.5f));
        goodDeeds.Add(("He turned himself in willingly.", 0.5f));
        goodDeeds.Add(("She tried, even when she failed.", 0.5f));

        // Bad Deeds
        badDeeds.Add(("He betrayed his brother for safety.", 9, 0.5f));
        badDeeds.Add(("She seduced for pleasure and left ruin behind.", 2, 0.5f));
        badDeeds.Add(("He ate while they starved.", 3, 0.5f));
        badDeeds.Add(("She hoarded gold she would never spend.", 4, 0.5f));
        badDeeds.Add(("He burned the store for insurance money.", 8, 0.5f));
        badDeeds.Add(("She faked the charity accounts.", 8, 0.5f));
        badDeeds.Add(("He struck first and enjoyed it.", 7, 0.5f));
        badDeeds.Add(("She pushed him from the ledge.", 7, 0.5f));
        badDeeds.Add(("He sold military secrets to the enemy.", 9, 0.5f));
        badDeeds.Add(("She denied the soul and mocked the divine.", 6, 0.5f));
        badDeeds.Add(("He lied under oath without remorse.", 8, 0.5f));
        badDeeds.Add(("She watched the assault and did nothing.", 5, 0.5f));
        badDeeds.Add(("He abandoned his child in winter.", 7, 0.5f));
        badDeeds.Add(("She poisoned her rival slowly.", 7, 0.5f));
        badDeeds.Add(("He manipulated faith for profit.", 8, 0.5f));
        badDeeds.Add(("She framed an innocent man.", 8, 0.5f));
        badDeeds.Add(("He betrayed a friend to save himself.", 9, 0.5f));
        badDeeds.Add(("She exploited addicts for gain.", 8, 0.5f));
        badDeeds.Add(("He incited a riot and hid.", 7, 0.5f));
        badDeeds.Add(("She forged signatures for inheritance.", 8, 0.5f));
        badDeeds.Add(("He took pleasure in another's humiliation.", 5, 0.5f));
        badDeeds.Add(("She profited from war contracts.", 7, 0.5f));
        badDeeds.Add(("He stole medicine meant for children.", 8, 0.5f));
        badDeeds.Add(("She broke sacred vows knowingly.", 2, 0.5f));
        badDeeds.Add(("He refused aid to a drowning man.", 7, 0.5f));
        badDeeds.Add(("She built wealth through crushing debt.", 4, 0.5f));
        badDeeds.Add(("He ordered executions to maintain power.", 7, 0.5f));
        badDeeds.Add(("She exposed a hiding family to authorities.", 9, 0.5f));
        badDeeds.Add(("He denied truth to protect reputation.", 8, 0.5f));
        badDeeds.Add(("She would commit the same sin again without regret.", 6, 0.5f));
    }
}