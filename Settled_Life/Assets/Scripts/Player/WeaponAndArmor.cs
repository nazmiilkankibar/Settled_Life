using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAndArmor : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> armors = new List<GameObject>();

    public Transform weaponSocket;

    private void Start()
    {
        ChangeWeapon(PlayerPrefs.GetInt("WeaponUpgrade"));
    }
    public void ChangeWeapon(int index)
    {
        if (weaponSocket.transform.childCount > 0)
        {
            Destroy(weaponSocket.GetChild(0).gameObject);
        }
        GameObject weapon = Instantiate(weapons[index], weaponSocket);
        //weapon.SetActive(true);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.transform.localScale = Vector3.one;
        //for (int i = 0; i < weapons.Count; i++)
        //{
        //    if (i != index)
        //    {
        //        weapons[i].SetActive(false);
        //    }
        //}
    }
    public void ChangeArmor(int index)
    {
        for (int i = 0; i < armors.Count; i++)
        {
            armors[i].SetActive(false);
        }
        armors[index].SetActive(true);
    }
}
