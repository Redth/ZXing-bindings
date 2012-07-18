using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libZXingWidget.a", LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true, IsCxx = true, Frameworks = "AVFoundation AudioToolbox CoreVideo CoreMedia AddressBook AddressBookUI")]
