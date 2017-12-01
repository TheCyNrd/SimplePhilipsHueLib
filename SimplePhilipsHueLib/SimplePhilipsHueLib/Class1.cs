using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhilipsHue
{
    static List<Double> Doubles;
    public static string Username = "";
    public static string ip = "";
    private static string url;

    public PhilipsHue(string Ip, string username)
    {
        ip = Ip;
        Username = username;
        url = "http://" + ip + "/api/" + Username + "/";
    }
    private List<Double> getRGBtoXY(Color c)
    {
        double[] normalizedToOne = new double[3];
        float cred, cgreen, cblue;
        cred = (float)c.R;
        cgreen = (float)c.G;
        cblue = (float)c.B;
        normalizedToOne[0] = (cred / 255);
        normalizedToOne[1] = (cgreen / 255);
        normalizedToOne[2] = (cblue / 255);
        float red, green, blue;
        if (normalizedToOne[0] > 0.04045) { red = (float)Math.Pow((normalizedToOne[0] + 0.055) / (1.0 + 0.055), 2.4); } else { red = (float)(normalizedToOne[0] / 12.92); }
        if (normalizedToOne[1] > 0.04045) { green = (float)Math.Pow((normalizedToOne[1] + 0.055) / (1.0 + 0.055), 2.4); } else { green = (float)(normalizedToOne[1] / 12.92); }
        if (normalizedToOne[2] > 0.04045) { blue = (float)Math.Pow((normalizedToOne[2] + 0.055) / (1.0 + 0.055), 2.4); } else { blue = (float)(normalizedToOne[2] / 12.92); }
        double X = (red * 0.649926 + green * 0.103455 + blue * 0.197109); double Y = (red * 0.234327 + green * 0.743075 + blue * 0.022598); float Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763); double x = X / (X + Y + Z); double y = Y / (X + Y + Z); double z = Z / (X + Y + Z); double[] xy = new double[2]; xy[0] = x; xy[1] = y; //xy[2] = z;
        List<Double> xyAsList = xy.ToList();
        return xyAsList;

    }

    public void SetLight(Color color, int? group = null,int? bulp=0)
    {
        using (var client = new System.Net.WebClient())
        {
            Random rnd = new Random();
            Color c = Color.White;
            var cmd = "/lights/" + bulp + "/state";
            if(group != null)
            cmd = "groups/" + group + "/action";
            
            
                c = color;
                var xy = JsonConvert.SerializeObject(getRGBtoXY(color));
                client.UploadData(url + cmd, "PUT", Encoding.ASCII.GetBytes("{\"sat\":254,\"bri\":" + Brightness(c) + ",\"xy\":" + xy + "}"));
            client.Dispose();
        }
    }

    public void TurnOn(bool status, Color? c = null, int? group = null, int? bulp = 0)
    {
        using (var client = new System.Net.WebClient())
        {
            Color selected = Color.White;
            if (c != null)
                selected = c.Value;
            var cmd = "lights/"+bulp+"/state";
            if(group!=null)
            cmd = "groups/" + group + "/action";



            
                var xy = JsonConvert.SerializeObject(getRGBtoXY(selected));
                client.UploadData(url + cmd, "PUT", Encoding.ASCII.GetBytes("{\"on\":" + status.ToString().ToLower() + ",\"bri\":254,\"xy\":" + xy + "}"));
            client.Dispose();
        }
    }

    public void Effect(string effect = "none", int? group = null, int? bulp = 0)
    {
        using (var client = new System.Net.WebClient())
        {
            Color selected = Color.White;
            var cmd = "lights/" + bulp + "/state";
            if (group != null)
                cmd = "groups/" + group + "/action";

            var xy = JsonConvert.SerializeObject(getRGBtoXY(selected));
                client.UploadData(url + cmd, "PUT", Encoding.ASCII.GetBytes("{\"effect\":\"" + effect + "\"}"));
            client.Dispose();
        }
    }

    public void Alert(string effect, Color? c = null,int? group=0, int? bulp = 0)
    {
        using (var client = new System.Net.WebClient())
        {
            Color selected = Color.White;
            if (c != null)
                selected = c.Value;
            var cmd = "lights/" + bulp + "/state";
            if (group != null)
                cmd = "groups/" + group + "/action";


            var xy = JsonConvert.SerializeObject(getRGBtoXY(selected));
                client.UploadData(url + cmd, "PUT", Encoding.ASCII.GetBytes("{\"alert\":\"" + effect + "\"}"));
            client.Dispose();
        }
    }

    private int Brightness(Color c)
    {
        int b = (int)Math.Sqrt(
           c.R * c.R * .241 +
           c.G * c.G * .691 +
           c.B * c.B * .068);
        return b;
    }
}
