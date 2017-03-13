using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicCatalogue.Models;

namespace MusicCatalogue.DAL
{
    public class CatalogueInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CatalogueContext>
    {
        protected override void Seed(CatalogueContext context)
        {

            var user = new List<User>
            {
            new User{name="Renan Aguiar", email="renanc@rca.pro.br", nickName=""},
            new User{name="Homer Simpson", email="homer@rca.pro.br", nickName=""},
            new User{name="Louis Lane", email="lane@rca.pro.br", nickName=""},
            };

            var artist = new List<Artist>
            {
                new Artist{name="Madonna"},
                new Artist{name="Shania Twain"},
                new Artist{name="Tina Turner"}
            };

            artist.ForEach(s => context.Artist.Add(s));
            context.SaveChanges();

            var album = new List<Album>
            {
            new Album{artistID=1,name="Ray of Light",cover="rol.png",year=1998,genre=Genre.Pop},
            new Album{artistID=1,name="You Can Dance",cover="ycd.png",year=1987,genre=Genre.Pop},
            new Album{artistID=2,name="Come On Over",cover="coo.png",year=1997,genre=Genre.Country},
            };
            album.ForEach(s => context.Album.Add(s));
            context.SaveChanges();

            var track = new List<Track>
            {
            new Track{albumID=1,title="Drowned World/Substitute for Love",trackNumber=1,duration=309},
            new Track{albumID=1,title="Swim",trackNumber=2,duration=300},
            new Track{albumID=1,title="Ray of Light",trackNumber=3,duration=321},
            new Track{albumID=1,title="Candy Perfume Girl",trackNumber=4,duration=274},
            new Track{albumID=1,title="Skin",trackNumber=5,duration=382},
            new Track{albumID=1,title="Nothing Really Matters",trackNumber=6,duration=267},
            new Track{albumID=1,title="Sky Fits Heaven",trackNumber=7,duration=290},
            new Track{albumID=1,title="Shanti/Ashtangi",trackNumber=8,duration=269},
            new Track{albumID=1,title="Frozen",trackNumber=9,duration=372},
            new Track{albumID=1,title="The Power of Good-Bye",trackNumber=10,duration=250},
            new Track{albumID=1,title="To Have and Not to Hold",trackNumber=11,duration=323},
            new Track{albumID=1,title="Little Star",trackNumber=12,duration=318},
            new Track{albumID=1,title="Mer Girl",trackNumber=13,duration=332},

            new Track{albumID=2,title="Spotlight",trackNumber=1,duration=383},
            new Track{albumID=2,title="Holiday",trackNumber=2,duration=392},
            new Track{albumID=2,title="Everybody",trackNumber=3,duration=403},
            new Track{albumID=2,title="Physical Attraction",trackNumber=4,duration=380},
            new Track{albumID=2,title="Over and Over",trackNumber=5,duration=431},
            new Track{albumID=2,title="Into the Groove",trackNumber=6,duration=506},
            new Track{albumID=2,title="Where's the Party",trackNumber=7,duration=436},

            new Track{albumID=3,title="You're Still the One",trackNumber=1,duration=0},
            new Track{albumID=3,title="When",trackNumber=2,duration=0},
            new Track{albumID=3,title="From This Moment On(The Right Mix)",trackNumber=3,duration=0},
            new Track{albumID=3,title="Black Eyes, Blue Tears",trackNumber=4,duration=0},
            new Track{albumID=3,title="I Won't Leave You Lonely",trackNumber=5,duration=0},
            new Track{albumID=3,title="I'm Holdin' On to Love (To Save My Life)",trackNumber=6,duration=0},
            new Track{albumID=3,title="Come On Over",trackNumber=7,duration=0},
            new Track{albumID=3,title="You've Got a Way(Notting Hill Remix)",trackNumber=8,duration=0},
            new Track{albumID=3,title="Whatever You Do! Don't!",trackNumber=9,duration=0},
            new Track{albumID=3,title="Man! I Feel Like a Woman!",trackNumber=10,duration=0},
            new Track{albumID=3,title="Love Gets Me Every Time",trackNumber=11,duration=0},
            new Track{albumID=3,title="Don't Be Stupid (You Know I Love You)",trackNumber=12,duration=0},
            new Track{albumID=3,title="That Don't Impress Me Much(UK Dance Mix)",trackNumber=13,duration=0},
            new Track{albumID=3,title="Honey, I'm Home",trackNumber=14,duration=0},
            new Track{albumID=3,title="If You Wanna Touch Her, Ask!",trackNumber=15,duration=0},
            new Track{albumID=3,title="Rock This Country!",trackNumber=16,duration=0},


            };
            track.ForEach(s => context.Track.Add(s));
            context.SaveChanges();

            var catalogue = new List<Catalogue>
            {
            new Catalogue{userID=1,albumID=1},
            new Catalogue{userID=1,albumID=2},
            new Catalogue{userID=2,albumID=2},
            };
            catalogue.ForEach(s => context.Catalogue.Add(s));
            context.SaveChanges();



        }
    }
}