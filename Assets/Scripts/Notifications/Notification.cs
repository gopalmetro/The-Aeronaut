﻿using UnityEngine;
using System.Collections;

public class Notification {

	public NotificationType type;
	public object userInfo;

	public Notification (NotificationType type) {
		this.type = type;
	}

	public Notification (NotificationType type, object userInfo) {
		this.type = type;
		this.userInfo = userInfo;
	}
}
