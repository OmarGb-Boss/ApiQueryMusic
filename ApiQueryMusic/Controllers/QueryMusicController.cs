using ApiQueryMusic.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQueryMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class QueryMusicController : Controller
    {
        private Data.DataClient _Dc;
        public QueryMusicController(Data.DataClient Dc)
        {
            _Dc = Dc;
        }

        // url https://localhost:44330/api/QueryMusic/getArtistByGenre/{Genre}
        [HttpGet("getArtistByGenre/{Genre}")]
        public List<Artist> GetArtistByGen(string Genre)
        {
            return _Dc.GetArtistByGenre(Genre);
        }

        [HttpGet("getAlbumByArtist/{Artist}")]
        public List<Album> GetAlbumByArtist(string artist)
        {
            return _Dc.GetAlbumByArtist(artist);
        }

        [HttpGet("getSongsByAlbum/{Album}")]
        public List<Tracks> GetSongsByAlbum(string album)
        {
            return _Dc.GetSongsByAlbum(album);
        }


        [HttpGet("getArtistBySong/{song}")]
        public List<Artist> GetArtistBySong(string song)
        {
            return _Dc.GetArtistBySong(song);
        }

        [HttpGet("getAllGenre")]
        public IEnumerable<Genre> GetAllGenre()
        {
            List<Genre> LIstGenre = new List<Genre>();         
            foreach (var i in _Dc.GetAllGenre()) 
            {
                Genre GenreObject = new Genre
                {
                    NameGenere = i.NameGenere,
                    lstSubGeneres = new List<SubGenre>()
                };
                foreach (var s in i.lstSubGeneres) 
                {
                    GenreObject.lstSubGeneres.Add(new SubGenre { NombreSubGenero = s.NombreSubGenero });
                }
                LIstGenre.Add(GenreObject);
            }
            return LIstGenre;
        }
    }
}
