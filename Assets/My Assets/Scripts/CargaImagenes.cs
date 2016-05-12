using UnityEngine;
using System.Collections;

namespace My_Assets.Scripts {
    public class CargaImagenes : MonoBehaviour
    {
        public GameObject Plane1;
        public GameObject Plane2;
        public GameObject Plane3;
        public GameObject Plane4;
        public GameObject Plane5;
        public GameObject Plane6;
        public GameObject Plane7;
        public GameObject Plane8;
        public GameObject Plane9;

        public GameObject cube;

        private float tileX;
        private float tileY;
        private LocationInfo loc;

        private float lat2, lat3, lat4, lat5, lat6, lat7, lat8, lat9;
        private float lon2, lon3, lon4, lon5, lon6, lon7, lon8, lon9;

        private float lat1 = 41.38885f;
        private float lon1 = 2.195817f;


        private int zoom1 = 16;



        IEnumerator Start ()
        {
            Input.location.Start(0.1f,0.1f);
            loc = Input.location.lastData;

            lat1 = loc.latitude;
            lon1 = loc.longitude;

            WorldToTilePos(lon1, lat1, zoom1);
            Point p = WorldToTilePos(1.986961, 41.27519, zoom1);
            Plane1.transform.position = new Vector3(Plane1.transform.localScale.x / 2, Plane1.transform.localScale.z / 2, 0);
            print(p.X + " " + p.Y);
            int x = Mathf.FloorToInt((float)p.X);
            int y = Mathf.FloorToInt((float)p.Y);
            print("X " + x + " Y " + y);
            WWW www = new WWW("http://a.tile.openstreetmap.org/"+ zoom1 + "/"+ x + "/ " + y + ".png");
            yield return www;
            Texture2D texture = new Texture2D(1, 1, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane1.GetComponent<Renderer>().material.mainTexture = texture;


            foreach (Transform t in cube.transform) {
                GameObject item = t.gameObject;
                double a = DrawCubeX(item.GetComponent<ItemCoordenadas>().Long, TileToWorldPos(x, y, zoom1).X, TileToWorldPos(x + 1, y, zoom1).X);
                double b = DrawCubeY(item.GetComponent<ItemCoordenadas>().Lat, TileToWorldPos(x, y + 1, zoom1).Y, TileToWorldPos(x, y, zoom1).Y);
                item.transform.position = new Vector3((float)a, (float)b, item.transform.position.z);
            }

            /*Plano 1

            string url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            Texture2D texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane1.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY + 1;
            tileX = tileX - 1;*/

            /*Plano 2

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane2.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY + 1;*/

            /*Plano 3

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane3.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY + 1;*/
            tileX = tileX + 1;

            /*Plano 4

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane4.GetComponent<Renderer>().material.mainTexture = texture;
            tileX = tileX - 1;*/

            /*Plano 5

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane5.GetComponent<Renderer>().material.mainTexture = texture;*/

            /*Plano 6

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane6.GetComponent<Renderer>().material.mainTexture = texture;
            tileX = tileX + 1;*/

            /*Plano 7

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane7.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY - 1;
            tileX = tileX - 1;*/

            /*Plano 8

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane8.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY - 1;*/

            /*Plano 9

            url = "http://a.tile.openstreetmap.org/" + zoom1 + "/" + Mathf.FloorToInt(tileX) + "/" + Mathf.FloorToInt(tileY) + ".png";
            www = new WWW(url);
            yield return www;
            texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
            www.LoadImageIntoTexture(texture);
            Plane9.GetComponent<Renderer>().material.mainTexture = texture;
            tileY = tileY + -1;
            tileX = tileX + 1;*/
        }

        public struct Point
        {
            public double X;
            public double Y;
        }

        public Point WorldToTilePos(double lon, double lat, int zoom)
        {
            Point p;
            p.X = ((lon + 180.0) / 360.0 * System.Math.Pow(2.0, zoom));
            p.Y = ((1.0 - System.Math.Log(System.Math.Tan(lat * System.Math.PI / 180.0) +
            1.0 / System.Math.Cos(lat * System.Math.PI / 180.0)) / System.Math.PI) / 2.0 * System.Math.Pow(2.0, zoom));

            return p;
        }

        // X -> longitud
        // Y -> latitud
        // devuelve la esquina superior izquierda del tile
        public Point TileToWorldPos(double tile_x, double tile_y, int zoom)
        {
            Point p = new Point();
            double n = System.Math.PI - ((2.0 * System.Math.PI * tile_y) / System.Math.Pow(2.0, zoom));

            p.X = ((tile_x / System.Math.Pow(2.0, zoom) * 360.0) - 180.0);
            p.Y = (180.0 / System.Math.PI * System.Math.Atan(System.Math.Sinh(n)));

            return p;
        }

        public double DrawCubeY(double targetLat, double minLat, double maxLat)
        {
            double pixelY = ((targetLat - minLat) / (maxLat - minLat)) * Plane1.transform.localScale.x;
            return pixelY;
        }

        public double DrawCubeX(double targetLong, double minLong, double maxLong)
        {
            double pixelX = ((targetLong - minLong) / (maxLong - minLong)) * Plane1.transform.localScale.z;
            return pixelX;
        }
    }
}
