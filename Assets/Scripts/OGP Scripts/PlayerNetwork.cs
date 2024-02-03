using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    float moveSpeed = 5f;

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);



    private void Update()
    {
        Debug.Log(OwnerClientId + ";" + "Random Number is : " + randomNumber.Value);

        if (!IsOwner) return;

        if(Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(1, 100);
        }


        Vector3 movDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movDir.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movDir.z -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movDir.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movDir.x += 1f;
        }

        transform.position += movDir * moveSpeed* Time.deltaTime * 5f;
    }
}
