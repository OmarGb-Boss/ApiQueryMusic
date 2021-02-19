using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ApiQueryMusic.Data
{

    public class DataClient
    {
        static HttpClient client = new HttpClient();
        //Artista por genero
        public List<Artist> GetArtistByGenre(string Genre)
        {
            List<Artist> lstArtist = new List<Artist>();
            HttpResponseMessage wcfResponse = client.GetAsync(string.Concat("http://localhost:61510/QueryMusic.svc/artistByGenre/", Genre)).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            lstArtist = JsonConvert.DeserializeObject<List<Artist>>(data.Result);
            return lstArtist;
        }


        //Album por artista
        public List<Album> GetAlbumByArtist(string Artist)
        {
            List<Album> lstArtist = new List<Album>();
            HttpResponseMessage wcfResponse = client.GetAsync(string.Concat("http://localhost:61510/QueryMusic.svc/albumByArtist/", Artist)).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            lstArtist = JsonConvert.DeserializeObject<List<Album>>(data.Result);
            return lstArtist;
        }

        //Canciones por album
        public List<Tracks> GetSongsByAlbum(string Album)
        {
            List<Tracks> lstAlbum = new List<Tracks>();
            HttpResponseMessage wcfResponse = client.GetAsync(string.Concat("http://localhost:61510/QueryMusic.svc/songsByAlbum/", Album)).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            lstAlbum = JsonConvert.DeserializeObject<List<Tracks>>(data.Result);
            return lstAlbum;
        }

        //artistas por cancion
        public List<Artist> GetArtistBySong(string song)
        {
            List<Artist> lstArtist = new List<Artist>();
            HttpResponseMessage wcfResponse = client.GetAsync(string.Concat("http://localhost:61510/QueryMusic.svc/artistBySong/", song)).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            lstArtist = JsonConvert.DeserializeObject<List<Artist>>(data.Result);
            return lstArtist;
        }

        //All generes
        public List<Genre> GetAllGenre() 
        {
            List<Genre> lstGeneres = new List<Genre>();
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:61510/QueryMusic.svc/allGenre").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            lstGeneres = JsonConvert.DeserializeObject<List<Genre>>(data.Result);
            return lstGeneres;
        }
    }



    public class Artist
    {
        public string NameArtist { get; set; }
    }

    public class Album
    {
        public string NameAlbum { get; set; }
    }

    public class Tracks
    {
        public string nameSong { get; set; }
    }

    public class SubGenre
    {
        public string NombreSubGenero { get; set; }
    }
    public class Genre
    {
        public string NameGenere { get; set; }
        public List<SubGenre> lstSubGeneres;
    }
}
