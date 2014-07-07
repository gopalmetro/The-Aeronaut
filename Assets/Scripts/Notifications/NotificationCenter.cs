//Assistance from: http://www.developermemo.com/2362547/
// Usage:
// NotificationCenter.defaultCenter.addListener( onNotification );
// NotificationCenter.defaultCenter.sendNotification( new Notification( NotificationTypes.OnStuff, this ) );
// NotificationCenter.defaultCenter.removeListener( onNotification, NotificationType.OnStuff );

using UnityEngine;
using System.Collections;

public enum NotificationType
{
    OnEvent,
    OnPowerUp,
    OnAchievableEvent,
    BalloonPop,
    BackgroundObjectNotification,
    Death,
    TotalNotifications,
}
;

public delegate void OnNotificationDelegate (Notification note);

public class NotificationCenter {

	private static NotificationCenter instance;
	private ArrayList[] listeners = new ArrayList[(int)NotificationType.TotalNotifications];

	public NotificationCenter () {
		if (instance != null) {
			Debug.Log ("NotificationCenter instance is not null");
			return;
		}
		instance = this;
	}

	public static NotificationCenter defaultCenter {
		get {
			if (instance == null)
				new NotificationCenter ();
			return instance;
		}
	}

	public void addListener (OnNotificationDelegate newListenerDelegate, NotificationType type) {
		int typeInt = (int)type;
		if (listeners [typeInt] == null)
			listeners [typeInt] = new ArrayList ();

		listeners [typeInt].Add (newListenerDelegate);
	}

	public void removeListener (OnNotificationDelegate listenerDelegate, NotificationType type) {
		int typeInt = (int)type;

		if (listeners [typeInt] == null)
			return;

		if (listeners [typeInt].Contains (listenerDelegate))
			listeners [typeInt].Remove (listenerDelegate);

		if (listeners [typeInt].Count == 0)
			listeners [typeInt] = null;
	}

	public void postNotification (Notification notification) {
		int typeInt = (int)notification.type;

		if (listeners [typeInt] == null)
			return;

		foreach (OnNotificationDelegate delegateCall in listeners[typeInt]) {
			delegateCall(notification);
		}

	}

	private void NotificationCenterSetToNull () {
		instance = null;
	}

}
