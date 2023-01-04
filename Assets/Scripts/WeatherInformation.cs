using System.Collections.Generic;
using System;

namespace WeatherInformation
{
    //This was made using Visual Studios 2022 Paste Special Method
    [Serializable]
    public class WeatherInfo
    {
        public Coord coord;
        public List<Weather> weather;
        public string _base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timezone;
        public int id;
        public string name;
        public int cod;
    }


    [Serializable]
    public class Coord
    {
        public float lon;
        public int lat;
    }

    [Serializable]
    public class Main
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public int pressure;
        public int humidity;
        public int sea_level;
        public int grnd_level;
    }

    [Serializable]
    public class Wind
    {
        public float speed;
        public int deg;
        public float gust;
    }

    [Serializable]
    public class Clouds
    {
        public int all;
    }

    [Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public int sunrise;
        public int sunset;
    }

    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }
}

