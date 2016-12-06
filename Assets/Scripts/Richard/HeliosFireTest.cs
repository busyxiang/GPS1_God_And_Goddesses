using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class HeliosFireTest : MonoBehaviour
{
	[HideInInspector]public float damageTimer = 10;
	[HideInInspector]public float damageAmount = 10;
    bool _fireCoroutineRunning = false;   // Ensures ONE coroutine is running.
    EnemyHealth script;
	[HideInInspector]public bool colorChange = false;

    void Start()
    {
        script = gameObject.GetComponent<EnemyHealth>();
    }

    void Update()
    {
        CheckFire();
    }

    public void CheckFire()
    {
        if (!_fireCoroutineRunning && script.enemyOnFire) // IF enemy on fire and aren't calculating any fire damage
        {
            _fireCoroutineRunning = true;   // Lock enemy into 1 instance of the coroutine
            colorChange = true; //initiate color change
            StartCoroutine(UpdateFire());   // Start the coroutine
        }
    }

    IEnumerator UpdateFire()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        yield return new WaitForSeconds(1);
        while (script.enemyOnFire && damageTimer >= 0 && watch.Elapsed.Seconds <= 5)     // While on fire and the damage taken is greater than 0
        {
            script.currentHealth -= damageAmount;   // Drops health
            yield return new WaitForSeconds(1);    // Waits 1 frame
        }// One of the conditions became false if it breaks past here
        watch.Stop();
        this.GetComponent<SpriteRenderer>().color = Color.white;
        colorChange = false;
        script.enemyOnFire = false;
        _fireCoroutineRunning = false;
        yield break;
    }
}