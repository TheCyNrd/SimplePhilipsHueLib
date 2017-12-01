# SimplePhilipsHueLib
Simple C# Library to Control Philips Hue

Usage

        PhilipsHue HueBridge = new PhilipsHue("YourBridgeIP", "YourUsername");

Turn on Bulp ID 1

        HueBridge.TurnOn(true,null,null,1);

Turn on Bulp ID 1 with Color:      

        HueBridge.TurnOn(true,Color.Red,null,1);
        
Turn on Group ID 0:

        HueBridge.TurnOn(true,null,0,null)

Turn on Group ID 0:

        HueBridge.TurnOn(true,null,0,null)
