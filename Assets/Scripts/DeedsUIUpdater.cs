using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeedsUIUpdater : MonoBehaviour
{
    private Deeeds deedsSystem;

    [Header("Good Deed Text (Legacy UI Text)")]
    public Text goodText1;
    public Text goodText2;
    public Text goodText3;

    [Header("Bad Deed Text (Legacy UI Text)")]
    public Text badText1;
    public Text badText2;
    public Text badText3;

    void Update()
    {
        // If prefab was destroyed, re-find it
        if (deedsSystem == null)
        {
            deedsSystem = FindObjectOfType<Deeeds>();

            if (deedsSystem != null)
                UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (deedsSystem == null) return;

        List<GoodDeed> good = deedsSystem.selectedGoodDeeds;
        List<BadDeed> bad = deedsSystem.selectedBadDeeds;

        // ---- GOOD ----
        if (good.Count >= 3)
        {
            goodText1.text = good[0].deed;
            goodText2.text = good[1].deed;
            goodText3.text = good[2].deed;
        }

        // ---- BAD ----
        if (bad.Count >= 3)
        {
            badText1.text = bad[0].deed;
            badText2.text = bad[1].deed;
            badText3.text = bad[2].deed;
        }
    }
}