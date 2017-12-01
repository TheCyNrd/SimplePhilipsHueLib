# SimplePhilipsHueLib
Simple C# Library to Control Philips Hue

**Usage**

        PhilipsHue HueBridge = new PhilipsHue("YourBridgeIP", "YourUsername");

**Turn on Bulp ID 1**

        HueBridge.TurnOn(true,null,null,1);

**Turn on Bulp ID 1 with Color:**    

        HueBridge.TurnOn(true,Color.Red,null,1);

**Turn off Bulp ID 1**

        HueBridge.TurnOn(false,null,null,1);
        
Turn on Group ID 0:

        HueBridge.TurnOn(true,null,0,null)

Turn on Group ID 0 with Color:

        HueBridge.TurnOn(true,Color.Red,0,null)

Turn off Group ID 0

        HueBridge.TurnOn(true,null,0,null)
        
Change Color of Bulp ID 1
        
        HueBridge.SetColor(Color.Blue, null,1);

Change Color of Group ID 0
        
        HueBridge.SetColor(Color.Blue, 0);

Effects

Colorloop on Bulp ID 1

            HueBridge.Effect("colorloop",null,1);

Colorloop off Bulp ID 1

            HueBridge.Effect("none",null,1);

Colorloop on Group ID 0

            HueBridge.Effect("colorloop",0,null);

Colorloop off Group ID 0

            HueBridge.Effect("none",0,null);

Alert on Bulp ID 1 with Color

            HueBridge.Alert("lselect",Color.Red,null,1);
            //Or
            HueBridge.Alert("select",Color.Red,null,1);

Alert on Group ID 1 with Color

            HueBridge.Alert("lselect",Color.Red,0,null);
            //Or
            HueBridge.Alert("select",Color.Red,0,null);
