using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;

namespace ZXing
{
    [BaseType (typeof (UIViewController), Delegates = new string[] { "WeakDelegate" }, Events = new Type[] { typeof(ZXingDelegate) })]
    interface ZXingWidgetController
    {
        [Export ("initWithDelegate:showCancel:OneDMode:")]
        IntPtr Constructor ([NullAllowed]ZXingDelegate zxingDelegate, bool shouldShowCancel, bool oneDMode);

        [Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Wrap ("WeakDelegate"), NullAllowed]
        ZXingDelegate Delegate { get; set; }

        [Export ("captureSession")]
        AVCaptureSession CaptureSession { get; set; }

        [Export ("prevLayer")]
        AVCaptureVideoPreviewLayer PrevLayer { get; set; }

        [Export ("readers")]
        NSSet Readers { get; set; }

        [Export ("soundToPlay")]
        NSUrl SoundToPlay { get; set; }

        [Export ("result")]
        ParsedResult Result { get; set; }

        [Export ("overlayView")]
        OverlayView OverlayView { get; set; }

        [Export ("fixedFocus")]
        bool FixedFocus { get; }

        [Export ("setTorch:")]
        void SetTorch(bool status);

        [Export ("torchIsOn")]
        bool TorchIsOn { get; }

        [Export ("reset")]
        void Reset ();
    }

    [BaseType (typeof (NSObject))]
    [Model]
    interface ZXingDelegate
    {
        [Abstract, Export ("zxingController:didScanResult:"), EventArgs("ZXingScanResult")]
        void DidScanResult (ZXingWidgetController controller, string result);

        [Abstract, Export ("zxingControllerDidCancel:"), EventArgs("ZXingCancel")]
        void DidCancel (ZXingWidgetController controller);
    }

    #region OverlayView
    [BaseType (typeof (UIView), Delegates = new string[] { "WeakDelegate" })]
    interface OverlayView
    {
        [Export ("initWithFrame:cancelEnabled:oneDMode:")]
        IntPtr Constructor (RectangleF frame, bool isCancelEnabled, bool isOneDModeEnabled);

        [Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Wrap ("WeakDelegate"), NullAllowed]
        CancelDelegate Delegate { get; set; }

        [Export ("points")]
        NSMutableArray Points { get; set; }

        [Export ("oneDMode")]
        bool OneDMode { get; set; }

        [Export ("cropRect")]
        RectangleF CropRect { get; set; }

        [Export ("displayedMessage")]
        string DisplayedMessage { get; set; }

        [Export ("setPoint:")]
        void SetPoint (PointF point);
    }

    [BaseType (typeof(NSObject))]
    [Model]
    interface CancelDelegate
    {
        [Abstract, Export("cancelled"), EventArgs("Cancel")]
        void Cancelled ();
    }
    #endregion

    #region ParsedResults
    [BaseType (typeof (NSObject))]
    interface ParsedResult
    {
        [Static, Export ("typeName")]
        string TypeName { get; }

        [Export ("stringForDisplay")]
        string StringForDisplay { get; }

        [Export ("icon")]
        UIImage Icon { get;}

        [Export ("actions")]
        NSArray Actions { get; }

        [Export ("populateActions")]
        void PopulateActions ();
    }
    #endregion
}

namespace ZXing.Readers
{
    [BaseType (typeof (NSObject))]
    interface FormatReader
    {

    }

    [BaseType (typeof (FormatReader))]
    interface QRCodeReader
    {

    }
}