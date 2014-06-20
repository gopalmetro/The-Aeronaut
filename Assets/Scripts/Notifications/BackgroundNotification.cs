using UnityEngine;
using System.Collections;

public class BackgroundNotification : Notification {

    public GameObject gameObj;
	
    public BackgroundNotification( NotificationType type, GameObject gameObject ) : base( type )
	{
		this.gameObj = gameObject;
	}
}
